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

using WpfShaderEffects.DirectX.Interop;

namespace WpfShaderEffects.DirectX
{
   enum ParameterType
   {
      Void = D3DXPARAMETER_TYPE.D3DXPT_VOID,
      Bool = D3DXPARAMETER_TYPE.D3DXPT_BOOL,
      Int = D3DXPARAMETER_TYPE.D3DXPT_INT,
      Float = D3DXPARAMETER_TYPE.D3DXPT_FLOAT,
      String = D3DXPARAMETER_TYPE.D3DXPT_STRING,
      Texture = D3DXPARAMETER_TYPE.D3DXPT_TEXTURE,
      Texture1D = D3DXPARAMETER_TYPE.D3DXPT_TEXTURE1D,
      Texture2D = D3DXPARAMETER_TYPE.D3DXPT_TEXTURE2D,
      Texture3D = D3DXPARAMETER_TYPE.D3DXPT_TEXTURE3D,
      TextureCube = D3DXPARAMETER_TYPE.D3DXPT_TEXTURECUBE,
      Sampler = D3DXPARAMETER_TYPE.D3DXPT_SAMPLER,
      Sampler1D = D3DXPARAMETER_TYPE.D3DXPT_SAMPLER1D,
      Sampler2D = D3DXPARAMETER_TYPE.D3DXPT_SAMPLER2D,
      Sampler3D = D3DXPARAMETER_TYPE.D3DXPT_SAMPLER3D,
      SamplerCube = D3DXPARAMETER_TYPE.D3DXPT_SAMPLERCUBE,
      PixelShader = D3DXPARAMETER_TYPE.D3DXPT_PIXELSHADER,
      VertexShader = D3DXPARAMETER_TYPE.D3DXPT_VERTEXSHADER,
      PixelFragment = D3DXPARAMETER_TYPE.D3DXPT_PIXELFRAGMENT,
      VertexFragment = D3DXPARAMETER_TYPE.D3DXPT_VERTEXFRAGMENT,
      Unsupported = D3DXPARAMETER_TYPE.D3DXPT_UNSUPPORTED,
   }
}