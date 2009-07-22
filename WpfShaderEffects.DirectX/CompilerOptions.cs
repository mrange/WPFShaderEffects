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
using WpfShaderEffects.DirectX.Interop;

namespace WpfShaderEffects.DirectX
{
   [Flags]
   enum CompilerOptions
   {
      None = D3DXSHADER.NONE,
      Debug = D3DXSHADER.DEBUG,
      SkipValidation = D3DXSHADER.SKIPVALIDATION,
      SkipOptimization = D3DXSHADER.SKIPOPTIMIZATION,
      PackMatrixRowMajor = D3DXSHADER.PACKMATRIX_ROWMAJOR,
      PackMatrixColumnMajor = D3DXSHADER.PACKMATRIX_COLUMNMAJOR,
      PartialPrecision = D3DXSHADER.PARTIALPRECISION,
      ForceVertexShaderSoftwareNoOptimizations =
         D3DXSHADER.FORCE_VS_SOFTWARE_NOOPT,
      ForcePixelShaderSoftwareNoOptimizations =
         D3DXSHADER.FORCE_PS_SOFTWARE_NOOPT,
      NoPreShader = D3DXSHADER.NO_PRESHADER,
      AvoidFlowControl = D3DXSHADER.AVOID_FLOW_CONTROL,
      PreferFlowControl = D3DXSHADER.PREFER_FLOW_CONTROL,
      [Obsolete] NotCloneable = 0x800,
      EnableBackwardsCompatibility = D3DXSHADER.ENABLE_BACKWARDS_COMPATIBILITY,
      IeeeStrictness = D3DXSHADER.IEEE_STRICTNESS,
      UseLegacyD3Dx931Dll = D3DXSHADER.USE_LEGACY_D3DX9_31_DLL,
      OptimizationLevel0 = D3DXSHADER.OPTIMIZATION_LEVEL0,
      OptimizationLevel1 = D3DXSHADER.OPTIMIZATION_LEVEL1,
      OptimizationLevel2 = D3DXSHADER.OPTIMIZATION_LEVEL2,
      OptimizationLevel3 = D3DXSHADER.OPTIMIZATION_LEVEL3,
   }
}