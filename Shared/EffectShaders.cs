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


// CompilerPath      :     H:\wpfshadereffects2\Shared\..\Output\WpfShaderEffects.DirectX.dll
// ShaderSourcePath  :     H:\wpfshadereffects2\Shared\ShaderSource
// ShaderBinaryPath  :     H:\wpfshadereffects2\Shared\ShaderBinary

using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects
#endif
{
   public abstract partial class BaseShaderEffect : System.Windows.Media.Effects.ShaderEffect
   {
      protected BaseShaderEffect(System.Windows.Media.Effects.PixelShader pixelShader)
      {
         PixelShader = pixelShader;
         UpdateShaderValue(InputProperty);
      }
      
      public static readonly System.Windows.DependencyProperty InputProperty =
         RegisterPixelShaderSamplerProperty(
            "Input", 
            typeof(BaseShaderEffect), 
            0);
            
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\BandedSwirl.fx.ps
   
   /// <summary>
   /// BandedSwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BandedSwirl.fx
   /// </summary>
   public sealed partial class BandedSwirlShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BandedSwirlShaderEffect>();
   
      public BandedSwirlShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(DistanceThresholdProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(BandedSwirlShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of swirl effect
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1),
            OnSpiralStrengthCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var SpiralStrength = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnSpiralStrengthCoerceValue(
               SpiralStrength,
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
#endif
      /// <summary>
      /// Gets or sets property SpiralStrength (double)
      /// Strength of spiral in swirl effect
      /// Default Value: 0.5
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(2),
            OnDistanceThresholdCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var DistanceThreshold = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDistanceThresholdCoerceValue(
               DistanceThreshold,
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
#endif
      /// <summary>
      /// Gets or sets property DistanceThreshold (double)
      /// DistanceThreshold
      /// Default Value: 0.5
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Bloom.fx.ps
   
   /// <summary>
   /// BloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Bloom.fx
   /// </summary>
   public sealed partial class BloomShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BloomShaderEffect>();
   
      public BloomShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(BloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BloomIntensity
      public static System.Windows.DependencyProperty BloomIntensityProperty = System.Windows.DependencyProperty.Register(
         @"BloomIntensity",
         typeof(double),
         typeof(BloomShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.8,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.8,
            PixelShaderConstantCallback(0),
            OnBloomIntensityCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BloomIntensity = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBloomIntensityCoerceValue(
               BloomIntensity,
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
#endif
      /// <summary>
      /// Gets or sets property BloomIntensity (double)
      /// Intensity of bloom effect
      /// Default Value: 0.8
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.6,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.6,
            PixelShaderConstantCallback(1),
            OnBaseIntensityCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BaseIntensity = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseIntensityCoerceValue(
               BaseIntensity,
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
#endif
      /// <summary>
      /// Gets or sets property BaseIntensity (double)
      /// Intensity of base image
      /// Default Value: 0.6
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(2),
            OnBloomSaturationCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BloomSaturation = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBloomSaturationCoerceValue(
               BloomSaturation,
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
#endif
      /// <summary>
      /// Gets or sets property BloomSaturation (double)
      /// Bloom effect saturation
      /// Default Value: 1.0
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(3),
            OnBaseSaturationCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BaseSaturation = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseSaturationCoerceValue(
               BaseSaturation,
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
#endif
      /// <summary>
      /// Gets or sets property BaseSaturation (double)
      /// Base image saturation
      /// Default Value: 1.0
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\BrightExtract.fx.ps
   
   /// <summary>
   /// BrightExtractShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BrightExtract.fx
   /// </summary>
   public sealed partial class BrightExtractShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BrightExtractShaderEffect>();
   
      public BrightExtractShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ThresholdProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Threshold
      public static System.Windows.DependencyProperty ThresholdProperty = System.Windows.DependencyProperty.Register(
         @"Threshold",
         typeof(double),
         typeof(BrightExtractShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0),
            OnThresholdCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Threshold = (double)baseValue;
       
         // Coerce
         Threshold = Clamp(Threshold, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnThresholdCoerceValue(
               Threshold,
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
#endif
      /// <summary>
      /// Gets or sets property Threshold (double)
      /// Brightness threshold
      /// Value coercion: Clamp(Threshold, 0.0, 1.0)
      /// Default Value: 0.5
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\ColorKeyAlpha.fx.ps
   
   /// <summary>
   /// ColorKeyAlphaShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorKeyAlpha.fx
   /// </summary>
   public sealed partial class ColorKeyAlphaShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ColorKeyAlphaShaderEffect>();
   
      public ColorKeyAlphaShaderEffect()
         :  base(s_pixelShader)
      {
            
      }
   
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\ColorTone.fx.ps
   
   /// <summary>
   /// ColorToneShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorTone.fx
   /// </summary>
   public sealed partial class ColorToneShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ColorToneShaderEffect>();
   
      public ColorToneShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(DesaturationProperty);
         UpdateShaderValue(TonedProperty);
         UpdateShaderValue(LightColorProperty);
         UpdateShaderValue(DarkColorProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Desaturation
      public static System.Windows.DependencyProperty DesaturationProperty = System.Windows.DependencyProperty.Register(
         @"Desaturation",
         typeof(double),
         typeof(ColorToneShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0),
            OnDesaturationCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Desaturation = (double)baseValue;
       
         // Coerce
         Desaturation = Clamp(Desaturation, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDesaturationCoerceValue(
               Desaturation,
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
#endif
      /// <summary>
      /// Gets or sets property Desaturation (double)
      /// Desaturation value
      /// Value coercion: Clamp(Desaturation, 0.0, 1.0)
      /// Default Value: 0.5
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1),
            OnTonedCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Toned = (double)baseValue;
       
         // Coerce
         Toned = Clamp(Toned, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnTonedCoerceValue(
               Toned,
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
#endif
      /// <summary>
      /// Gets or sets property Toned (double)
      /// Toned value
      /// Value coercion: Clamp(Toned, 0.0, 1.0)
      /// Default Value: 0.5
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
         typeof(Color),
         typeof(ColorToneShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakeColor(0xFF, 0x7F, 0x00),
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            MakeColor(0xFF, 0x7F, 0x00),
            PixelShaderConstantCallback(2),
            OnLightColorCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnLightColorCoerceValue(
         Color baseValue,
         ref Color newValue,
         ref bool isProcessed
         );

      static object OnLightColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         var LightColor = (Color)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Color);
            var isProcessed = false;
            inst.OnLightColorCoerceValue(
               LightColor,
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
#endif
      /// <summary>
      /// Gets or sets property LightColor (Color)
      /// LightColor value
      /// Default Value: MakeColor(0xFF, 0x7F, 0x00)
      /// </summary>
      public Color LightColor
      {
         get
         {
            return (Color)GetValue(LightColorProperty);
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
         typeof(Color),
         typeof(ColorToneShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakeColor(0x00, 0x3F, 0x7F),
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            MakeColor(0x00, 0x3F, 0x7F),
            PixelShaderConstantCallback(3),
            OnDarkColorCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnDarkColorCoerceValue(
         Color baseValue,
         ref Color newValue,
         ref bool isProcessed
         );

      static object OnDarkColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ColorToneShaderEffect)instance;
         var DarkColor = (Color)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Color);
            var isProcessed = false;
            inst.OnDarkColorCoerceValue(
               DarkColor,
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
#endif
      /// <summary>
      /// Gets or sets property DarkColor (Color)
      /// DarkColor value
      /// Default Value: MakeColor(0x00, 0x3F, 0x7F)
      /// </summary>
      public Color DarkColor
      {
         get
         {
            return (Color)GetValue(DarkColorProperty);
         }
         set
         {
            SetValue(DarkColorProperty, value);
         }
      }

      // END_PROPERTY DarkColor
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\ContrastAdjust.fx.ps
   
   /// <summary>
   /// ContrastAdjustShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ContrastAdjust.fx
   /// </summary>
   public sealed partial class ContrastAdjustShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ContrastAdjustShaderEffect>();
   
      public ContrastAdjustShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BrightnessProperty);
         UpdateShaderValue(ContrastProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Brightness
      public static System.Windows.DependencyProperty BrightnessProperty = System.Windows.DependencyProperty.Register(
         @"Brightness",
         typeof(Color),
         typeof(ContrastAdjustShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakeColor(0x2F, 0x2F, 0x2F),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakeColor(0x2F, 0x2F, 0x2F),
            PixelShaderConstantCallback(0),
            OnBrightnessCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnBrightnessCoerceValue(
         Color baseValue,
         ref Color newValue,
         ref bool isProcessed
         );

      static object OnBrightnessCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ContrastAdjustShaderEffect)instance;
         var Brightness = (Color)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Color);
            var isProcessed = false;
            inst.OnBrightnessCoerceValue(
               Brightness,
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
#endif
      /// <summary>
      /// Gets or sets property Brightness (Color)
      /// Brightness color
      /// Default Value: MakeColor(0x2F, 0x2F, 0x2F)
      /// </summary>
      public Color Brightness
      {
         get
         {
            return (Color)GetValue(BrightnessProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnContrastCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Contrast = (double)baseValue;
       
         // Coerce
         Contrast = Clamp(Contrast, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnContrastCoerceValue(
               Contrast,
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
#endif
      /// <summary>
      /// Gets or sets property Contrast (double)
      /// Contrast value
      /// Value coercion: Clamp(Contrast, 0.0, 1.0)
      /// Default Value: 0.2
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\DirectionalBlur.fx.ps
   
   /// <summary>
   /// DirectionalBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: DirectionalBlur.fx
   /// </summary>
   public sealed partial class DirectionalBlurShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<DirectionalBlurShaderEffect>();
   
      public DirectionalBlurShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AngleProperty);
         UpdateShaderValue(BlurAmountProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Angle
      public static System.Windows.DependencyProperty AngleProperty = System.Windows.DependencyProperty.Register(
         @"Angle",
         typeof(double),
         typeof(DirectionalBlurShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(0),
            OnAngleCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Angle = (double)baseValue;
       
         // Coerce
         Angle = Angle % (2.0 * Pi);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAngleCoerceValue(
               Angle,
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
#endif
      /// <summary>
      /// Gets or sets property Angle (double)
      /// Blur direction (in radians)
      /// Value coercion: Angle % (2.0 * Pi)
      /// Default Value: 0.1
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnBlurAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BlurAmount = (double)baseValue;
       
         // Coerce
         BlurAmount = Clamp(BlurAmount, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlurAmountCoerceValue(
               BlurAmount,
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
#endif
      /// <summary>
      /// Gets or sets property BlurAmount (double)
      /// Amount of blur
      /// Value coercion: Clamp(BlurAmount, 0.0, double.MaxValue)
      /// Default Value: 0.2
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Embossed.fx.ps
   
   /// <summary>
   /// EmbossedShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Embossed.fx
   /// </summary>
   public sealed partial class EmbossedShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<EmbossedShaderEffect>();
   
      public EmbossedShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(EmbossedShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0),
            OnAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Amount = (double)baseValue;
       
         // Coerce
         Amount = Clamp(Amount, -1.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               Amount,
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
#endif
      /// <summary>
      /// Gets or sets property Amount (double)
      /// Amount of emboss
      /// Value coercion: Clamp(Amount, -1.0, 1.0)
      /// Default Value: 0.2
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.01,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.01,
            PixelShaderConstantCallback(1),
            OnWidthCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Width = (double)baseValue;
       
         // Coerce
         Width = Clamp(Width, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnWidthCoerceValue(
               Width,
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
#endif
      /// <summary>
      /// Gets or sets property Width (double)
      /// Width of emboss
      /// Value coercion: Clamp(Width, 0.0, 1.0)
      /// Default Value: 0.01
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Gloom.fx.ps
   
   /// <summary>
   /// GloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Gloom.fx
   /// </summary>
   public sealed partial class GloomShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<GloomShaderEffect>();
   
      public GloomShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(GloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(GloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY GloomIntensity
      public static System.Windows.DependencyProperty GloomIntensityProperty = System.Windows.DependencyProperty.Register(
         @"GloomIntensity",
         typeof(double),
         typeof(GloomShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.8,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.8,
            PixelShaderConstantCallback(0),
            OnGloomIntensityCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var GloomIntensity = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGloomIntensityCoerceValue(
               GloomIntensity,
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
#endif
      /// <summary>
      /// Gets or sets property GloomIntensity (double)
      /// Intensity of gloom effect
      /// Default Value: 0.8
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.6,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.6,
            PixelShaderConstantCallback(1),
            OnBaseIntensityCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BaseIntensity = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseIntensityCoerceValue(
               BaseIntensity,
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
#endif
      /// <summary>
      /// Gets or sets property BaseIntensity (double)
      /// Intensity of base image
      /// Default Value: 0.6
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(2),
            OnGloomSaturationCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var GloomSaturation = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGloomSaturationCoerceValue(
               GloomSaturation,
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
#endif
      /// <summary>
      /// Gets or sets property GloomSaturation (double)
      /// Gloom effect saturation
      /// Default Value: 1.0
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(3),
            OnBaseSaturationCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BaseSaturation = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBaseSaturationCoerceValue(
               BaseSaturation,
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
#endif
      /// <summary>
      /// Gets or sets property BaseSaturation (double)
      /// Base image saturation
      /// Default Value: 1.0
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\GrowablePoissonDisk.fx.ps
   
   /// <summary>
   /// GrowablePoissonDiskShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: GrowablePoissonDisk.fx
   /// </summary>
   public sealed partial class GrowablePoissonDiskShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<GrowablePoissonDiskShaderEffect>();
   
      public GrowablePoissonDiskShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(DiscRadiusProperty);
         UpdateShaderValue(ScreenSizeProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY DiscRadius
      public static System.Windows.DependencyProperty DiscRadiusProperty = System.Windows.DependencyProperty.Register(
         @"DiscRadius",
         typeof(double),
         typeof(GrowablePoissonDiskShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0),
            OnDiscRadiusCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var DiscRadius = (double)baseValue;
       
         // Coerce
         DiscRadius = Clamp(DiscRadius, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDiscRadiusCoerceValue(
               DiscRadius,
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
#endif
      /// <summary>
      /// Gets or sets property DiscRadius (double)
      /// Radius of disc
      /// Value coercion: Clamp(DiscRadius, 0.0, 1.0)
      /// Default Value: 0.2
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
      // BEGIN_PROPERTY ScreenSize
      public static System.Windows.DependencyProperty ScreenSizeProperty = System.Windows.DependencyProperty.Register(
         @"ScreenSize",
         typeof(Point),
         typeof(GrowablePoissonDiskShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(100.0, 100.0),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(100.0, 100.0),
            PixelShaderConstantCallback(1),
            OnScreenSizeCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnScreenSizeCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnScreenSizeCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (GrowablePoissonDiskShaderEffect)instance;
         var ScreenSize = (Point)baseValue;
       
         // Coerce
         ScreenSize = Clamp(ScreenSize, MakePoint(1.0, 1.0), MakePoint(double.MaxValue, double.MaxValue));
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnScreenSizeCoerceValue(
               ScreenSize,
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
#endif
      /// <summary>
      /// Gets or sets property ScreenSize (Point)
      /// Size of screen
      /// Value coercion: Clamp(ScreenSize, MakePoint(1.0, 1.0), MakePoint(double.MaxValue, double.MaxValue))
      /// Default Value: MakePoint(100.0, 100.0)
      /// </summary>
      public Point ScreenSize
      {
         get
         {
            return (Point)GetValue(ScreenSizeProperty);
         }
         set
         {
            SetValue(ScreenSizeProperty, value);
         }
      }

      // END_PROPERTY ScreenSize
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\InvertColor.fx.ps
   
   /// <summary>
   /// InvertColorShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: InvertColor.fx
   /// </summary>
   public sealed partial class InvertColorShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<InvertColorShaderEffect>();
   
      public InvertColorShaderEffect()
         :  base(s_pixelShader)
      {
            
      }
   
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\LightStreak.fx.ps
   
   /// <summary>
   /// LightStreakShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: LightStreak.fx
   /// </summary>
   public sealed partial class LightStreakShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<LightStreakShaderEffect>();
   
      public LightStreakShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BrightThresholdProperty);
         UpdateShaderValue(ScaleProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BrightThreshold
      public static System.Windows.DependencyProperty BrightThresholdProperty = System.Windows.DependencyProperty.Register(
         @"BrightThreshold",
         typeof(double),
         typeof(LightStreakShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(0),
            OnBrightThresholdCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BrightThreshold = (double)baseValue;
       
         // Coerce
         BrightThreshold = Clamp(BrightThreshold, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBrightThresholdCoerceValue(
               BrightThreshold,
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
#endif
      /// <summary>
      /// Gets or sets property BrightThreshold (double)
      /// Brightness threshold
      /// Value coercion: Clamp(BrightThreshold, 0.0, 1.0)
      /// Default Value: 0.5
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            2.0,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            2.0,
            PixelShaderConstantCallback(1),
            OnScaleCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Scale = (double)baseValue;
       
         // Coerce
         Scale = Clamp(Scale, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnScaleCoerceValue(
               Scale,
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
#endif
      /// <summary>
      /// Gets or sets property Scale (double)
      /// Scale value
      /// Value coercion: Clamp(Scale, 0.0, double.MaxValue)
      /// Default Value: 2.0
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Magnify.fx.ps
   
   /// <summary>
   /// MagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Magnify.fx
   /// </summary>
   public sealed partial class MagnifyShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MagnifyShaderEffect>();
   
      public MagnifyShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(RadiiProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmountProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Radii
      public static System.Windows.DependencyProperty RadiiProperty = System.Windows.DependencyProperty.Register(
         @"Radii",
         typeof(Point),
         typeof(MagnifyShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.1,0.1),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.1,0.1),
            PixelShaderConstantCallback(0),
            OnRadiiCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnRadiiCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnRadiiCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MagnifyShaderEffect)instance;
         var Radii = (Point)baseValue;
       
         // Coerce
         Radii = Clamp(Radii, MakePoint(0.00001, 0.00001), MakePoint(double.MaxValue, double.MaxValue));
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnRadiiCoerceValue(
               Radii,
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
#endif
      /// <summary>
      /// Gets or sets property Radii (Point)
      /// Radii of Magnify
      /// Value coercion: Clamp(Radii, MakePoint(0.00001, 0.00001), MakePoint(double.MaxValue, double.MaxValue))
      /// Default Value: MakePoint(0.1,0.1)
      /// </summary>
      public Point Radii
      {
         get
         {
            return (Point)GetValue(RadiiProperty);
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
         typeof(Point),
         typeof(MagnifyShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(1),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MagnifyShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of Magnify
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            2.0,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            2.0,
            PixelShaderConstantCallback(2),
            OnAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Amount = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               Amount,
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
#endif
      /// <summary>
      /// Gets or sets property Amount (double)
      /// Amount of Magnify
      /// Default Value: 2.0
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Monochrome.fx.ps
   
   /// <summary>
   /// MonochromeShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Monochrome.fx
   /// </summary>
   public sealed partial class MonochromeShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MonochromeShaderEffect>();
   
      public MonochromeShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(FilterColorProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY FilterColor
      public static System.Windows.DependencyProperty FilterColorProperty = System.Windows.DependencyProperty.Register(
         @"FilterColor",
         typeof(Color),
         typeof(MonochromeShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakeColor(0x7F, 0x7F, 0x7F),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakeColor(0x7F, 0x7F, 0x7F),
            PixelShaderConstantCallback(0),
            OnFilterColorCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnFilterColorCoerceValue(
         Color baseValue,
         ref Color newValue,
         ref bool isProcessed
         );

      static object OnFilterColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MonochromeShaderEffect)instance;
         var FilterColor = (Color)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Color);
            var isProcessed = false;
            inst.OnFilterColorCoerceValue(
               FilterColor,
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
#endif
      /// <summary>
      /// Gets or sets property FilterColor (Color)
      /// Monochrome color
      /// Default Value: MakeColor(0x7F, 0x7F, 0x7F)
      /// </summary>
      public Color FilterColor
      {
         get
         {
            return (Color)GetValue(FilterColorProperty);
         }
         set
         {
            SetValue(FilterColorProperty, value);
         }
      }

      // END_PROPERTY FilterColor
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Pinch.fx.ps
   
   /// <summary>
   /// PinchShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pinch.fx
   /// </summary>
   public sealed partial class PinchShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PinchShaderEffect>();
   
      public PinchShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(RadiusProperty);
         UpdateShaderValue(AmountProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(PinchShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PinchShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of pinching
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
         }
         set
         {
            SetValue(CenterProperty, value);
         }
      }

      // END_PROPERTY Center
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Radius
      public static System.Windows.DependencyProperty RadiusProperty = System.Windows.DependencyProperty.Register(
         @"Radius",
         typeof(double),
         typeof(PinchShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnRadiusCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Radius = (double)baseValue;
       
         // Coerce
         Radius = Clamp(Radius, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnRadiusCoerceValue(
               Radius,
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
#endif
      /// <summary>
      /// Gets or sets property Radius (double)
      /// Radius of pinching
      /// Value coercion: Clamp(Radius, 0.0, double.MaxValue)
      /// Default Value: 0.2
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(2),
            OnAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Amount = (double)baseValue;
       
         // Coerce
         Amount = Clamp(Amount, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               Amount,
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
#endif
      /// <summary>
      /// Gets or sets property Amount (double)
      /// Amount of pinching
      /// Value coercion: Clamp(Amount, 0.0, double.MaxValue)
      /// Default Value: 0.2
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Pixelate.fx.ps
   
   /// <summary>
   /// PixelateShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pixelate.fx
   /// </summary>
   public sealed partial class PixelateShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PixelateShaderEffect>();
   
      public PixelateShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(PixelCountProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY PixelCount
      public static System.Windows.DependencyProperty PixelCountProperty = System.Windows.DependencyProperty.Register(
         @"PixelCount",
         typeof(Point),
         typeof(PixelateShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(20.0, 20.0),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(20.0, 20.0),
            PixelShaderConstantCallback(0),
            OnPixelCountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnPixelCountCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnPixelCountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateShaderEffect)instance;
         var PixelCount = (Point)baseValue;
       
         // Coerce
         PixelCount = Clamp(PixelCount, MakePoint(20.0, 20.0), MakePoint(10000.0, 10000.0));
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnPixelCountCoerceValue(
               PixelCount,
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
#endif
      /// <summary>
      /// Gets or sets property PixelCount (Point)
      /// PixelCount value
      /// Value coercion: Clamp(PixelCount, MakePoint(20.0, 20.0), MakePoint(10000.0, 10000.0))
      /// Default Value: MakePoint(20.0, 20.0)
      /// </summary>
      public Point PixelCount
      {
         get
         {
            return (Point)GetValue(PixelCountProperty);
         }
         set
         {
            SetValue(PixelCountProperty, value);
         }
      }

      // END_PROPERTY PixelCount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Ripple.fx.ps
   
   /// <summary>
   /// RippleShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Ripple.fx
   /// </summary>
   public sealed partial class RippleShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<RippleShaderEffect>();
   
      public RippleShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmplitudeProperty);
         UpdateShaderValue(FrequencyProperty);
         UpdateShaderValue(PhaseProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(RippleShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of ripple
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnAmplitudeCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Amplitude = (double)baseValue;
       
         // Coerce
         Amplitude = Clamp(Amplitude, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmplitudeCoerceValue(
               Amplitude,
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
#endif
      /// <summary>
      /// Gets or sets property Amplitude (double)
      /// Amplitude of ripple
      /// Value coercion: Clamp(Amplitude, 0.0, double.MaxValue)
      /// Default Value: 0.2
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            4.0,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            4.0,
            PixelShaderConstantCallback(2),
            OnFrequencyCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Frequency = (double)baseValue;
       
         // Coerce
         Frequency = Clamp(Frequency, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnFrequencyCoerceValue(
               Frequency,
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
#endif
      /// <summary>
      /// Gets or sets property Frequency (double)
      /// Frequency of ripple
      /// Value coercion: Clamp(Frequency, 0.0, double.MaxValue)
      /// Default Value: 4.0
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            0.0,
            PixelShaderConstantCallback(3),
            OnPhaseCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Phase = (double)baseValue;
       
         // Coerce
         Phase = Phase % (2 * Pi);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnPhaseCoerceValue(
               Phase,
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
#endif
      /// <summary>
      /// Gets or sets property Phase (double)
      /// Phase of ripple
      /// Value coercion: Phase % (2 * Pi)
      /// Default Value: 0.0
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Sharpen.fx.ps
   
   /// <summary>
   /// SharpenShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Sharpen.fx
   /// </summary>
   public sealed partial class SharpenShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SharpenShaderEffect>();
   
      public SharpenShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(SharpenShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(0),
            OnAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Amount = (double)baseValue;
       
         // Coerce
         Amount = Clamp(Amount, -1.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAmountCoerceValue(
               Amount,
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
#endif
      /// <summary>
      /// Gets or sets property Amount (double)
      /// Amount of sharpness
      /// Value coercion: Clamp(Amount, -1.0, 1.0)
      /// Default Value: 0.1
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.01,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.01,
            PixelShaderConstantCallback(1),
            OnWidthCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Width = (double)baseValue;
       
         // Coerce
         Width = Clamp(Width, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnWidthCoerceValue(
               Width,
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
#endif
      /// <summary>
      /// Gets or sets property Width (double)
      /// Width of sharpness
      /// Value coercion: Clamp(Width, 0.0, 1.0)
      /// Default Value: 0.01
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\SmoothMagnify.fx.ps
   
   /// <summary>
   /// SmoothMagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SmoothMagnify.fx
   /// </summary>
   public sealed partial class SmoothMagnifyShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SmoothMagnifyShaderEffect>();
   
      public SmoothMagnifyShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(InnerRadiusProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(SmoothMagnifyShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SmoothMagnifyShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of Magnify
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(2),
            OnInnerRadiusCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var InnerRadius = (double)baseValue;
       
         // Coerce
         InnerRadius = Clamp(InnerRadius, 0.00001, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnInnerRadiusCoerceValue(
               InnerRadius,
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
#endif
      /// <summary>
      /// Gets or sets property InnerRadius (double)
      /// InnerRadius of Magnify
      /// Value coercion: Clamp(InnerRadius, 0.00001, double.MaxValue)
      /// Default Value: 0.1
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Swirl.fx.ps
   
   /// <summary>
   /// SwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Swirl.fx
   /// </summary>
   public sealed partial class SwirlShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SwirlShaderEffect>();
   
      public SwirlShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(AngleFrequencyProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(SwirlShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of Swirl
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.5,
            PixelShaderConstantCallback(1),
            OnSpiralStrengthCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var SpiralStrength = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnSpiralStrengthCoerceValue(
               SpiralStrength,
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
#endif
      /// <summary>
      /// Gets or sets property SpiralStrength (double)
      /// Strength of spiral in swirl effect
      /// Default Value: 0.5
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
         typeof(Point),
         typeof(SwirlShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(2.0,2.0),
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(2.0,2.0),
            PixelShaderConstantCallback(2),
            OnAngleFrequencyCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAngleFrequencyCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnAngleFrequencyCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlShaderEffect)instance;
         var AngleFrequency = (Point)baseValue;
       
         // Coerce
         AngleFrequency = Clamp(AngleFrequency, MakePoint(0.0,0.0), MakePoint(double.MaxValue,double.MaxValue));
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnAngleFrequencyCoerceValue(
               AngleFrequency,
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
#endif
      /// <summary>
      /// Gets or sets property AngleFrequency (Point)
      /// AngleFrequency of spiral in swirl effect
      /// Value coercion: Clamp(AngleFrequency, MakePoint(0.0,0.0), MakePoint(double.MaxValue,double.MaxValue))
      /// Default Value: MakePoint(2.0,2.0)
      /// </summary>
      public Point AngleFrequency
      {
         get
         {
            return (Point)GetValue(AngleFrequencyProperty);
         }
         set
         {
            SetValue(AngleFrequencyProperty, value);
         }
      }

      // END_PROPERTY AngleFrequency
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\ToneMapping.fx.ps
   
   /// <summary>
   /// ToneMappingShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ToneMapping.fx
   /// </summary>
   public sealed partial class ToneMappingShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ToneMappingShaderEffect>();
   
      public ToneMappingShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ExposureProperty);
         UpdateShaderValue(DefogProperty);
         UpdateShaderValue(GammaProperty);
         UpdateShaderValue(FogColorProperty);
         UpdateShaderValue(VignetteRadiusProperty);
         UpdateShaderValue(VignetteCenterProperty);
         UpdateShaderValue(BlueShiftProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Exposure
      public static System.Windows.DependencyProperty ExposureProperty = System.Windows.DependencyProperty.Register(
         @"Exposure",
         typeof(double),
         typeof(ToneMappingShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(0),
            OnExposureCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Exposure = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnExposureCoerceValue(
               Exposure,
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
#endif
      /// <summary>
      /// Gets or sets property Exposure (double)
      /// Exposure value of tone mapping effect
      /// Default Value: 0.2
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnDefogCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Defog = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnDefogCoerceValue(
               Defog,
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
#endif
      /// <summary>
      /// Gets or sets property Defog (double)
      /// Defog value of tone mapping effect
      /// Default Value: 0.2
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(2),
            OnGammaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var Gamma = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnGammaCoerceValue(
               Gamma,
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
#endif
      /// <summary>
      /// Gets or sets property Gamma (double)
      /// Gamma value of tone mapping effect
      /// Default Value: 0.1
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
         typeof(Color),
         typeof(ToneMappingShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakeColor(0xAF, 0xAF, 0xAF),
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            MakeColor(0xAF, 0xAF, 0xAF),
            PixelShaderConstantCallback(3),
            OnFogColorCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnFogColorCoerceValue(
         Color baseValue,
         ref Color newValue,
         ref bool isProcessed
         );

      static object OnFogColorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         var FogColor = (Color)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Color);
            var isProcessed = false;
            inst.OnFogColorCoerceValue(
               FogColor,
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
#endif
      /// <summary>
      /// Gets or sets property FogColor (Color)
      /// FogColor value of tone mapping effect
      /// Default Value: MakeColor(0xAF, 0xAF, 0xAF)
      /// </summary>
      public Color FogColor
      {
         get
         {
            return (Color)GetValue(FogColorProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(4))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(4),
            OnVignetteRadiusCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var VignetteRadius = (double)baseValue;
       
         // Coerce
         VignetteRadius = Clamp(VignetteRadius, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnVignetteRadiusCoerceValue(
               VignetteRadius,
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
#endif
      /// <summary>
      /// Gets or sets property VignetteRadius (double)
      /// VignetteRadius value of tone mapping effect
      /// Value coercion: Clamp(VignetteRadius, 0.0, double.MaxValue)
      /// Default Value: 0.1
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
         typeof(Point),
         typeof(ToneMappingShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(5))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(5),
            OnVignetteCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnVignetteCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnVignetteCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ToneMappingShaderEffect)instance;
         var VignetteCenter = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnVignetteCenterCoerceValue(
               VignetteCenter,
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
#endif
      /// <summary>
      /// Gets or sets property VignetteCenter (Point)
      /// VignetteCenter value of tone mapping effect
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point VignetteCenter
      {
         get
         {
            return (Point)GetValue(VignetteCenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.1,
            PixelShaderConstantCallback(6))
#else
         new System.Windows.UIPropertyMetadata(
            0.1,
            PixelShaderConstantCallback(6),
            OnBlueShiftCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BlueShift = (double)baseValue;
       
         // Coerce
         BlueShift = Clamp(BlueShift, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlueShiftCoerceValue(
               BlueShift,
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
#endif
      /// <summary>
      /// Gets or sets property BlueShift (double)
      /// BlueShift value of tone mapping effect
      /// Value coercion: Clamp(BlueShift, 0.0, 1.0)
      /// Default Value: 0.1
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
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\Toon.fx.ps
   
   /// <summary>
   /// ToonShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Toon.fx
   /// </summary>
   public sealed partial class ToonShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ToonShaderEffect>();
   
      public ToonShaderEffect()
         :  base(s_pixelShader)
      {
            
      }
   
   
   }
   
   // Wrote to H:\wpfshadereffects2\Shared\ShaderBinary\ZoomBlur.fx.ps
   
   /// <summary>
   /// ZoomBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ZoomBlur.fx
   /// </summary>
   public sealed partial class ZoomBlurShaderEffect : BaseShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ZoomBlurShaderEffect>();
   
      public ZoomBlurShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(BlurAmountProperty);
            
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Center
      public static System.Windows.DependencyProperty CenterProperty = System.Windows.DependencyProperty.Register(
         @"Center",
         typeof(Point),
         typeof(ZoomBlurShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            MakePoint(0.5,0.5),
            PixelShaderConstantCallback(0),
            OnCenterCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnCenterCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnCenterCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ZoomBlurShaderEffect)instance;
         var Center = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnCenterCoerceValue(
               Center,
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
#endif
      /// <summary>
      /// Gets or sets property Center (Point)
      /// Center of Zoom
      /// Default Value: MakePoint(0.5,0.5)
      /// </summary>
      public Point Center
      {
         get
         {
            return (Point)GetValue(CenterProperty);
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
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnBlurAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
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
         var BlurAmount = (double)baseValue;
       
         // Coerce
         BlurAmount = Clamp(BlurAmount, 0.0, double.MaxValue);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBlurAmountCoerceValue(
               BlurAmount,
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
#endif
      /// <summary>
      /// Gets or sets property BlurAmount (double)
      /// The amount of blur to apply
      /// Value coercion: Clamp(BlurAmount, 0.0, double.MaxValue)
      /// Default Value: 0.2
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
