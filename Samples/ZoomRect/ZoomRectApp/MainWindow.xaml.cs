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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using WpfShaderEffects;

namespace WpfApplication4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
	   decimal m_zoom = 1;
	   double m_zoomd = 1;

	   const decimal ZoomFactor = 1.2M;

      partial void OnCurrentShaderPropertyChanged(ShaderEffectInfo oldValue, ShaderEffectInfo newValue, ref bool isProcessed)
      {
         ContentRect.Effect = newValue.ShaderEffect;
      }

      partial void OnRoiCenterXPropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         var centerX = (RoiX0 + RoiX1) / 2;
         RoiX0 += newValue - centerX;
         RoiX1 += newValue - centerX;
      }

      partial void OnRoiCenterYPropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         var centerY = (RoiY0 + RoiY1) / 2;
         RoiY0 += newValue - centerY;
         RoiY1 += newValue - centerY;
      }

	   partial void OnRoiX0PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
	      RoiCenterX = (RoiX1 + newValue)/2.0;
         CoerceValue(RoiLeftProperty);
         CoerceValue(RoiRightProperty);
         CoerceValue(RoiWidthProperty);
	      SetTranslate();
      }

      partial void OnRoiY0PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterY = (RoiY1 + newValue) / 2.0;
         CoerceValue(RoiTopProperty);
         CoerceValue(RoiBottomProperty);
         CoerceValue(RoiHeightProperty);
         SetTranslate();
      }

      partial void OnRoiX1PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterX = (RoiX0 + newValue) / 2.0;
         CoerceValue(RoiLeftProperty);
         CoerceValue(RoiRightProperty);
         CoerceValue(RoiWidthProperty);
         SetTranslate();
      }

      partial void OnRoiY1PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterY = (RoiY0 + newValue) / 2.0;
         CoerceValue(RoiTopProperty);
         CoerceValue(RoiBottomProperty);
         CoerceValue(RoiHeightProperty);
         SetTranslate();
      }

      partial void OnRoiLeftCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Min(RoiX0, RoiX1);
         isProcessed = true;
      }

      partial void OnRoiRightCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Max(RoiX0, RoiX1);
         isProcessed = true;
      }

      partial void OnRoiTopCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Min(RoiY0, RoiY1);
         isProcessed = true;
      }

      partial void OnRoiBottomCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Max(RoiY0, RoiY1);
         isProcessed = true;
      }

      partial void OnRoiWidthCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Max(RoiX1 - RoiX0, RoiX0 - RoiX1);
         isProcessed = true;
      }

      partial void OnRoiHeightCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Max(RoiY1 - RoiY0, RoiY0 - RoiY1);
         isProcessed = true;
      }

      public MainWindow()
      {
         InitializeComponent();

         Shaders = new ObservableCollection<ShaderEffectInfo>
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

         CurrentShader = Shaders[0];

         VB.AutoLayoutContent = false;
         VB.ViewboxUnits = BrushMappingMode.Absolute;

         RoiX0 = 100;
         RoiY0 = 100;
         RoiX1 = 400;
         RoiY1 = 300;
     }

      void ZoomInButtonClick(object sender, RoutedEventArgs e)
      {
         m_zoom = Math.Max(m_zoom * ZoomFactor, 1.0M);
         SetZoom();
      }

	   void ZoomOutButtonClick(object sender, RoutedEventArgs e)
	   {
         m_zoom = Math.Max(m_zoom / ZoomFactor, 1.0M);
         SetZoom();
	   }

      void SetZoom()
      {
         m_zoomd = (double)m_zoom;
         VB.RelativeTransform =
            new ScaleTransform(m_zoomd, m_zoomd)
               {
                  CenterX = 0.5,
                  CenterY = 0.5,
               };
         ZoomText.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}x", m_zoom);
      }
      void SetTranslate()
      {
         VB.Viewbox = new Rect
                          {
                             X = RoiLeft,
                             Y = RoiTop,
                             Width = RoiWidth,
                             Height = RoiHeight,
                          };

      }

      void AdjustBox(double factor)
      {
         var width = RoiWidth;
         var height = RoiHeight;

         var newWidth = width * factor;
         var newHeight = height * factor;

         var diffX = (newWidth - width) / 2;
         var diffY = (newHeight - height) / 2;

         if (RoiX0 < RoiX1)
         {
            RoiX1 += diffX;
            RoiX0 -= diffX;
         }
         else
         {
            RoiX1 -= diffX;
            RoiX0 += diffX;
         }

         if (RoiY0 < RoiY1)
         {
            RoiY1 += diffY;
            RoiY0 -= diffY;
         }
         else
         {
            RoiY1 -= diffY;
            RoiY0 += diffY;
         }


      }

	   void ShrinkButtonClick(object sender, RoutedEventArgs e)
      {
         if(RoiWidth > 250 && RoiHeight > 120)
         {
            AdjustBox(1.0 / (double)ZoomFactor);
         }
	   }

	   void GrowButtonClick(object sender, RoutedEventArgs e)
	   {
         AdjustBox((double)ZoomFactor);
      }
	}
}