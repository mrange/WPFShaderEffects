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
   [Guid("ab3c758f-093e-4356-b762-4db18f1b3a01")]
   [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   unsafe interface ID3DXConstantTable
   {
      //[PreserveSig] HRESULT QueryInterface;
      //[PreserveSig] HRESULT AddRef;
      //[PreserveSig] HRESULT Release;

      // Buffer
      [PreserveSig]
      IntPtr GetBufferPointer();

      [PreserveSig]
      uint GetBufferSize();

      // Descs
      [PreserveSig]
      Int32 GetDesc(out D3DXCONSTANTTABLE_DESC desc);

      [PreserveSig]
      Int32 GetConstantDesc(
         IntPtr constant,
         [In] [Out] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] D3DXCONSTANT_DESC[] desc,
         [In] [Out] ref uint count);

      [PreserveSig]
      uint GetSamplerIndex(IntPtr constant);

      // Handle operations
      [PreserveSig]
      IntPtr GetConstant(
         IntPtr constant,
         uint index);

      [PreserveSig]
      IntPtr GetConstantByName(
         IntPtr constant,
         [Out] [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetConstantElement(
         IntPtr constant,
         uint index);

      // Set Constants
      [PreserveSig]
      Int32 SetDefaults(IntPtr device);

      [PreserveSig]
      Int32 SetValue(
         IntPtr device,
         IntPtr constant,
         IntPtr data,
         uint bytes);

      [PreserveSig]
      Int32 SetBool(
         IntPtr device,
         IntPtr constant,
         [MarshalAs(UnmanagedType.Bool)] bool b);

      [PreserveSig]
      Int32 SetBoolArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] bool[] array,
         uint count);

      [PreserveSig]
      Int32 SetInt(
         IntPtr device,
         IntPtr constant,
         int n);

      [PreserveSig]
      Int32 SetIntArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4,
            SizeParamIndex = 2)] int[] array,
         uint count);

      [PreserveSig]
      Int32 SetFloat(
         IntPtr device,
         IntPtr constant,
         float f);

      [PreserveSig]
      Int32 SetFloatArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R4,
            SizeParamIndex = 2)] float[] array,
         uint count);

      [PreserveSig]
      Int32 SetVector(
         IntPtr device,
         IntPtr constant,
         [In] ref D3DXVector4 f);

      [PreserveSig]
      Int32 SetVectorArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct
            ,
            SizeParamIndex = 2)] D3DXVector4[] array,
         uint count);

      [PreserveSig]
      Int32 SetMatrix(
         IntPtr device,
         IntPtr constant,
         [In] ref D3DXMatrix16 matrix);

      [PreserveSig]
      Int32 SetMatrixArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[] array,
         uint count);

      [PreserveSig]
      Int32 SetMatrixPointerArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct
            ,
            SizeParamIndex = 2)] D3DXMatrix16*[] array,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTranspose(
         IntPtr device,
         IntPtr constant,
         [In] ref D3DXMatrix16 matrix);

      [PreserveSig]
      Int32 SetMatrixTransposeArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[]
            array,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTransposePointerArray(
         IntPtr device,
         IntPtr constant,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct
            , SizeParamIndex = 2)] D3DXMatrix16*[] array,
         uint count);
   }
}