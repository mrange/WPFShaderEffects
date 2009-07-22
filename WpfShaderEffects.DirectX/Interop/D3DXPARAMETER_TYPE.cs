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

namespace WpfShaderEffects.DirectX.Interop
{
   enum D3DXPARAMETER_TYPE
   {
      D3DXPT_VOID,
      D3DXPT_BOOL,
      D3DXPT_INT,
      D3DXPT_FLOAT,
      D3DXPT_STRING,
      D3DXPT_TEXTURE,
      D3DXPT_TEXTURE1D,
      D3DXPT_TEXTURE2D,
      D3DXPT_TEXTURE3D,
      D3DXPT_TEXTURECUBE,
      D3DXPT_SAMPLER,
      D3DXPT_SAMPLER1D,
      D3DXPT_SAMPLER2D,
      D3DXPT_SAMPLER3D,
      D3DXPT_SAMPLERCUBE,
      D3DXPT_PIXELSHADER,
      D3DXPT_VERTEXSHADER,
      D3DXPT_PIXELFRAGMENT,
      D3DXPT_VERTEXFRAGMENT,
      D3DXPT_UNSUPPORTED,
   }
}