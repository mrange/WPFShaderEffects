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

namespace WpfShaderEffects.DirectX.Interop
{
   [Flags]
   enum D3DXSHADER
   {
      NONE = 0,
      DEBUG = (1 << 0),
      SKIPVALIDATION = (1 << 1),
      SKIPOPTIMIZATION = (1 << 2),
      PACKMATRIX_ROWMAJOR = (1 << 3),
      PACKMATRIX_COLUMNMAJOR = (1 << 4),
      PARTIALPRECISION = (1 << 5),
      FORCE_VS_SOFTWARE_NOOPT = (1 << 6),
      FORCE_PS_SOFTWARE_NOOPT = (1 << 7),
      NO_PRESHADER = (1 << 8),
      AVOID_FLOW_CONTROL = (1 << 9),
      PREFER_FLOW_CONTROL = (1 << 10),
      ENABLE_BACKWARDS_COMPATIBILITY = (1 << 12),
      IEEE_STRICTNESS = (1 << 13),
      USE_LEGACY_D3DX9_31_DLL = (1 << 16),
      OPTIMIZATION_LEVEL0 = (1 << 14),
      OPTIMIZATION_LEVEL1 = 0,
      OPTIMIZATION_LEVEL2 = ((1 << 14) | (1 << 15)),
      OPTIMIZATION_LEVEL3 = (1 << 15),
   }
}