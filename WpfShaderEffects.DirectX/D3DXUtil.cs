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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace WpfShaderEffects.DirectX.Interop
{
   static class D3DXUtil
   {
      const int MaxD3DX9Version = 39; // DirectX SDK August 2008
      const int MinD3DX9Version = 32; // DirectX SDK December 2006

      public static UnmanagedLibrary LoadDirectX9()
      {
         for (var ver = MaxD3DX9Version; ver >= MinD3DX9Version; --ver)
         {
            var dllname = "d3dx9_" + Convert.ToString(ver) + ".dll";
            var handle = UnmanagedLibrary.LoadLibrary(
               dllname,
               false);
            if (handle != null)
            {
               return handle;
            }
         }
         throw new Exception("DX9 dll couldn't be located");
      }

      public static string ReadAsAnsiString(this IntPtr ptr)
      {
         return ptr == IntPtr.Zero
                   ? String.Empty
                   : Marshal.PtrToStringAnsi(ptr);
      }

      public static byte[] AsByteArray(this ID3DXBuffer buffer)
      {
         VerifyNonNullArgument(
            buffer,
            "buffer");
         var buf = new byte[(int) buffer.GetBufferSize()];
         Marshal.Copy(
            buffer.GetBufferPointer(),
            buf,
            0,
            (int) buffer.GetBufferSize());
         return buf;
      }

      public static string AsAnsiString(this ID3DXBuffer buffer)
      {
         VerifyNonNullArgument(
            buffer,
            "buffer");
         unsafe
         {
            var ptr = (sbyte*) buffer.GetBufferPointer();
            var size = (int) buffer.GetBufferSize();
            if (ptr[size - 1] == 0)
            {
               // skip the last null char
               size = Math.Max(
                  checked(size - 1),
                  0);
            }
            return new string(
               ptr,
               0,
               size);
         }
      }

      public static RegisterSet ToRegisterSet(this D3DXREGISTER_SET src)
      {
         return (RegisterSet) src;
      }

      public static D3DXREGISTER_SET ToD3DXREGISTER_SET(this RegisterSet src)
      {
         return (D3DXREGISTER_SET) src;
      }

      public static ParameterClass ToParameterClass(
         this D3DXPARAMETER_CLASS src)
      {
         return (ParameterClass) src;
      }

      public static D3DXPARAMETER_CLASS ToD3DXPARAMETER_CLASS(
         this ParameterClass src)
      {
         return (D3DXPARAMETER_CLASS) src;
      }

      public static ParameterType ToParameterType(this D3DXPARAMETER_TYPE src)
      {
         return (ParameterType) src;
      }

      public static D3DXPARAMETER_TYPE ToD3DXPARAMETER_TYPE(
         this ParameterType src)
      {
         return (D3DXPARAMETER_TYPE) src;
      }

      public static ParameterFlags ToParameterFlags(this D3DX_PARAMETER src)
      {
         return (ParameterFlags) src;
      }

      public static D3DX_PARAMETER ToD3DX_PARAMETER(this ParameterFlags src)
      {
         return (D3DX_PARAMETER) src;
      }

      public static CompilerOptions ToCompilerOptions(this D3DXSHADER option)
      {
         return (CompilerOptions) option;
      }

      public static D3DXSHADER ToD3DXSHADER(this CompilerOptions option)
      {
         return (D3DXSHADER) option;
      }

      public static ConstantInfo ToConstantInfo(this D3DXCONSTANT_DESC desc)
      {
         var info = new ConstantInfo
                       {
                          Name = desc.Name.ReadAsAnsiString(),
                          RegisterSet = desc.RegisterSet.ToRegisterSet(),
                          RegisterIndex = (int) desc.RegisterIndex,
                          RegisterCount = (int) desc.RegisterCount,
                          Class = desc.Class.ToParameterClass(),
                          Type = desc.Type.ToParameterType(),
                          Rows = (int) desc.Rows,
                          Columns = (int) desc.Columns,
                          Elements = (int) desc.Elements,
                          StructMembers = (int) desc.StructMembers,
                          Bytes = (int) desc.Bytes,
                       };

         if (desc.DefaultValue != IntPtr.Zero)
         {
            info.DefaultValue = new byte[desc.Bytes];
            Marshal.Copy(
               desc.DefaultValue,
               info.DefaultValue,
               0,
               (int) desc.Bytes);
         }

         return info;
      }

      public static D3DXCONSTANTTABLE_DESC? GetDesc(
         this ID3DXConstantTable contantTable)
      {
         VerifyNonNullArgument(
            contantTable,
            "contantTable");

         var desc = default(D3DXCONSTANTTABLE_DESC);
         return Succeeded(contantTable.GetDesc(out desc))
                   ? (D3DXCONSTANTTABLE_DESC?) desc
                   : null;
      }

      public static IEnumerable<IntPtr> GetTopLevelConstantHandles(
         this ID3DXConstantTable contantTable)
      {
         VerifyNonNullArgument(
            contantTable,
            "contantTable");

         var desc_ = contantTable.GetDesc();
         if (!desc_.HasValue)
         {
            return Enumerable.Empty<IntPtr>();
         }
         var desc = desc_.Value;
         return Enumerable.Range(
            0,
            (int) desc.Constants)
            .Select(
            index => contantTable.GetConstant(
                        IntPtr.Zero,
                        (uint) index));
      }

      public static IEnumerable<D3DXCONSTANT_DESC> GetConstantDesc(
         this ID3DXConstantTable contantTable,
         IntPtr constantHandle)
      {
         VerifyNonNullArgument(
            contantTable,
            "contantTable");

         uint count = 0;
         if (Succeeded(
            contantTable.GetConstantDesc(
               constantHandle,
               null,
               ref count)))
         {
            var array = new D3DXCONSTANT_DESC[count];
            if (Succeeded(
               contantTable.GetConstantDesc(
                  constantHandle,
                  array,
                  ref count)))
            {
               return array.Take((int) count);
            }
         }
         return Enumerable.Empty<D3DXCONSTANT_DESC>();
      }

      public static ParameterInfo GetParameter(
         this ID3DXEffectCompiler compiler,
         IntPtr targetHandle,
         int paramIndex)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");

         var paramHandle = compiler.GetParameter(
            targetHandle,
            (uint) paramIndex);
         var paramDesc_ = compiler.GetParameterDesc(paramHandle);
         if (!paramDesc_.HasValue)
         {
            return null;
         }

         var paramDesc = paramDesc_.Value;
         var annotations =
            from annotationIndex in Enumerable.Range(
               0,
               (int) paramDesc.Annotations)
            let annotationHandle = compiler.GetAnnotation(
               paramHandle,
               (uint) annotationIndex)
            let annotation =
               annotationHandle == IntPtr.Zero
                  ? String.Empty
                  : Marshal.PtrToStringAnsi(annotationHandle)
            select annotation;

         return new ParameterInfo
                   {
                      Annotations = annotations.ToArray(),
                      Bytes = (int) paramDesc.Bytes,
                      Class = paramDesc.Class.ToParameterClass(),
                      Columns = (int) paramDesc.Columns,
                      Elements = (int) paramDesc.Elements,
                      Flags = paramDesc.Flags.ToParameterFlags(),
                      Name = paramDesc.Name.ReadAsAnsiString(),
                      Rows = (int) paramDesc.Rows,
                      Semantic = paramDesc.Semantic.ReadAsAnsiString(),
                      StructMembers = (int) paramDesc.StructMembers,
                      Type = paramDesc.Type.ToParameterType(),
                   };
      }

      public static CompiledShader CompileShader(
         this ID3DXEffectCompiler compiler,
         string function,
         string profile,
         CompilerOptions option)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");
         return CompileShader(
            compiler as ID3DXEffectCompilerCustom,
            function,
            profile,
            option);
      }

      public static CompiledShader CompileShader(
         this ID3DXEffectCompilerCustom compiler,
         string function,
         string profile,
         CompilerOptions option)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");

         var buffer = default(ID3DXBuffer);
         var msg = default(ID3DXBuffer);
         var constantTable = default(ID3DXConstantTable);

         try
         {
            var ret = new CompiledShader();
            if (
               Succeeded(
                  compiler.CompileShader(
                     function,
                     profile,
                     option.ToD3DXSHADER(),
                     out buffer,
                     out msg,
                     out constantTable)))
            {
               var constantDesc = constantTable.GetDesc();
               if (constantDesc.HasValue)
               {
                  var constantsList =
                     from handle in constantTable.GetTopLevelConstantHandles()
                     let constatns =
                        from desc in constantTable.GetConstantDesc(handle)
                        select desc.ToConstantInfo()
                     select constatns.ToArray();
                  ret.TopLevelConstants = constantsList.ToArray();
                  ret.ConstantTableCreator =
                     constantDesc.Value.Creator.ReadAsAnsiString();
                  ret.ConstantTableVersion = (int) constantDesc.Value.Version;
               }
               ret.Data = buffer.AsByteArray();
            }
            ret.ErrorMessage = msg != null ? msg.AsAnsiString() : String.Empty;

            return ret;
         }
         finally
         {
            if (buffer != null)
            {
               Marshal.ReleaseComObject(buffer);
               buffer = null;
            }
            if (msg != null)
            {
               Marshal.ReleaseComObject(msg);
               msg = null;
            }
            if (constantTable != null)
            {
               Marshal.ReleaseComObject(constantTable);
               constantTable = null;
            }
         }
      }

      public static D3DXEFFECT_DESC? GetDesc(this ID3DXEffectCompiler compiler)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");

         var desc = default(D3DXEFFECT_DESC);
         return Succeeded(compiler.GetDesc(out desc))
                   ? (D3DXEFFECT_DESC?) desc
                   : null;
      }

      public static D3DXFUNCTION_DESC? GetFunctionDesc(
         this ID3DXEffectCompiler compiler,
         IntPtr functionHandle)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");

         var desc = default(D3DXFUNCTION_DESC);
         return Succeeded(
                   compiler.GetFunctionDesc(
                      functionHandle,
                      out desc))
                   ? (D3DXFUNCTION_DESC?) desc
                   : null;
      }

      public static D3DXPARAMETER_DESC? GetParameterDesc(
         this ID3DXEffectCompiler compiler,
         IntPtr parameterHandle)
      {
         VerifyNonNullArgument(
            compiler,
            "compiler");

         var desc = default(D3DXPARAMETER_DESC);
         return Succeeded(
                   compiler.GetParameterDesc(
                      parameterHandle,
                      out desc))
                   ? (D3DXPARAMETER_DESC?) desc
                   : null;
      }

      [DebuggerStepThrough]
      public static void VerifyNonNullArgument<T>(
         T argument,
         string argumentName)
         where T : class
      {
         if (argument == null) throw new ArgumentNullException(argumentName);
      }

      [DebuggerStepThrough]
      public static bool Succeeded(Int32 hr)
      {
         return hr >= 0;
      }
   }
}