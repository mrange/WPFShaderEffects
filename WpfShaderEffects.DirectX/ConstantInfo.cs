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

namespace WpfShaderEffects.DirectX
{
   sealed class ConstantInfo
   {
      public string Name { get; set; }
      public RegisterSet RegisterSet { get; set; }
      public int RegisterIndex { get; set; }
      public int RegisterCount { get; set; }

      public ParameterClass Class { get; set; }
      public ParameterType Type { get; set; }

      public int Rows { get; set; }
      public int Columns { get; set; }
      public int Elements { get; set; }
      public int StructMembers { get; set; }

      public int Bytes { get; set; }
      public byte[] DefaultValue { get; set; }
   }
}