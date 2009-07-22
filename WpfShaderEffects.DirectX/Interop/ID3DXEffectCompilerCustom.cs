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
   interface ID3DXEffectCompilerCustom
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
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         uint index);

      [PreserveSig]
      IntPtr GetParameterByName(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetParameterBySemantic(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] string semantic);

      [PreserveSig]
      IntPtr GetParameterElement(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         uint index);

      [PreserveSig]
      IntPtr GetTechnique(uint index);

      [PreserveSig]
      IntPtr GetTechniqueByName([MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      IntPtr GetPass(
         [MarshalAs(UnmanagedType.LPStr)] string techniqueHandle,
         uint index);

      [PreserveSig]
      IntPtr GetPassByName(
         [MarshalAs(UnmanagedType.LPStr)] string techniqueHandle,
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
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         IntPtr data,
         uint bytes);

      [PreserveSig]
      Int32 GetValue(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         IntPtr data,
         uint bytes);

      [PreserveSig]
      Int32 SetBool(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] bool b);

      [PreserveSig]
      Int32 GetBool(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] out bool b);

      [PreserveSig]
      Int32 SetBoolArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] bool[] b,
         uint count);

      [PreserveSig]
      Int32 GetBoolArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool,
            SizeParamIndex = 2)] out bool[] b,
         uint count);

      [PreserveSig]
      Int32 SetInt(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         int b);

      [PreserveSig]
      Int32 GetInt(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out int b);

      [PreserveSig]
      Int32 SetIntArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] n,
         uint count);

      [PreserveSig]
      Int32 GetIntArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out int[] n,
         uint count);

      [PreserveSig]
      Int32 SetFloat(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         float b);

      [PreserveSig]
      Int32 GetFloat(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out float b);

      [PreserveSig]
      Int32 SetFloatArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] n,
         uint count);

      [PreserveSig]
      Int32 GetFloatArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out float[] n,
         uint count);

      [PreserveSig]
      Int32 SetVector(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] ref D3DXVector4 b);

      [PreserveSig]
      Int32 GetVector(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out D3DXVector4 b);

      [PreserveSig]
      Int32 SetVectorArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXVector4[] n,
         uint count);

      [PreserveSig]
      Int32 GetVectorArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXVector4[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrix(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] ref D3DXMatrix16 b);

      [PreserveSig]
      Int32 GetMatrix(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out D3DXMatrix16 b);

      [PreserveSig]
      Int32 SetMatrixArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixPointerArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixPointerArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTranspose(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] ref D3DXMatrix16 b);

      [PreserveSig]
      Int32 GetMatrixTranspose(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out D3DXMatrix16 b);

      [PreserveSig]
      Int32 SetMatrixTransposeArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixTransposeArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out
            D3DXMatrix16[] n,
         uint count);

      [PreserveSig]
      Int32 SetMatrixTransposePointerArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 GetMatrixTransposePointerArray(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out IntPtr[] n,
         uint count);

      [PreserveSig]
      Int32 SetString(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [In] [MarshalAs(UnmanagedType.LPStr)] string name);

      [PreserveSig]
      Int32 GetString(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.LPStr)] out string name);

      [PreserveSig]
      Int32 SetTexture(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         IntPtr texture);

      [PreserveSig]
      Int32 GetTexture(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out IntPtr texture);

      [PreserveSig]
      Int32 GetPixelShader(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out IDirect3DPixelShader9 pixelShader);

      [PreserveSig]
      Int32 GetVertexShader(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         out IDirect3DVertexShader9 vertexShader);

      [PreserveSig]
      Int32 SetArrayRange(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         uint start,
         uint end);

      //// ID3DXBaseEffect

      //// Parameter sharing, specialization, and information
      [PreserveSig]
      Int32 SetLiteral(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] bool literal);

      [PreserveSig]
      Int32 GetLiteral(
         [MarshalAs(UnmanagedType.LPStr)] string parameterHandle,
         [MarshalAs(UnmanagedType.Bool)] out bool literal);

      //// Compilation
      [PreserveSig]
      Int32 CompileEffect(
         D3DXSHADER flags,
         out ID3DXBuffer effect,
         out ID3DXBuffer errorMsgs);

      [PreserveSig]
      Int32 CompileShader(
         [MarshalAs(UnmanagedType.LPStr)] string function,
         [MarshalAs(UnmanagedType.LPStr)] string target,
         D3DXSHADER flags,
         out ID3DXBuffer shader,
         out ID3DXBuffer errorMsgs,
         out ID3DXConstantTable constantTable);
   }
}