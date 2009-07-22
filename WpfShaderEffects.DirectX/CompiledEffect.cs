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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WpfShaderEffects.DirectX.Interop;

namespace WpfShaderEffects.DirectX
{
   class CompiledEffect
   {
      const string EffectCompilerFuncName = "D3DXCreateEffectCompiler";
      public readonly CompilerOptions CompileFlags;
      public readonly bool CompileSucceeded;
      public readonly string Creator;
      public readonly string ErrorMessage;
      public readonly string[] Functions;
      readonly D3DXCreateEffectCompilerProc m_d3DXCreateEffectCompiler;
      readonly UnmanagedLibrary m_dx9Handle;
      public readonly string SourceCode;
      public readonly ParameterInfo[] TopLevelParameters;

      CompiledEffect(
         UnmanagedLibrary dx9Handle,
         string source,
         CompilerOptions options)
      {
         m_dx9Handle = dx9Handle;
         m_d3DXCreateEffectCompiler = m_dx9Handle
            .GetUnmanagedFunction<D3DXCreateEffectCompilerProc>(
            EffectCompilerFuncName);

         SourceCode = source;
         CompileFlags = options;
         CompileSucceeded = false;


         var errorbuf = default(ID3DXBuffer);
         var compiler = default(ID3DXEffectCompiler);
         try
         {
            var len = Encoding.ASCII.GetByteCount(SourceCode);

            var hr = m_d3DXCreateEffectCompiler(
               SourceCode,
               (uint) len,
               null,
               IntPtr.Zero,
               options.ToD3DXSHADER(),
               out compiler,
               out errorbuf);
            ErrorMessage = errorbuf != null
                              ? errorbuf.AsAnsiString()
                              : string.Empty;
            if (!D3DXUtil.Succeeded(hr))
            {
               return;
            }

            CompileSucceeded = true;

            var maybeEffectDesc = compiler.GetDesc();
            if (!maybeEffectDesc.HasValue)
            {
               return;
            }

            var effectDesc = maybeEffectDesc.Value;
            var dxEffectCompiler = compiler;
            var functions = from funcIndex in Enumerable.Range(
                               0,
                               (int) effectDesc.Functions)
                            let funcHandle =
                               dxEffectCompiler.GetFunction((uint) funcIndex)
                            let funcDesc =
                               dxEffectCompiler.GetFunctionDesc(funcHandle)
                            // funcDesc.Annotations are always empty, so we ignore them
                            select
                               funcDesc.HasValue
                                  ? funcDesc.Value.Name.ReadAsAnsiString()
                                  : string.Empty;

            var effectCompiler = compiler;

            var topLevelParams =
               from paramIndex in Enumerable.Range(
                  0,
                  (int) effectDesc.Parameters)
               select effectCompiler.GetParameter(
                  IntPtr.Zero,
                  paramIndex);

            Creator = effectDesc.Creator.ReadAsAnsiString();
            Functions = functions.ToArray();
            TopLevelParameters = topLevelParams.ToArray();

            return;
         }
         finally
         {
            if (errorbuf != null)
            {
               Marshal.ReleaseComObject(errorbuf);
            }
            if (compiler != null)
            {
               Marshal.ReleaseComObject(compiler);
            }
         }
      }

      public CompiledShader CompileShader(
         string funcname,
         string profile,
         CompilerOptions options)
      {
         var errorbuf = default(ID3DXBuffer);
         var compiler = default(ID3DXEffectCompiler);
         try
         {
            var len = Encoding.ASCII.GetByteCount(SourceCode);

            var hr = m_d3DXCreateEffectCompiler(
               SourceCode,
               (uint) len,
               null,
               IntPtr.Zero,
               options.ToD3DXSHADER(),
               out compiler,
               out errorbuf);
            if (!D3DXUtil.Succeeded(hr))
            {
               return new CompiledShader
                         {
                            ErrorMessage =
                               errorbuf != null
                                  ? errorbuf.AsAnsiString()
                                  : string.Empty
                         };
            }
            return compiler.CompileShader(
               funcname,
               profile,
               options);
         }
         finally
         {
            if (errorbuf != null)
            {
               Marshal.ReleaseComObject(errorbuf);
            }
            if (compiler != null)
            {
               Marshal.ReleaseComObject(compiler);
            }
         }
      }

      public static CompiledEffect FromString(
         UnmanagedLibrary dx9Handle,
         string source,
         CompilerOptions options)
      {
         return new CompiledEffect(
            dx9Handle,
            source,
            options);
      }

      #region Nested type: D3DXCreateEffectCompilerProc

      [UnmanagedFunctionPointer(CallingConvention.StdCall,
         CharSet = CharSet.Ansi)]
      delegate Int32 D3DXCreateEffectCompilerProc(
         [MarshalAs(UnmanagedType.LPStr)] string pSrcData,
         uint srcDataLen,
         [In] D3DXMACRO[] defines, // last element should be null+null
         IntPtr include,
         D3DXSHADER flags,
         out ID3DXEffectCompiler effectCompiler,
         out ID3DXBuffer parseErrors
         );

      #endregion
   }
}