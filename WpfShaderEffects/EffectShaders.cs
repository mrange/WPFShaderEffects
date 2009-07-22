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


namespace WpfShaderEffects
{
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\BandedSwirl.fx.ps
   
   /// <summary>
   /// BandedSwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BandedSwirl.fx
   /// </summary>
   public sealed partial class BandedSwirlShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<BandedSwirlShaderEffect>();
   
      public BandedSwirlShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(DistanceThresholdProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(BandedSwirlShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(System.Windows.Point),
         typeof(BandedSwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Center
      {
         get
         {
            return (System.Windows.Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY SpiralStrength
      public static System.Windows.DependencyProperty SpiralStrengthProperty = System.Windows.DependencyProperty.Register(
         @"SpiralStrength",
         typeof(double),
         typeof(BandedSwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnSpiralStrengthCoerceValueStatic));

      partial void OnSpiralStrengthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnSpiralStrengthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnSpiralStrengthCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property SpiralStrength (double)
      /// </summary>
      public double SpiralStrength
      {
         get
         {
            return (double)GetValue(SpiralStrengthProperty);
         }
         set
         {
            SetValue(SpiralStrengthProperty, value);
         }
      }

      // END_PROPERTY SpiralStrength
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY DistanceThreshold
      public static System.Windows.DependencyProperty DistanceThresholdProperty = System.Windows.DependencyProperty.Register(
         @"DistanceThreshold",
         typeof(double),
         typeof(BandedSwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnDistanceThresholdCoerceValueStatic));

      partial void OnDistanceThresholdCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnDistanceThresholdCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDistanceThresholdCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property DistanceThreshold (double)
      /// </summary>
      public double DistanceThreshold
      {
         get
         {
            return (double)GetValue(DistanceThresholdProperty);
         }
         set
         {
            SetValue(DistanceThresholdProperty, value);
         }
      }

      // END_PROPERTY DistanceThreshold
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Bloom.fx.ps
   
   /// <summary>
   /// BloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Bloom.fx
   /// </summary>
   public sealed partial class BloomShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<BloomShaderEffect>();
   
      public BloomShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(BloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(BloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(BloomShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BloomIntensity
      public static System.Windows.DependencyProperty BloomIntensityProperty = System.Windows.DependencyProperty.Register(
         @"BloomIntensity",
         typeof(double),
         typeof(BloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnBloomIntensityCoerceValueStatic));

      partial void OnBloomIntensityCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBloomIntensityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBloomIntensityCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BloomIntensity (double)
      /// </summary>
      public double BloomIntensity
      {
         get
         {
            return (double)GetValue(BloomIntensityProperty);
         }
         set
         {
            SetValue(BloomIntensityProperty, value);
         }
      }

      // END_PROPERTY BloomIntensity
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BaseIntensity
      public static System.Windows.DependencyProperty BaseIntensityProperty = System.Windows.DependencyProperty.Register(
         @"BaseIntensity",
         typeof(double),
         typeof(BloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnBaseIntensityCoerceValueStatic));

      partial void OnBaseIntensityCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBaseIntensityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseIntensityCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BaseIntensity (double)
      /// </summary>
      public double BaseIntensity
      {
         get
         {
            return (double)GetValue(BaseIntensityProperty);
         }
         set
         {
            SetValue(BaseIntensityProperty, value);
         }
      }

      // END_PROPERTY BaseIntensity
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BloomSaturation
      public static System.Windows.DependencyProperty BloomSaturationProperty = System.Windows.DependencyProperty.Register(
         @"BloomSaturation",
         typeof(double),
         typeof(BloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnBloomSaturationCoerceValueStatic));

      partial void OnBloomSaturationCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBloomSaturationCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBloomSaturationCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BloomSaturation (double)
      /// </summary>
      public double BloomSaturation
      {
         get
         {
            return (double)GetValue(BloomSaturationProperty);
         }
         set
         {
            SetValue(BloomSaturationProperty, value);
         }
      }

      // END_PROPERTY BloomSaturation
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BaseSaturation
      public static System.Windows.DependencyProperty BaseSaturationProperty = System.Windows.DependencyProperty.Register(
         @"BaseSaturation",
         typeof(double),
         typeof(BloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(3),
            OnBaseSaturationCoerceValueStatic));

      partial void OnBaseSaturationCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBaseSaturationCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseSaturationCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BaseSaturation (double)
      /// </summary>
      public double BaseSaturation
      {
         get
         {
            return (double)GetValue(BaseSaturationProperty);
         }
         set
         {
            SetValue(BaseSaturationProperty, value);
         }
      }

      // END_PROPERTY BaseSaturation
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\BrightExtract.fx.ps
   
   /// <summary>
   /// BrightExtractShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BrightExtract.fx
   /// </summary>
   public sealed partial class BrightExtractShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<BrightExtractShaderEffect>();
   
      public BrightExtractShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(ThresholdProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(BrightExtractShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Threshold
      public static System.Windows.DependencyProperty ThresholdProperty = System.Windows.DependencyProperty.Register(
         @"Threshold",
         typeof(double),
         typeof(BrightExtractShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnThresholdCoerceValueStatic));

      partial void OnThresholdCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnThresholdCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BrightExtractShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnThresholdCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Threshold (double)
      /// </summary>
      public double Threshold
      {
         get
         {
            return (double)GetValue(ThresholdProperty);
         }
         set
         {
            SetValue(ThresholdProperty, value);
         }
      }

      // END_PROPERTY Threshold
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ColorKeyAlpha.fx.ps
   
   /// <summary>
   /// ColorKeyAlphaShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorKeyAlpha.fx
   /// </summary>
   public sealed partial class ColorKeyAlphaShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ColorKeyAlphaShaderEffect>();
   
      public ColorKeyAlphaShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ColorKeyAlphaShaderEffect), 
            0);
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ColorTone.fx.ps
   
   /// <summary>
   /// ColorToneShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorTone.fx
   /// </summary>
   public sealed partial class ColorToneShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ColorToneShaderEffect>();
   
      public ColorToneShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(DesaturationProperty);
         UpdateShaderValue(TonedProperty);
         UpdateShaderValue(LightColorProperty);
         UpdateShaderValue(DarkColorProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ColorToneShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Desaturation
      public static System.Windows.DependencyProperty DesaturationProperty = System.Windows.DependencyProperty.Register(
         @"Desaturation",
         typeof(double),
         typeof(ColorToneShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnDesaturationCoerceValueStatic));

      partial void OnDesaturationCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnDesaturationCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDesaturationCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Desaturation (double)
      /// </summary>
      public double Desaturation
      {
         get
         {
            return (double)GetValue(DesaturationProperty);
         }
         set
         {
            SetValue(DesaturationProperty, value);
         }
      }

      // END_PROPERTY Desaturation
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Toned
      public static System.Windows.DependencyProperty TonedProperty = System.Windows.DependencyProperty.Register(
         @"Toned",
         typeof(double),
         typeof(ColorToneShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnTonedCoerceValueStatic));

      partial void OnTonedCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnTonedCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnTonedCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Toned (double)
      /// </summary>
      public double Toned
      {
         get
         {
            return (double)GetValue(TonedProperty);
         }
         set
         {
            SetValue(TonedProperty, value);
         }
      }

      // END_PROPERTY Toned
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY LightColor
      public static System.Windows.DependencyProperty LightColorProperty = System.Windows.DependencyProperty.Register(
         @"LightColor",
         typeof(System.Windows.Media.Color),
         typeof(ColorToneShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Color), 
            PixelShaderConstantCallback(2),
            OnLightColorCoerceValueStatic));

      partial void OnLightColorCoerceValue(
         System.Windows.Media.Color baseValue,
         ref System.Windows.Media.Color newValue,
         ref bool isProcessed
         );

      static object OnLightColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Media.Color)baseValue;
            var newValue = default(System.Windows.Media.Color);
            var isProcessed = false;
            inst.OnLightColorCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property LightColor (System.Windows.Media.Color)
      /// </summary>
      public System.Windows.Media.Color LightColor
      {
         get
         {
            return (System.Windows.Media.Color)GetValue(LightColorProperty);
         }
         set
         {
            SetValue(LightColorProperty, value);
         }
      }

      // END_PROPERTY LightColor
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY DarkColor
      public static System.Windows.DependencyProperty DarkColorProperty = System.Windows.DependencyProperty.Register(
         @"DarkColor",
         typeof(System.Windows.Media.Color),
         typeof(ColorToneShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Color), 
            PixelShaderConstantCallback(3),
            OnDarkColorCoerceValueStatic));

      partial void OnDarkColorCoerceValue(
         System.Windows.Media.Color baseValue,
         ref System.Windows.Media.Color newValue,
         ref bool isProcessed
         );

      static object OnDarkColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Media.Color)baseValue;
            var newValue = default(System.Windows.Media.Color);
            var isProcessed = false;
            inst.OnDarkColorCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property DarkColor (System.Windows.Media.Color)
      /// </summary>
      public System.Windows.Media.Color DarkColor
      {
         get
         {
            return (System.Windows.Media.Color)GetValue(DarkColorProperty);
         }
         set
         {
            SetValue(DarkColorProperty, value);
         }
      }

      // END_PROPERTY DarkColor
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ContrastAdjust.fx.ps
   
   /// <summary>
   /// ContrastAdjustShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ContrastAdjust.fx
   /// </summary>
   public sealed partial class ContrastAdjustShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ContrastAdjustShaderEffect>();
   
      public ContrastAdjustShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(BrightnessProperty);
         UpdateShaderValue(ContrastProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ContrastAdjustShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Brightness
      public static System.Windows.DependencyProperty BrightnessProperty = System.Windows.DependencyProperty.Register(
         @"Brightness",
         typeof(double),
         typeof(ContrastAdjustShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnBrightnessCoerceValueStatic));

      partial void OnBrightnessCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBrightnessCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ContrastAdjustShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBrightnessCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Brightness (double)
      /// </summary>
      public double Brightness
      {
         get
         {
            return (double)GetValue(BrightnessProperty);
         }
         set
         {
            SetValue(BrightnessProperty, value);
         }
      }

      // END_PROPERTY Brightness
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Contrast
      public static System.Windows.DependencyProperty ContrastProperty = System.Windows.DependencyProperty.Register(
         @"Contrast",
         typeof(double),
         typeof(ContrastAdjustShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnContrastCoerceValueStatic));

      partial void OnContrastCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnContrastCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ContrastAdjustShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnContrastCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Contrast (double)
      /// </summary>
      public double Contrast
      {
         get
         {
            return (double)GetValue(ContrastProperty);
         }
         set
         {
            SetValue(ContrastProperty, value);
         }
      }

      // END_PROPERTY Contrast
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\DirectionalBlur.fx.ps
   
   /// <summary>
   /// DirectionalBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: DirectionalBlur.fx
   /// </summary>
   public sealed partial class DirectionalBlurShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<DirectionalBlurShaderEffect>();
   
      public DirectionalBlurShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(AngleProperty);
         UpdateShaderValue(BlurAmountProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(DirectionalBlurShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Angle
      public static System.Windows.DependencyProperty AngleProperty = System.Windows.DependencyProperty.Register(
         @"Angle",
         typeof(double),
         typeof(DirectionalBlurShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnAngleCoerceValueStatic));

      partial void OnAngleCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAngleCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (DirectionalBlurShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAngleCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Angle (double)
      /// </summary>
      public double Angle
      {
         get
         {
            return (double)GetValue(AngleProperty);
         }
         set
         {
            SetValue(AngleProperty, value);
         }
      }

      // END_PROPERTY Angle
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BlurAmount
      public static System.Windows.DependencyProperty BlurAmountProperty = System.Windows.DependencyProperty.Register(
         @"BlurAmount",
         typeof(double),
         typeof(DirectionalBlurShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnBlurAmountCoerceValueStatic));

      partial void OnBlurAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBlurAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (DirectionalBlurShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlurAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BlurAmount (double)
      /// </summary>
      public double BlurAmount
      {
         get
         {
            return (double)GetValue(BlurAmountProperty);
         }
         set
         {
            SetValue(BlurAmountProperty, value);
         }
      }

      // END_PROPERTY BlurAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Embossed.fx.ps
   
   /// <summary>
   /// EmbossedShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Embossed.fx
   /// </summary>
   public sealed partial class EmbossedShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<EmbossedShaderEffect>();
   
      public EmbossedShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(EmbossedShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(EmbossedShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnAmountCoerceValueStatic));

      partial void OnAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (EmbossedShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Amount (double)
      /// </summary>
      public double Amount
      {
         get
         {
            return (double)GetValue(AmountProperty);
         }
         set
         {
            SetValue(AmountProperty, value);
         }
      }

      // END_PROPERTY Amount
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Width
      public static System.Windows.DependencyProperty WidthProperty = System.Windows.DependencyProperty.Register(
         @"Width",
         typeof(double),
         typeof(EmbossedShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnWidthCoerceValueStatic));

      partial void OnWidthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnWidthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (EmbossedShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnWidthCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Width (double)
      /// </summary>
      public double Width
      {
         get
         {
            return (double)GetValue(WidthProperty);
         }
         set
         {
            SetValue(WidthProperty, value);
         }
      }

      // END_PROPERTY Width
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Gloom.fx.ps
   
   /// <summary>
   /// GloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Gloom.fx
   /// </summary>
   public sealed partial class GloomShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<GloomShaderEffect>();
   
      public GloomShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(GloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(GloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(GloomShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY GloomIntensity
      public static System.Windows.DependencyProperty GloomIntensityProperty = System.Windows.DependencyProperty.Register(
         @"GloomIntensity",
         typeof(double),
         typeof(GloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnGloomIntensityCoerceValueStatic));

      partial void OnGloomIntensityCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnGloomIntensityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGloomIntensityCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property GloomIntensity (double)
      /// </summary>
      public double GloomIntensity
      {
         get
         {
            return (double)GetValue(GloomIntensityProperty);
         }
         set
         {
            SetValue(GloomIntensityProperty, value);
         }
      }

      // END_PROPERTY GloomIntensity
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BaseIntensity
      public static System.Windows.DependencyProperty BaseIntensityProperty = System.Windows.DependencyProperty.Register(
         @"BaseIntensity",
         typeof(double),
         typeof(GloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnBaseIntensityCoerceValueStatic));

      partial void OnBaseIntensityCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBaseIntensityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseIntensityCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BaseIntensity (double)
      /// </summary>
      public double BaseIntensity
      {
         get
         {
            return (double)GetValue(BaseIntensityProperty);
         }
         set
         {
            SetValue(BaseIntensityProperty, value);
         }
      }

      // END_PROPERTY BaseIntensity
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY GloomSaturation
      public static System.Windows.DependencyProperty GloomSaturationProperty = System.Windows.DependencyProperty.Register(
         @"GloomSaturation",
         typeof(double),
         typeof(GloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnGloomSaturationCoerceValueStatic));

      partial void OnGloomSaturationCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnGloomSaturationCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGloomSaturationCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property GloomSaturation (double)
      /// </summary>
      public double GloomSaturation
      {
         get
         {
            return (double)GetValue(GloomSaturationProperty);
         }
         set
         {
            SetValue(GloomSaturationProperty, value);
         }
      }

      // END_PROPERTY GloomSaturation
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BaseSaturation
      public static System.Windows.DependencyProperty BaseSaturationProperty = System.Windows.DependencyProperty.Register(
         @"BaseSaturation",
         typeof(double),
         typeof(GloomShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(3),
            OnBaseSaturationCoerceValueStatic));

      partial void OnBaseSaturationCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBaseSaturationCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GloomShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseSaturationCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BaseSaturation (double)
      /// </summary>
      public double BaseSaturation
      {
         get
         {
            return (double)GetValue(BaseSaturationProperty);
         }
         set
         {
            SetValue(BaseSaturationProperty, value);
         }
      }

      // END_PROPERTY BaseSaturation
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\GrowablePoissonDisk.fx.ps
   
   /// <summary>
   /// GrowablePoissonDiskShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: GrowablePoissonDisk.fx
   /// </summary>
   public sealed partial class GrowablePoissonDiskShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<GrowablePoissonDiskShaderEffect>();
   
      public GrowablePoissonDiskShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(DiscRadiusProperty);
         UpdateShaderValue(WidthProperty);
         UpdateShaderValue(HeightProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(GrowablePoissonDiskShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY DiscRadius
      public static System.Windows.DependencyProperty DiscRadiusProperty = System.Windows.DependencyProperty.Register(
         @"DiscRadius",
         typeof(double),
         typeof(GrowablePoissonDiskShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnDiscRadiusCoerceValueStatic));

      partial void OnDiscRadiusCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnDiscRadiusCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GrowablePoissonDiskShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDiscRadiusCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property DiscRadius (double)
      /// </summary>
      public double DiscRadius
      {
         get
         {
            return (double)GetValue(DiscRadiusProperty);
         }
         set
         {
            SetValue(DiscRadiusProperty, value);
         }
      }

      // END_PROPERTY DiscRadius
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Width
      public static System.Windows.DependencyProperty WidthProperty = System.Windows.DependencyProperty.Register(
         @"Width",
         typeof(double),
         typeof(GrowablePoissonDiskShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnWidthCoerceValueStatic));

      partial void OnWidthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnWidthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GrowablePoissonDiskShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnWidthCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Width (double)
      /// </summary>
      public double Width
      {
         get
         {
            return (double)GetValue(WidthProperty);
         }
         set
         {
            SetValue(WidthProperty, value);
         }
      }

      // END_PROPERTY Width
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Height
      public static System.Windows.DependencyProperty HeightProperty = System.Windows.DependencyProperty.Register(
         @"Height",
         typeof(double),
         typeof(GrowablePoissonDiskShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnHeightCoerceValueStatic));

      partial void OnHeightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnHeightCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GrowablePoissonDiskShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnHeightCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Height (double)
      /// </summary>
      public double Height
      {
         get
         {
            return (double)GetValue(HeightProperty);
         }
         set
         {
            SetValue(HeightProperty, value);
         }
      }

      // END_PROPERTY Height
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\InvertColor.fx.ps
   
   /// <summary>
   /// InvertColorShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: InvertColor.fx
   /// </summary>
   public sealed partial class InvertColorShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<InvertColorShaderEffect>();
   
      public InvertColorShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(InvertColorShaderEffect), 
            0);
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\LightStreak.fx.ps
   
   /// <summary>
   /// LightStreakShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: LightStreak.fx
   /// </summary>
   public sealed partial class LightStreakShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<LightStreakShaderEffect>();
   
      public LightStreakShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(BrightThresholdProperty);
         UpdateShaderValue(ScaleProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(LightStreakShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BrightThreshold
      public static System.Windows.DependencyProperty BrightThresholdProperty = System.Windows.DependencyProperty.Register(
         @"BrightThreshold",
         typeof(double),
         typeof(LightStreakShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnBrightThresholdCoerceValueStatic));

      partial void OnBrightThresholdCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBrightThresholdCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LightStreakShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBrightThresholdCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BrightThreshold (double)
      /// </summary>
      public double BrightThreshold
      {
         get
         {
            return (double)GetValue(BrightThresholdProperty);
         }
         set
         {
            SetValue(BrightThresholdProperty, value);
         }
      }

      // END_PROPERTY BrightThreshold
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Scale
      public static System.Windows.DependencyProperty ScaleProperty = System.Windows.DependencyProperty.Register(
         @"Scale",
         typeof(double),
         typeof(LightStreakShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnScaleCoerceValueStatic));

      partial void OnScaleCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnScaleCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LightStreakShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnScaleCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Scale (double)
      /// </summary>
      public double Scale
      {
         get
         {
            return (double)GetValue(ScaleProperty);
         }
         set
         {
            SetValue(ScaleProperty, value);
         }
      }

      // END_PROPERTY Scale
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Magnify.fx.ps
   
   /// <summary>
   /// MagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Magnify.fx
   /// </summary>
   public sealed partial class MagnifyShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<MagnifyShaderEffect>();
   
      public MagnifyShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(RadiiProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmountProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(MagnifyShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Radii
      public static System.Windows.DependencyProperty RadiiProperty = System.Windows.DependencyProperty.Register(
         @"Radii",
         typeof(System.Windows.Point),
         typeof(MagnifyShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(0),
            OnRadiiCoerceValueStatic));

      partial void OnRadiiCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnRadiiCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MagnifyShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnRadiiCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Radii (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Radii
      {
         get
         {
            return (System.Windows.Point)GetValue(RadiiProperty);
         }
         set
         {
            SetValue(RadiiProperty, value);
         }
      }

      // END_PROPERTY Radii
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(System.Windows.Point),
         typeof(MagnifyShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(1),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MagnifyShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Center
      {
         get
         {
            return (System.Windows.Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(MagnifyShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnAmountCoerceValueStatic));

      partial void OnAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MagnifyShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Amount (double)
      /// </summary>
      public double Amount
      {
         get
         {
            return (double)GetValue(AmountProperty);
         }
         set
         {
            SetValue(AmountProperty, value);
         }
      }

      // END_PROPERTY Amount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Monochrome.fx.ps
   
   /// <summary>
   /// MonochromeShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Monochrome.fx
   /// </summary>
   public sealed partial class MonochromeShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<MonochromeShaderEffect>();
   
      public MonochromeShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(FilterColorProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(MonochromeShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY FilterColor
      public static System.Windows.DependencyProperty FilterColorProperty = System.Windows.DependencyProperty.Register(
         @"FilterColor",
         typeof(System.Windows.Media.Color),
         typeof(MonochromeShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Color), 
            PixelShaderConstantCallback(0),
            OnFilterColorCoerceValueStatic));

      partial void OnFilterColorCoerceValue(
         System.Windows.Media.Color baseValue,
         ref System.Windows.Media.Color newValue,
         ref bool isProcessed
         );

      static object OnFilterColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MonochromeShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Media.Color)baseValue;
            var newValue = default(System.Windows.Media.Color);
            var isProcessed = false;
            inst.OnFilterColorCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property FilterColor (System.Windows.Media.Color)
      /// </summary>
      public System.Windows.Media.Color FilterColor
      {
         get
         {
            return (System.Windows.Media.Color)GetValue(FilterColorProperty);
         }
         set
         {
            SetValue(FilterColorProperty, value);
         }
      }

      // END_PROPERTY FilterColor
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Pinch.fx.ps
   
   /// <summary>
   /// PinchShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pinch.fx
   /// </summary>
   public sealed partial class PinchShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<PinchShaderEffect>();
   
      public PinchShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterXProperty);
         UpdateShaderValue(CenterYProperty);
         UpdateShaderValue(RadiusProperty);
         UpdateShaderValue(AmountProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(PinchShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY CenterX
      public static System.Windows.DependencyProperty CenterXProperty = System.Windows.DependencyProperty.Register(
         @"CenterX",
         typeof(double),
         typeof(PinchShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnCenterXCoerceValueStatic));

      partial void OnCenterXCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnCenterXCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PinchShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnCenterXCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property CenterX (double)
      /// </summary>
      public double CenterX
      {
         get
         {
            return (double)GetValue(CenterXProperty);
         }
         set
         {
            SetValue(CenterXProperty, value);
         }
      }

      // END_PROPERTY CenterX
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY CenterY
      public static System.Windows.DependencyProperty CenterYProperty = System.Windows.DependencyProperty.Register(
         @"CenterY",
         typeof(double),
         typeof(PinchShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnCenterYCoerceValueStatic));

      partial void OnCenterYCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnCenterYCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PinchShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnCenterYCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property CenterY (double)
      /// </summary>
      public double CenterY
      {
         get
         {
            return (double)GetValue(CenterYProperty);
         }
         set
         {
            SetValue(CenterYProperty, value);
         }
      }

      // END_PROPERTY CenterY
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Radius
      public static System.Windows.DependencyProperty RadiusProperty = System.Windows.DependencyProperty.Register(
         @"Radius",
         typeof(double),
         typeof(PinchShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnRadiusCoerceValueStatic));

      partial void OnRadiusCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnRadiusCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PinchShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnRadiusCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Radius (double)
      /// </summary>
      public double Radius
      {
         get
         {
            return (double)GetValue(RadiusProperty);
         }
         set
         {
            SetValue(RadiusProperty, value);
         }
      }

      // END_PROPERTY Radius
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(PinchShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(3),
            OnAmountCoerceValueStatic));

      partial void OnAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PinchShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Amount (double)
      /// </summary>
      public double Amount
      {
         get
         {
            return (double)GetValue(AmountProperty);
         }
         set
         {
            SetValue(AmountProperty, value);
         }
      }

      // END_PROPERTY Amount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Pixelate.fx.ps
   
   /// <summary>
   /// PixelateShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pixelate.fx
   /// </summary>
   public sealed partial class PixelateShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<PixelateShaderEffect>();
   
      public PixelateShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(HorizontalPixelCountsProperty);
         UpdateShaderValue(VerticalPixelCountsProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(PixelateShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY HorizontalPixelCounts
      public static System.Windows.DependencyProperty HorizontalPixelCountsProperty = System.Windows.DependencyProperty.Register(
         @"HorizontalPixelCounts",
         typeof(double),
         typeof(PixelateShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnHorizontalPixelCountsCoerceValueStatic));

      partial void OnHorizontalPixelCountsCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnHorizontalPixelCountsCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnHorizontalPixelCountsCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property HorizontalPixelCounts (double)
      /// </summary>
      public double HorizontalPixelCounts
      {
         get
         {
            return (double)GetValue(HorizontalPixelCountsProperty);
         }
         set
         {
            SetValue(HorizontalPixelCountsProperty, value);
         }
      }

      // END_PROPERTY HorizontalPixelCounts
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY VerticalPixelCounts
      public static System.Windows.DependencyProperty VerticalPixelCountsProperty = System.Windows.DependencyProperty.Register(
         @"VerticalPixelCounts",
         typeof(double),
         typeof(PixelateShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnVerticalPixelCountsCoerceValueStatic));

      partial void OnVerticalPixelCountsCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnVerticalPixelCountsCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnVerticalPixelCountsCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property VerticalPixelCounts (double)
      /// </summary>
      public double VerticalPixelCounts
      {
         get
         {
            return (double)GetValue(VerticalPixelCountsProperty);
         }
         set
         {
            SetValue(VerticalPixelCountsProperty, value);
         }
      }

      // END_PROPERTY VerticalPixelCounts
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Ripple.fx.ps
   
   /// <summary>
   /// RippleShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Ripple.fx
   /// </summary>
   public sealed partial class RippleShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<RippleShaderEffect>();
   
      public RippleShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmplitudeProperty);
         UpdateShaderValue(FrequencyProperty);
         UpdateShaderValue(PhaseProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(RippleShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(System.Windows.Point),
         typeof(RippleShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Center
      {
         get
         {
            return (System.Windows.Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amplitude
      public static System.Windows.DependencyProperty AmplitudeProperty = System.Windows.DependencyProperty.Register(
         @"Amplitude",
         typeof(double),
         typeof(RippleShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnAmplitudeCoerceValueStatic));

      partial void OnAmplitudeCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAmplitudeCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmplitudeCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Amplitude (double)
      /// </summary>
      public double Amplitude
      {
         get
         {
            return (double)GetValue(AmplitudeProperty);
         }
         set
         {
            SetValue(AmplitudeProperty, value);
         }
      }

      // END_PROPERTY Amplitude
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Frequency
      public static System.Windows.DependencyProperty FrequencyProperty = System.Windows.DependencyProperty.Register(
         @"Frequency",
         typeof(double),
         typeof(RippleShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnFrequencyCoerceValueStatic));

      partial void OnFrequencyCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnFrequencyCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnFrequencyCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Frequency (double)
      /// </summary>
      public double Frequency
      {
         get
         {
            return (double)GetValue(FrequencyProperty);
         }
         set
         {
            SetValue(FrequencyProperty, value);
         }
      }

      // END_PROPERTY Frequency
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Phase
      public static System.Windows.DependencyProperty PhaseProperty = System.Windows.DependencyProperty.Register(
         @"Phase",
         typeof(double),
         typeof(RippleShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(3),
            OnPhaseCoerceValueStatic));

      partial void OnPhaseCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnPhaseCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnPhaseCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Phase (double)
      /// </summary>
      public double Phase
      {
         get
         {
            return (double)GetValue(PhaseProperty);
         }
         set
         {
            SetValue(PhaseProperty, value);
         }
      }

      // END_PROPERTY Phase
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Sharpen.fx.ps
   
   /// <summary>
   /// SharpenShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Sharpen.fx
   /// </summary>
   public sealed partial class SharpenShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<SharpenShaderEffect>();
   
      public SharpenShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(SharpenShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(SharpenShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnAmountCoerceValueStatic));

      partial void OnAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SharpenShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Amount (double)
      /// </summary>
      public double Amount
      {
         get
         {
            return (double)GetValue(AmountProperty);
         }
         set
         {
            SetValue(AmountProperty, value);
         }
      }

      // END_PROPERTY Amount
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Width
      public static System.Windows.DependencyProperty WidthProperty = System.Windows.DependencyProperty.Register(
         @"Width",
         typeof(double),
         typeof(SharpenShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnWidthCoerceValueStatic));

      partial void OnWidthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnWidthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SharpenShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnWidthCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Width (double)
      /// </summary>
      public double Width
      {
         get
         {
            return (double)GetValue(WidthProperty);
         }
         set
         {
            SetValue(WidthProperty, value);
         }
      }

      // END_PROPERTY Width
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\SmoothMagnify.fx.ps
   
   /// <summary>
   /// SmoothMagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SmoothMagnify.fx
   /// </summary>
   public sealed partial class SmoothMagnifyShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<SmoothMagnifyShaderEffect>();
   
      public SmoothMagnifyShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(InnerRadiusProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(SmoothMagnifyShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(System.Windows.Point),
         typeof(SmoothMagnifyShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SmoothMagnifyShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Center
      {
         get
         {
            return (System.Windows.Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY InnerRadius
      public static System.Windows.DependencyProperty InnerRadiusProperty = System.Windows.DependencyProperty.Register(
         @"InnerRadius",
         typeof(double),
         typeof(SmoothMagnifyShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnInnerRadiusCoerceValueStatic));

      partial void OnInnerRadiusCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnInnerRadiusCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SmoothMagnifyShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnInnerRadiusCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property InnerRadius (double)
      /// </summary>
      public double InnerRadius
      {
         get
         {
            return (double)GetValue(InnerRadiusProperty);
         }
         set
         {
            SetValue(InnerRadiusProperty, value);
         }
      }

      // END_PROPERTY InnerRadius
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\Swirl.fx.ps
   
   /// <summary>
   /// SwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Swirl.fx
   /// </summary>
   public sealed partial class SwirlShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<SwirlShaderEffect>();
   
      public SwirlShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(AngleFrequencyProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(SwirlShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(System.Windows.Point),
         typeof(SwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (System.Windows.Point)
      /// </summary>
      public System.Windows.Point Center
      {
         get
         {
            return (System.Windows.Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY SpiralStrength
      public static System.Windows.DependencyProperty SpiralStrengthProperty = System.Windows.DependencyProperty.Register(
         @"SpiralStrength",
         typeof(double),
         typeof(SwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnSpiralStrengthCoerceValueStatic));

      partial void OnSpiralStrengthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnSpiralStrengthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnSpiralStrengthCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property SpiralStrength (double)
      /// </summary>
      public double SpiralStrength
      {
         get
         {
            return (double)GetValue(SpiralStrengthProperty);
         }
         set
         {
            SetValue(SpiralStrengthProperty, value);
         }
      }

      // END_PROPERTY SpiralStrength
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY AngleFrequency
      public static System.Windows.DependencyProperty AngleFrequencyProperty = System.Windows.DependencyProperty.Register(
         @"AngleFrequency",
         typeof(System.Windows.Point),
         typeof(SwirlShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(2),
            OnAngleFrequencyCoerceValueStatic));

      partial void OnAngleFrequencyCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnAngleFrequencyCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnAngleFrequencyCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property AngleFrequency (System.Windows.Point)
      /// </summary>
      public System.Windows.Point AngleFrequency
      {
         get
         {
            return (System.Windows.Point)GetValue(AngleFrequencyProperty);
         }
         set
         {
            SetValue(AngleFrequencyProperty, value);
         }
      }

      // END_PROPERTY AngleFrequency
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ToneMapping.fx.ps
   
   /// <summary>
   /// ToneMappingShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ToneMapping.fx
   /// </summary>
   public sealed partial class ToneMappingShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ToneMappingShaderEffect>();
   
      public ToneMappingShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(ExposureProperty);
         UpdateShaderValue(DefogProperty);
         UpdateShaderValue(GammaProperty);
         UpdateShaderValue(FogColorProperty);
         UpdateShaderValue(VignetteRadiusProperty);
         UpdateShaderValue(VignetteCenterProperty);
         UpdateShaderValue(BlueShiftProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ToneMappingShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Exposure
      public static System.Windows.DependencyProperty ExposureProperty = System.Windows.DependencyProperty.Register(
         @"Exposure",
         typeof(double),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnExposureCoerceValueStatic));

      partial void OnExposureCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnExposureCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnExposureCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Exposure (double)
      /// </summary>
      public double Exposure
      {
         get
         {
            return (double)GetValue(ExposureProperty);
         }
         set
         {
            SetValue(ExposureProperty, value);
         }
      }

      // END_PROPERTY Exposure
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Defog
      public static System.Windows.DependencyProperty DefogProperty = System.Windows.DependencyProperty.Register(
         @"Defog",
         typeof(double),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnDefogCoerceValueStatic));

      partial void OnDefogCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnDefogCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDefogCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Defog (double)
      /// </summary>
      public double Defog
      {
         get
         {
            return (double)GetValue(DefogProperty);
         }
         set
         {
            SetValue(DefogProperty, value);
         }
      }

      // END_PROPERTY Defog
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Gamma
      public static System.Windows.DependencyProperty GammaProperty = System.Windows.DependencyProperty.Register(
         @"Gamma",
         typeof(double),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(2),
            OnGammaCoerceValueStatic));

      partial void OnGammaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnGammaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGammaCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Gamma (double)
      /// </summary>
      public double Gamma
      {
         get
         {
            return (double)GetValue(GammaProperty);
         }
         set
         {
            SetValue(GammaProperty, value);
         }
      }

      // END_PROPERTY Gamma
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY FogColor
      public static System.Windows.DependencyProperty FogColorProperty = System.Windows.DependencyProperty.Register(
         @"FogColor",
         typeof(System.Windows.Media.Color),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Color), 
            PixelShaderConstantCallback(3),
            OnFogColorCoerceValueStatic));

      partial void OnFogColorCoerceValue(
         System.Windows.Media.Color baseValue,
         ref System.Windows.Media.Color newValue,
         ref bool isProcessed
         );

      static object OnFogColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Media.Color)baseValue;
            var newValue = default(System.Windows.Media.Color);
            var isProcessed = false;
            inst.OnFogColorCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property FogColor (System.Windows.Media.Color)
      /// </summary>
      public System.Windows.Media.Color FogColor
      {
         get
         {
            return (System.Windows.Media.Color)GetValue(FogColorProperty);
         }
         set
         {
            SetValue(FogColorProperty, value);
         }
      }

      // END_PROPERTY FogColor
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY VignetteRadius
      public static System.Windows.DependencyProperty VignetteRadiusProperty = System.Windows.DependencyProperty.Register(
         @"VignetteRadius",
         typeof(double),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(4),
            OnVignetteRadiusCoerceValueStatic));

      partial void OnVignetteRadiusCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnVignetteRadiusCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnVignetteRadiusCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property VignetteRadius (double)
      /// </summary>
      public double VignetteRadius
      {
         get
         {
            return (double)GetValue(VignetteRadiusProperty);
         }
         set
         {
            SetValue(VignetteRadiusProperty, value);
         }
      }

      // END_PROPERTY VignetteRadius
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY VignetteCenter
      public static System.Windows.DependencyProperty VignetteCenterProperty = System.Windows.DependencyProperty.Register(
         @"VignetteCenter",
         typeof(System.Windows.Point),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(System.Windows.Point), 
            PixelShaderConstantCallback(5),
            OnVignetteCenterCoerceValueStatic));

      partial void OnVignetteCenterCoerceValue(
         System.Windows.Point baseValue,
         ref System.Windows.Point newValue,
         ref bool isProcessed
         );

      static object OnVignetteCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (System.Windows.Point)baseValue;
            var newValue = default(System.Windows.Point);
            var isProcessed = false;
            inst.OnVignetteCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property VignetteCenter (System.Windows.Point)
      /// </summary>
      public System.Windows.Point VignetteCenter
      {
         get
         {
            return (System.Windows.Point)GetValue(VignetteCenterProperty);
         }
         set
         {
            SetValue(VignetteCenterProperty, value);
         }
      }

      // END_PROPERTY VignetteCenter
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BlueShift
      public static System.Windows.DependencyProperty BlueShiftProperty = System.Windows.DependencyProperty.Register(
         @"BlueShift",
         typeof(double),
         typeof(ToneMappingShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(6),
            OnBlueShiftCoerceValueStatic));

      partial void OnBlueShiftCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBlueShiftCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlueShiftCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BlueShift (double)
      /// </summary>
      public double BlueShift
      {
         get
         {
            return (double)GetValue(BlueShiftProperty);
         }
         set
         {
            SetValue(BlueShiftProperty, value);
         }
      }

      // END_PROPERTY BlueShift
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ToonShader.fx.ps
   
   /// <summary>
   /// ToonShaderShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ToonShader.fx
   /// </summary>
   public sealed partial class ToonShaderShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ToonShaderShaderEffect>();
   
      public ToonShaderShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ToonShaderShaderEffect), 
            0);
   
   }
   
   // Wrote to H:\wpfshadereffects\WpfShaderEffects\ShaderBinary\ZoomBlur.fx.ps
   
   /// <summary>
   /// ZoomBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ZoomBlur.fx
   /// </summary>
   public sealed partial class ZoomBlurShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         WpfShaderEffects.Common.Utility.CreatePixelShader<ZoomBlurShaderEffect>();
   
      public ZoomBlurShaderEffect()
      {
         PixelShader = s_pixelShader;    
         UpdateShaderValue(InputProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(BlurAmountProperty);
            
      }
   
      public System.Windows.Media.Brush Input
      {
         get 
         { 
            return (System.Windows.Media.Brush)GetValue(InputProperty); 
         }
         set 
         { 
            SetValue(InputProperty, value); 
         }
      }

      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(ZoomBlurShaderEffect), 
            0);
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(double),
         typeof(ZoomBlurShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic));

      partial void OnCenterCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ZoomBlurShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property Center (double)
      /// </summary>
      public double Center
      {
         get
         {
            return (double)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BlurAmount
      public static System.Windows.DependencyProperty BlurAmountProperty = System.Windows.DependencyProperty.Register(
         @"BlurAmount",
         typeof(double),
         typeof(ZoomBlurShaderEffect),
         new System.Windows.PropertyMetadata(
            default(double), 
            PixelShaderConstantCallback(1),
            OnBlurAmountCoerceValueStatic));

      partial void OnBlurAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBlurAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ZoomBlurShaderEffect)instance;
         if(inst != null)
         {
            var bv = (double)baseValue;
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlurAmountCoerceValue(
               bv,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return baseValue;
            }
         }
         else
         {
            return baseValue;
         }
      }

      /// <summary>
      /// Gets or sets property BlurAmount (double)
      /// </summary>
      public double BlurAmount
      {
         get
         {
            return (double)GetValue(BlurAmountProperty);
         }
         set
         {
            SetValue(BlurAmountProperty, value);
         }
      }

      // END_PROPERTY BlurAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   

}
