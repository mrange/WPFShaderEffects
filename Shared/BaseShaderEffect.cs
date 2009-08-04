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

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects
#endif
{
   public abstract partial class BaseShaderEffect : ShaderEffect
   {
      partial void OnConstruction(PixelShader pixelShader);

      protected BaseShaderEffect(PixelShader pixelShader)
      {
         PixelShader = pixelShader;
         OnConstruction(pixelShader);
      }

      protected const double Pi = System.Math.PI;

      protected static Point MakePoint(double x, double y)
      {
         return new Point(x, y);
      }

      protected static Color MakeColor(byte r, byte g, byte b)
      {
         return MakeColor(0xFF, r, g, b);
      }

      protected static Color MakeColor(byte alpha, byte r, byte g, byte b)
      {
         return Color.FromArgb(alpha, r, g, b);
      }

      protected static double Clamp(double value, double min, double max)
      {
         return System.Math.Min(max, System.Math.Max(min, value));
      }

      protected static Point Clamp(Point value, Point min, Point max)
      {
         return new Point(
            Clamp(value.X, min.X, max.X),
            Clamp(value.Y, min.Y, max.Y));
      }
   }
}
