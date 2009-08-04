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
   public abstract partial class BaseSingleInputShaderEffect : BaseShaderEffect
   {
      partial void OnConstruction(PixelShader pixelShader);
      protected BaseSingleInputShaderEffect(PixelShader pixelShader) 
         : base(pixelShader)
      {
         UpdateShaderValue(InputProperty);
         OnConstruction(pixelShader);
      }

         
      public static readonly DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input",
            typeof(BaseSingleInputShaderEffect),
            0);

      public Brush Input
      {
         get
         {
            return (Brush)GetValue(InputProperty);
         }
         set
         {
            SetValue(InputProperty, value);
         }
      }

         
   }
   public abstract partial class BaseTwoInputsShaderEffect : BaseShaderEffect
   {
      partial void OnConstruction(PixelShader pixelShader);
      protected BaseTwoInputsShaderEffect(PixelShader pixelShader) 
         : base(pixelShader)
      {
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(SecondInputProperty);
         OnConstruction(pixelShader);
      }

         
      public static readonly DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input",
            typeof(BaseTwoInputsShaderEffect),
            0);

      public Brush Input
      {
         get
         {
            return (Brush)GetValue(InputProperty);
         }
         set
         {
            SetValue(InputProperty, value);
         }
      }

         
      public static readonly DependencyProperty SecondInputProperty =
         RegisterPixelShaderSamplerProperty(
            "SecondInput",
            typeof(BaseTwoInputsShaderEffect),
            1);

      public Brush SecondInput
      {
         get
         {
            return (Brush)GetValue(SecondInputProperty);
         }
         set
         {
            SetValue(SecondInputProperty, value);
         }
      }

         
   }
   public abstract partial class BaseThreeInputsShaderEffect : BaseShaderEffect
   {
      partial void OnConstruction(PixelShader pixelShader);
      protected BaseThreeInputsShaderEffect(PixelShader pixelShader) 
         : base(pixelShader)
      {
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(SecondInputProperty);
         UpdateShaderValue(ThirdInputProperty);
         OnConstruction(pixelShader);
      }

         
      public static readonly DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input",
            typeof(BaseThreeInputsShaderEffect),
            0);

      public Brush Input
      {
         get
         {
            return (Brush)GetValue(InputProperty);
         }
         set
         {
            SetValue(InputProperty, value);
         }
      }

         
      public static readonly DependencyProperty SecondInputProperty =
         RegisterPixelShaderSamplerProperty(
            "SecondInput",
            typeof(BaseThreeInputsShaderEffect),
            1);

      public Brush SecondInput
      {
         get
         {
            return (Brush)GetValue(SecondInputProperty);
         }
         set
         {
            SetValue(SecondInputProperty, value);
         }
      }

         
      public static readonly DependencyProperty ThirdInputProperty =
         RegisterPixelShaderSamplerProperty(
            "ThirdInput",
            typeof(BaseThreeInputsShaderEffect),
            2);

      public Brush ThirdInput
      {
         get
         {
            return (Brush)GetValue(ThirdInputProperty);
         }
         set
         {
            SetValue(ThirdInputProperty, value);
         }
      }

         
   }
   public abstract partial class BaseFourInputsShaderEffect : BaseShaderEffect
   {
      partial void OnConstruction(PixelShader pixelShader);
      protected BaseFourInputsShaderEffect(PixelShader pixelShader) 
         : base(pixelShader)
      {
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(SecondInputProperty);
         UpdateShaderValue(ThirdInputProperty);
         UpdateShaderValue(FourthInputProperty);
         OnConstruction(pixelShader);
      }

         
      public static readonly DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input",
            typeof(BaseFourInputsShaderEffect),
            0);

      public Brush Input
      {
         get
         {
            return (Brush)GetValue(InputProperty);
         }
         set
         {
            SetValue(InputProperty, value);
         }
      }

         
      public static readonly DependencyProperty SecondInputProperty =
         RegisterPixelShaderSamplerProperty(
            "SecondInput",
            typeof(BaseFourInputsShaderEffect),
            1);

      public Brush SecondInput
      {
         get
         {
            return (Brush)GetValue(SecondInputProperty);
         }
         set
         {
            SetValue(SecondInputProperty, value);
         }
      }

         
      public static readonly DependencyProperty ThirdInputProperty =
         RegisterPixelShaderSamplerProperty(
            "ThirdInput",
            typeof(BaseFourInputsShaderEffect),
            2);

      public Brush ThirdInput
      {
         get
         {
            return (Brush)GetValue(ThirdInputProperty);
         }
         set
         {
            SetValue(ThirdInputProperty, value);
         }
      }

         
      public static readonly DependencyProperty FourthInputProperty =
         RegisterPixelShaderSamplerProperty(
            "FourthInput",
            typeof(BaseFourInputsShaderEffect),
            3);

      public Brush FourthInput
      {
         get
         {
            return (Brush)GetValue(FourthInputProperty);
         }
         set
         {
            SetValue(FourthInputProperty, value);
         }
      }

         
   }
      
}