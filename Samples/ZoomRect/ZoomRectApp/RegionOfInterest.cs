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
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZoomRectApp
{
   [TemplatePart(Name = "PART_Content", Type = typeof(ContentPresenter))]
   [TemplatePart(Name = "PART_ContentBrush", Type = typeof(VisualBrush))]
   [TemplatePart(Name = "PART_RoiText", Type = typeof(TextBlock))]
   [TemplatePart(Name = "PART_ShaderTarget", Type = typeof(FrameworkElement))]
   public partial class RegionOfInterest : ContentControl
   {
      static RegionOfInterest()
      {
         DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RegionOfInterest), 
            new FrameworkPropertyMetadata(typeof(RegionOfInterest)));
      }


      VisualBrush m_contentBrush;
      TextBlock m_roiText;
      FrameworkElement m_shaderTarget;

      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         m_contentBrush = (VisualBrush)GetTemplateChild("PART_ContentBrush");
         m_roiText = (TextBlock)GetTemplateChild("PART_RoiText");
         m_shaderTarget = (FrameworkElement) GetTemplateChild("PART_ShaderTarget");

         AddAllCommands(CommandBindings);

         SetViewBox();
         SetZoom();
         SetShader();
      }

      protected override void OnMouseWheel(System.Windows.Input.MouseWheelEventArgs e)
      {
         var pow = e.Delta / 40.0;
         RoiZoom *= (decimal)Math.Pow((double)RoiZoomFactor, pow);
         base.OnMouseWheel(e);
      }

      partial void OnCanExecuteZoomOut(ref bool isExecutable, ref bool isProcessed)
      {
         isExecutable = RoiZoom > 1.0M;
         isProcessed = true;
      }

      partial void OnZoomOutExecuted(ref bool isProcessed)
      {
         RoiZoom /= RoiZoomFactor;
         isProcessed = true;
      }

      partial void OnCanExecuteZoomIn(ref bool isExecutable, ref bool isProcessed)
      {
         isExecutable = RoiZoom < 32M;
         isProcessed = true;
      }

      partial void OnZoomInExecuted(ref bool isProcessed)
      {
         RoiZoom *= RoiZoomFactor;
         isProcessed = true;
      }

      partial void OnCanExecuteGrowRoi(ref bool isExecutable, ref bool isProcessed)
      {
         isExecutable = RoiWidth < ActualWidth && RoiHeight < ActualHeight;
         isProcessed = true;
      }

      partial void OnGrowRoiExecuted(ref bool isProcessed)
      {
         AdjustBox((double)RoiZoomFactor);
         isProcessed = true;
      }

      partial void OnCanExecuteShrinkRoi(ref bool isExecutable, ref bool isProcessed)
      {
         isExecutable = RoiWidth > 250 && RoiHeight > 120;
         isProcessed = true;
      }

      partial void OnShrinkRoiExecuted(ref bool isProcessed)
      {
         AdjustBox(1.0 / (double)RoiZoomFactor);
         isProcessed = true;
      }

      partial void OnCurrentShaderPropertyChanged(ShaderEffectInfo oldValue, ShaderEffectInfo newValue, ref bool isProcessed)
      {
         SetShader();
      }

      partial void OnRoiZoomCoerceValue(decimal baseValue, ref decimal newValue, ref bool isProcessed)
      {
         newValue = Math.Min(Math.Max(baseValue, 1.0M), 32M);
         isProcessed = true;
      }

      partial void OnRoiZoomPropertyChanged(decimal oldValue, decimal newValue, ref bool isProcessed)
      {
         SetZoom();
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
         RoiCenterX = (RoiX1 + newValue) / 2.0;
         CoerceValue(RoiLeftProperty);
         CoerceValue(RoiRightProperty);
         CoerceValue(RoiWidthProperty);
         SetViewBox();
      }

      partial void OnRoiY0PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterY = (RoiY1 + newValue) / 2.0;
         CoerceValue(RoiTopProperty);
         CoerceValue(RoiBottomProperty);
         CoerceValue(RoiHeightProperty);
         SetViewBox();
      }

      partial void OnRoiX1PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterX = (RoiX0 + newValue) / 2.0;
         CoerceValue(RoiLeftProperty);
         CoerceValue(RoiRightProperty);
         CoerceValue(RoiWidthProperty);
         SetViewBox();
      }

      partial void OnRoiY1PropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         RoiCenterY = (RoiY0 + newValue) / 2.0;
         CoerceValue(RoiTopProperty);
         CoerceValue(RoiBottomProperty);
         CoerceValue(RoiHeightProperty);
         SetViewBox();
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


      void SetShader()
      {
         if (m_shaderTarget != null)
         {
            m_shaderTarget.Effect = 
               CurrentShader != null
               ? CurrentShader.ShaderEffect
               :  null;
         }
      }

      void SetZoom()
      {
         var zoom  = (double)RoiZoom;
         if (m_contentBrush != null)
         {
            m_contentBrush.RelativeTransform =
               new ScaleTransform(zoom, zoom)
                  {
                     CenterX = 0.5,
                     CenterY = 0.5,
                  };
         }

         if (m_roiText != null)
         {
            m_roiText.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}x", RoiZoom);
         }
      }

      void SetViewBox()
      {
         if (m_contentBrush != null)
         {
            m_contentBrush.Viewbox =
               new Rect
                  {
                     X = RoiLeft,
                     Y = RoiTop,
                     Width = RoiWidth,
                     Height = RoiHeight,
                  };
         }
      }

      static double NegateIfFalse(bool condition, double value)
      {
         return condition ? value : -value;
      }

      void AdjustBox(double factor)
      {
         var width = RoiWidth;
         var height = RoiHeight;

         var newWidth = width * factor;
         var newHeight = height * factor;

         var diffX = NegateIfFalse(RoiX0 < RoiX1, (newWidth - width) / 2);
         var diffY = NegateIfFalse(RoiY0 < RoiY1, (newHeight - height) / 2);

         RoiX1 += diffX;
         RoiX0 -= diffX;

         RoiY1 += diffY;
         RoiY0 -= diffY;

      }
   }
}
