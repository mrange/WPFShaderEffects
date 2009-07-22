/* ****************************************************************************
 *
 * Copyright (c) Mårten Rånge.
 *
 * This source code is subject to terms and conditions of the Microsoft Public License. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Microsoft Public License, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Microsoft Public License.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace WpfShaderEffects.DirectX
{
   /// <summary>
   /// Utility class to wrap an unmanaged DLL and be responsible for freeing it.
   /// </summary>
   ///<remarks>
   ///This is a managed wrapper over the native LoadLibrary, GetProcAddress, and
   /// FreeLibrary calls.
   /// original: http://blogs.msdn.com/jmstall/archive/2007/01/06/Typesafe-GetProcAddress.aspx
   /// </remarks>
   ///
   sealed class UnmanagedLibrary : IDisposable
   {
      readonly SafeLibraryHandle m_hLibrary;
      public string FileName;

      UnmanagedLibrary(
         string fileName,
         SafeLibraryHandle handle)
      {
         FileName = fileName;
         m_hLibrary = handle;
      }

      #region IDisposable Members

      /// <summary>
      ///
      /// Call FreeLibrary on the unmanaged dll. All function pointers
      /// handed out from this class become invalid after this.
      /// </summary>
      ///<remarks>
      ///This is very dangerous because it suddenly invalidate
      /// everything retrieved from this dll. This includes any functions
      /// handed out via GetProcAddress, and potentially any objects returned
      /// from those functions (which may have an implemention in the
      /// dll).
      /// </remarks>
      ///
      public void Dispose()
      {
         if (!m_hLibrary.IsClosed)
         {
            m_hLibrary.Close();
         }
      }

      #endregion

      /// <summary>
      /// Constructor to load a dll and be responible for freeing it.
      /// </summary>
      ///<param name = "fileName">
      ///full path name of dll to load</param>
      ///<exception cref = "System.IO.FileNotFoundException">
      ///if fileName can't be found</exception>
      ///<remarks>
      ///Throws exceptions on failure. Most common failure would be file-not-found, or
      /// that the file is not a  loadable image.</remarks>
      public static UnmanagedLibrary LoadLibrary(
         string fileName)
      {
         return LoadLibrary(fileName, true);
      }

      /// <summary>
      /// Constructor to load a dll and be responible for freeing it.
      /// </summary>
      ///<param name = "fileName">
      ///full path name of dll to load</param>
      ///<param name = "throwOnFailure">
      ///</param>
      ///<exception cref = "System.IO.FileNotFoundException">
      ///if fileName can't be found</exception>
      ///<remarks>
      ///Throws exceptions on failure. Most common failure would be file-not-found, or
      /// that the file is not a  loadable image.</remarks>
      public static UnmanagedLibrary LoadLibrary(
         string fileName,
         bool throwOnFailure)
      {
         var handle = NativeMethods.LoadLibrary(fileName);
         var hr = Marshal.GetHRForLastWin32Error();
         if (!handle.IsInvalid)
         {
            return new UnmanagedLibrary(
               fileName,
               handle);
         }
         else if (throwOnFailure)
         {
            throw new Exception(
               string.Format(
                  "Failed to load: {0}",
                  fileName));
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Dynamically lookup a function in the dll via kernel32!GetProcAddress.
      /// </summary>
      ///<param name = "functionName">
      ///raw name of the function in the export table.</param>
      ///<returns>
      ///null if function is not found. Else a delegate to the unmanaged function.
      /// </returns>
      ///<remarks>
      ///GetProcAddress results are valid as long as the dll is not yet unloaded. This
      /// is very very dangerous to use since you need to ensure that the dll is not unloaded
      /// until after you're done with any objects implemented by the dll. For example, if you
      /// get a delegate that then gets an IUnknown implemented by this dll,
      /// you can not dispose this library until that IUnknown is collected. Else, you may free
      /// the library and then the CLR may call release on that IUnknown and it will crash.</remarks>
      ///
      public TDelegate GetUnmanagedFunction<TDelegate>(
         string functionName) where TDelegate : class
      {
         return GetUnmanagedFunction<TDelegate>(functionName, true);
      }
      /// <summary>
      /// Dynamically lookup a function in the dll via kernel32!GetProcAddress.
      /// </summary>
      ///<param name = "functionName">
      ///raw name of the function in the export table.</param>
      ///<param name = "throwOnFailure">
      ///</param>
      ///<returns>
      ///null if function is not found. Else a delegate to the unmanaged function.
      /// </returns>
      ///<remarks>
      ///GetProcAddress results are valid as long as the dll is not yet unloaded. This
      /// is very very dangerous to use since you need to ensure that the dll is not unloaded
      /// until after you're done with any objects implemented by the dll. For example, if you
      /// get a delegate that then gets an IUnknown implemented by this dll,
      /// you can not dispose this library until that IUnknown is collected. Else, you may free
      /// the library and then the CLR may call release on that IUnknown and it will crash.</remarks>
      public TDelegate GetUnmanagedFunction<TDelegate>(
         string functionName,
         bool throwOnFailure) where TDelegate : class
      {
         var p = NativeMethods.GetProcAddress(
            m_hLibrary,
            functionName);

         // Failure is a common case, especially for adaptive code.
         if (p == IntPtr.Zero)
         {
            return null;
         }
         var function = Marshal.GetDelegateForFunctionPointer(
            p,
            typeof (TDelegate));

         if (function == null && throwOnFailure)
         {
            throw new Exception(
               string.Format(
                  "Dll function couldn't be located: {0}.{1}",
                  FileName,
                  functionName));
         }

         // Ideally, we'd just make the constraint on TDelegate be
         // System.Delegate, but compiler error CS0702 (constrained can't be System.Delegate)
         // prevents that. So we make the constraint system.object and do the cast from object-->TDelegate.
         object o = function;

         return (TDelegate) o;
      }
   }
}