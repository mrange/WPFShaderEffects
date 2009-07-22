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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace WpfShaderEffects.DirectX
{
   static class NativeMethods
   {
      const string Kernel32Dll = "kernel32";

      [DllImport(Kernel32Dll, EntryPoint = "LoadLibraryW",
         CharSet = CharSet.Unicode, SetLastError = true,
         ExactSpelling = true)]
      public static extern SafeLibraryHandle LoadLibrary(string fileName);

      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      [DllImport(Kernel32Dll, SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      public static extern bool FreeLibrary(IntPtr hModule);

      [DllImport(Kernel32Dll, CharSet = CharSet.Ansi, ExactSpelling = true)]
      public static extern IntPtr GetProcAddress(
         SafeLibraryHandle hModule,
         string procname);
   }
}