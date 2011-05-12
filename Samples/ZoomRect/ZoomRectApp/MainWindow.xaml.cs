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

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using WpfShaderEffects;

namespace ZoomRectApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
      partial void OnConstruction()
      {
         InitializeComponent();

         Roi.Shaders = new ObservableCollection<ShaderEffectInfo>
                      {
                         new ShaderEffectInfo
                            {
                               Name = "None",
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Invert",
                               ShaderEffect = new InvertColorShaderEffect(),
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Toon",
                               ShaderEffect = new ToonShaderEffect
                                                  {
                                                     
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Sharpen",
                               ShaderEffect = new SharpenShaderEffect
                                                  {
                                                     
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Sobel",
                               ShaderEffect = new SobelShaderEffect
                                                  {
                                                     
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "MonoChrome",
                               ShaderEffect = new MonochromeShaderEffect
                                                  {
                                                     FilterColor = Colors.White,
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "ColorTone",
                               ShaderEffect = new ColorToneShaderEffect
                                                  {
                                                     DarkColor = Colors.Black,
                                                     LightColor = Colors.Yellow,
                                                     
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Pinch",
                               ShaderEffect = new PinchShaderEffect
                                                  {
                                                   Amount = 0.8,
                                                   Radius = 0.5,
                                                     
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Swirl",
                               ShaderEffect = new SwirlShaderEffect
                                                 {
                                                     AngleFrequency = new Point(1.2, 1.4),
                                                     SpiralStrength = 1,
                                                  },
                            },
                         new ShaderEffectInfo
                            {
                               Name = "Ripple",
                               ShaderEffect = new RippleShaderEffect
                                                  {
                                                     Frequency = 8,
                                                     Phase = 0.4,
                                                  },
                            },
                      };

         Roi.CurrentShader = Roi.Shaders[0];

         Roi.RoiX0 = 100;
         Roi.RoiY0 = 100;
         Roi.RoiX1 = 400;
         Roi.RoiY1 = 300;
     }
	}
}