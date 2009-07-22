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
   public class EffectCompiler : IDisposable
   {
      readonly UnmanagedLibrary m_dx9Handle = D3DXUtil.LoadDirectX9();

      public byte[] CompilePixelShader(
         string source)
      {
         var effect = CompiledEffect.FromString(
            m_dx9Handle,
            source,
            CompilerOptions.None);

         if (effect.CompileSucceeded)
         {
            var shader = effect.CompileShader(
               "main",
               "ps_2_0",
               CompilerOptions.None);

            if (shader.CompileSucceeded)
            {
               return shader.Data;
            }
            else
            {
               throw new ArgumentException(
                  "COMPILE FAILED " + shader.ErrorMessage);
            }
         }
         else
         {
            throw new ArgumentException("PARSE FAILED " + effect.ErrorMessage);
         }

      }

      public void Dispose()
      {
         m_dx9Handle.Dispose();
      }
   }
}
