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
   [Guid("51b8a949-1a31-47e6-bea0-4b30db53f1e0")]
   [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   interface ID3DXEffectCompiler
   {
      //[PreserveSig] HRESULT QueryInterface;
      //[PreserveSig] HRESULT AddRef;
      //[PreserveSig] HRESULT Release;

      [PreserveSig]
      Int32 GetDesc(out D3DXEFFECT_DESC desc);

      [PreserveSig]
      Int32 GetParameterDesc(
         IntPtr parameterHandle,
         out D3DXPARAMETER_DESC desc);

      [PreserveSig]
      Int32 GetTechniqueDesc(
         IntPtr techniqueHandle,
         out D3DXTECHNIQUE_DESC desc);

      [PreserveSig]
      Int32 GetPassDesc(
         IntPtr passHandle,
         out D3DXPASS_DESC desc);

      [PreserveSig]
      Int32 GetFunctionDesc(
         IntPtr functionHandle,
         out D3DXFUNCTION_DESC desc);

      // Handle operations

      [PreserveSig]
      IntPtr GetParameter(
         IntPtr parameterHandle,
         uint index);

      [PreserveSig]
      IntPtr GetParameterByName(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetParameterBySemantic(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] string semantic);

      [PreserveSig]
      IntPtr GetParameterElement(
         IntPtr parameterHandle,
         uint index);

      [PreserveSig]
      IntPtr GetTechnique(uint index);

      [PreserveSig]
      IntPtr GetTechniqueByName([MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetPass(
         IntPtr techniqueHandle,
         uint index);

      [PreserveSig]
      IntPtr GetPassByName(
         IntPtr techniqueHandle,
         [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetFunction(uint index);

      [PreserveSig]
      IntPtr GetFunctionByName([MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetAnnotation(
         IntPtr objectHandle,
         uint index);

      [PreserveSig]
      IntPtr GetAnnotationByName(
         IntPtr objectHandle,
         [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      Int32 SetValue(
         IntPtr parameterHandle,
         IntPtr data,
         uint bytes);

      [PreserveSig]
      Int32 GetValue(
         IntPtr parameterHandle,
         IntPtr data,
         uint bytes);

      [PreserveSig]
      Int32 SetBool(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] bool b);

      [PreserveSig]
      Int32 GetBool(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] out bool b);

      [PreserveSig]
      Int32 SetBoolArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] bool[] b,
         uint count);

      [PreserveSig]
      Int32 GetBoolArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] out bool[] b,
         uint count);

      [PreserveSig]
      Int32 SetInt(
         IntPtr parameterHandle,
         int b);

      [PreserveSig]
      Int32 GetInt(
         IntPtr parameterHandle,
         out int b);

      [PreserveSig]
      Int32 SetIntArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] n,
         uint count);

      [PreserveSig]
      Int32 GetIntArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out int[] n,
         uint count);

      [PreserveSig]
      Int32 SetFloat(
         IntPtr parameterHandle,
         float b);

      [PreserveSig]
      Int32 GetFloat(
         IntPtr parameterHandle,
         out float b);

      [PreserveSig]
      Int32 SetFloatArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] n,
         uint count);

      [PreserveSig]
      Int32 GetFloatArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out float[] n,
         uint count);

      [PreserveSig]
      Int32 SetVector(
         IntPtr parameterHandle,
         [In] ref D3DXVector4 b);

      [PreserveSig]
      Int32 GetVector(
         IntPtr parameterHandle,
         out D3DXVector4 b);

      [PreserveSig]
      Int32 SetVectorArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXVector4[] n,
         uint count);

      [PreserveSig]
      Int32 GetVectorArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXVector4[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrix(
         IntPtr parameterHandle,
         [In] ref D3DXMatrix16 b);

      [PreserveSig]
      Int32 GetMatrix(
         IntPtr parameterHandle,
         out D3DXMatrix16 b);

      [PreserveSig]
      Int32 SetMatrixArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixPointerArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixPointerArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTranspose(
         IntPtr parameterHandle,
         [In] ref D3DXMatrix16 b);

      [PreserveSig]
      Int32 GetMatrixTranspose(
         IntPtr parameterHandle,
         out D3DXMatrix16 b);

      [PreserveSig]
      Int32 SetMatrixTransposeArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixTransposeArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTransposePointerArray(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixTransposePointerArray(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 SetString(
         IntPtr parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      Int32 GetString(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] out string name);

      [PreserveSig]
      Int32 SetTexture(
         IntPtr parameterHandle,
         IntPtr texture);

      [PreserveSig]
      Int32 GetTexture(
         IntPtr parameterHandle,
         out IntPtr texture);

      [PreserveSig]
      Int32 GetPixelShader(
         IntPtr parameterHandle,
         out IDirect3DPixelShader9 pixelShader);

      [PreserveSig]
      Int32 GetVertexShader(
         IntPtr parameterHandle,
         out IDirect3DVertexShader9 vertexShader);

      Int32 SetArrayRange(
         IntPtr parameterHandle,
         uint start,
         uint end);

      //// ID3DXBaseEffect

      //// Parameter sharing, specialization, and information
      [PreserveSig]
      Int32 SetLiteral(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] bool literal);

      [PreserveSig]
      Int32 GetLiteral(
         IntPtr parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] out bool literal);

      //// Compilation
      [PreserveSig]
      Int32 CompileEffect(
         D3DXSHADER flags,
         out ID3DXBuffer effect,
         out ID3DXBuffer errorMsgs);

      [PreserveSig]
      Int32 CompileShader(
         IntPtr functionHandle,
         [MarshalAs(UnmanagedType.LPStr)] string target,
         D3DXSHADER flags,
         out ID3DXBuffer shader,
         out ID3DXBuffer errorMsgs,
         out ID3DXConstantTable constantTable);
   }
}