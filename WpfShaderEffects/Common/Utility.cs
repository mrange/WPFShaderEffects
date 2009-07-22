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

using System.IO;
using System.Reflection;
using System.Windows.Media.Effects;

namespace WpfShaderEffects.Common
{
   static class Utility
   {
      public static PixelShader CreatePixelShader<T>()
      {
         var stream = GetShaderBinary<T>();
         var pixelShader = new PixelShader();
         pixelShader.SetStreamSource(stream);
         return pixelShader;
      }

      public static Stream GetShaderBinary<T>()
      {
         var type = typeof (T);
         var fullName = type.Name;
         var name = fullName.Substring(0, fullName.Length - "ShaderEffect".Length);
         return Assembly.GetExecutingAssembly().GetManifestResourceStream(
            type,
            string.Format(
               @"ShaderBinary.{0}.fx.ps",
               name));
      }

   }
}
