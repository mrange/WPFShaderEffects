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
using System.Windows.Media.Effects;

namespace WpfShaderEffects.Common
{
   static class Utility
   {
      public static PixelShader CreatePixelShader<T>()
      {
         var pixelShader =
            new PixelShader
               {
                  UriSource = GetShaderUri<T>(),
               };
         return pixelShader;
      }

      public static Uri GetShaderUri<T>()
      {
         var type = typeof(T);
         var fullName = type.Name;
         var name = fullName.Substring(0, fullName.Length - "ShaderEffect".Length);

         return MakePackUri(string.Format(@"{0}.fx.ps", name));
      }

      public static Uri MakePackUri(string relativeFile)
      {
         var assembly = typeof (Utility).Assembly;

         // Extract the short name.
         var assemblyShortName = assembly.ToString().Split(',')[0];

         var uriString =
            string.Format(
               @"pack://application:,,,/{0};component/ShaderBinary/{1}",
               assemblyShortName,
               relativeFile);

         return new Uri(uriString);
      }

   }
}
