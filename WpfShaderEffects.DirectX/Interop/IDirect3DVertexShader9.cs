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

namespace WpfShaderEffects.DirectX.Interop
{
   [ComImport]
   [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   [Guid("EFC5557E-6265-4613-8A94-43857889EB36")]
   interface IDirect3DVertexShader9
   {
      [PreserveSig]
      Int32 GetDevice(out IntPtr device);

      [PreserveSig]
      Int32 GetFunction(
         IntPtr buffer,
         out uint size);
   }
}