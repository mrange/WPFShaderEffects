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
   sealed class CompiledShader
   {
      public bool CompileSucceeded
      {
         get { return Data != null; }
      }

      public int ConstantTableVersion { get; set; }
      public string ConstantTableCreator { get; set; }
      public byte[] Data { get; set; }
      public string ErrorMessage { get; set; }
      public ConstantInfo[][] TopLevelConstants { get; set; }
   }
}