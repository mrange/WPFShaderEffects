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


// CompilerPath      :     F:\Projects\wpfshadereffects\Shared\..\Output\WpfShaderEffects.DirectX.dll
// ShaderSourcePath  :     F:\Projects\wpfshadereffects\Shared\ShaderSource
// ShaderBinaryPath  :     F:\Projects\wpfshadereffects\Shared\ShaderBinary

using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects
#endif
{
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Add.fx.ps
   
   /// <summary>
   /// AddShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Add.fx
   /// </summary>
   public sealed partial class AddShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<AddShaderEffect>();
   
      partial void OnConstruction();
      
      public AddShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(AddShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (AddShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Alpha.fx.ps
   
   /// <summary>
   /// AlphaShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Alpha.fx
   /// </summary>
   public sealed partial class AlphaShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<AlphaShaderEffect>();
   
      partial void OnConstruction();
      
      public AlphaShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(AlphaShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (AlphaShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha on input
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\BandedSwirl.fx.ps
   
   /// <summary>
   /// BandedSwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BandedSwirl.fx
   /// </summary>
   public sealed partial class BandedSwirlShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BandedSwirlShaderEffect>();
   
      partial void OnConstruction();
      
      public BandedSwirlShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(DistanceThresholdProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return SpiralStrength;
            }
         }
         else
         {
            return SpiralStrength;
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
               return DistanceThreshold;
            }
         }
         else
         {
            return DistanceThreshold;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\BandedSwirlTransition.fx.ps
   
   /// <summary>
   /// BandedSwirlTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BandedSwirlTransition.fx
   /// </summary>
   public sealed partial class BandedSwirlTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BandedSwirlTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public BandedSwirlTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(TwistAmountProperty);
         UpdateShaderValue(FrequencyProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(BandedSwirlTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY TwistAmount
      public static System.Windows.DependencyProperty TwistAmountProperty = System.Windows.DependencyProperty.Register(
         @"TwistAmount",
         typeof(double),
         typeof(BandedSwirlTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1),
            OnTwistAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnTwistAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnTwistAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedSwirlTransitionShaderEffect)instance;
         var TwistAmount = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnTwistAmountCoerceValue(
               TwistAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return TwistAmount;
            }
         }
         else
         {
            return TwistAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property TwistAmount (double)
      /// Default Value: default(double)
      /// </summary>
      public double TwistAmount
      {
         get
         {
            return (double)GetValue(TwistAmountProperty);
         }
         set
         {
            SetValue(TwistAmountProperty, value);
         }
      }

      // END_PROPERTY TwistAmount
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Frequency
      public static System.Windows.DependencyProperty FrequencyProperty = System.Windows.DependencyProperty.Register(
         @"Frequency",
         typeof(double),
         typeof(BandedSwirlTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
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
         var inst = (BandedSwirlTransitionShaderEffect)instance;
         var Frequency = (double)baseValue;
      
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
               return Frequency;
            }
         }
         else
         {
            return Frequency;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Frequency (double)
      /// Default Value: default(double)
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
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\BandedTransition.fx.ps
   
   /// <summary>
   /// BandedTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BandedTransition.fx
   /// </summary>
   public sealed partial class BandedTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BandedTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public BandedTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(BandHeightProperty);
         UpdateShaderValue(BandOffsetProperty);
         DdxUvDdyUvRegisterIndex = 3;
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(BandedTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.0,
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
       
         // Coerce
         Progress = Clamp(Progress, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Progress of transition
      /// Value coercion: Clamp(Progress, 0.0, 1.0)
      /// Default Value: 0.0
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BandHeight
      public static System.Windows.DependencyProperty BandHeightProperty = System.Windows.DependencyProperty.Register(
         @"BandHeight",
         typeof(double),
         typeof(BandedTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            0.2,
            PixelShaderConstantCallback(1),
            OnBandHeightCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnBandHeightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBandHeightCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedTransitionShaderEffect)instance;
         var BandHeight = (double)baseValue;
       
         // Coerce
         BandHeight = Clamp(BandHeight, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBandHeightCoerceValue(
               BandHeight,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return BandHeight;
            }
         }
         else
         {
            return BandHeight;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property BandHeight (double)
      /// Height of bands
      /// Value coercion: Clamp(BandHeight, 0.0, 1.0)
      /// Default Value: 0.2
      /// </summary>
      public double BandHeight
      {
         get
         {
            return (double)GetValue(BandHeightProperty);
         }
         set
         {
            SetValue(BandHeightProperty, value);
         }
      }

      // END_PROPERTY BandHeight
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BandOffset
      public static System.Windows.DependencyProperty BandOffsetProperty = System.Windows.DependencyProperty.Register(
         @"BandOffset",
         typeof(double),
         typeof(BandedTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            0.0,
            PixelShaderConstantCallback(2),
            OnBandOffsetCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnBandOffsetCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnBandOffsetCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BandedTransitionShaderEffect)instance;
         var BandOffset = (double)baseValue;
       
         // Coerce
         BandOffset = Clamp(BandOffset, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnBandOffsetCoerceValue(
               BandOffset,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return BandOffset;
            }
         }
         else
         {
            return BandOffset;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property BandOffset (double)
      /// Offset of bands
      /// Value coercion: Clamp(BandOffset, 0.0, 1.0)
      /// Default Value: 0.0
      /// </summary>
      public double BandOffset
      {
         get
         {
            return (double)GetValue(BandOffsetProperty);
         }
         set
         {
            SetValue(BandOffsetProperty, value);
         }
      }

      // END_PROPERTY BandOffset
      // ----------------------------------------------------------------------
      
      // Skipped parameter: ddx_ddy as it's a DdxDdy register
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\BlindsTransition.fx.ps
   
   /// <summary>
   /// BlindsTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BlindsTransition.fx
   /// </summary>
   public sealed partial class BlindsTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BlindsTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public BlindsTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(BlindsTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (BlindsTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Bloom.fx.ps
   
   /// <summary>
   /// BloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Bloom.fx
   /// </summary>
   public sealed partial class BloomShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BloomShaderEffect>();
   
      partial void OnConstruction();
      
      public BloomShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(BloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
         OnConstruction();
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
               return BloomIntensity;
            }
         }
         else
         {
            return BloomIntensity;
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
               return BaseIntensity;
            }
         }
         else
         {
            return BaseIntensity;
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
               return BloomSaturation;
            }
         }
         else
         {
            return BloomSaturation;
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
               return BaseSaturation;
            }
         }
         else
         {
            return BaseSaturation;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\BrightExtract.fx.ps
   
   /// <summary>
   /// BrightExtractShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: BrightExtract.fx
   /// </summary>
   public sealed partial class BrightExtractShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<BrightExtractShaderEffect>();
   
      partial void OnConstruction();
      
      public BrightExtractShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ThresholdProperty);
            
         OnConstruction();
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
               return Threshold;
            }
         }
         else
         {
            return Threshold;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\CircleRevealTransition.fx.ps
   
   /// <summary>
   /// CircleRevealTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: CircleRevealTransition.fx
   /// </summary>
   public sealed partial class CircleRevealTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<CircleRevealTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public CircleRevealTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(FuzzyAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(CircleRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (CircleRevealTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY FuzzyAmount
      public static System.Windows.DependencyProperty FuzzyAmountProperty = System.Windows.DependencyProperty.Register(
         @"FuzzyAmount",
         typeof(double),
         typeof(CircleRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1),
            OnFuzzyAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnFuzzyAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnFuzzyAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (CircleRevealTransitionShaderEffect)instance;
         var FuzzyAmount = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnFuzzyAmountCoerceValue(
               FuzzyAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return FuzzyAmount;
            }
         }
         else
         {
            return FuzzyAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property FuzzyAmount (double)
      /// Default Value: default(double)
      /// </summary>
      public double FuzzyAmount
      {
         get
         {
            return (double)GetValue(FuzzyAmountProperty);
         }
         set
         {
            SetValue(FuzzyAmountProperty, value);
         }
      }

      // END_PROPERTY FuzzyAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\CircleStretchTransition.fx.ps
   
   /// <summary>
   /// CircleStretchTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: CircleStretchTransition.fx
   /// </summary>
   public sealed partial class CircleStretchTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<CircleStretchTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public CircleStretchTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(CircleStretchTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (CircleStretchTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ColorKeyAlpha.fx.ps
   
   /// <summary>
   /// ColorKeyAlphaShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorKeyAlpha.fx
   /// </summary>
   public sealed partial class ColorKeyAlphaShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ColorKeyAlphaShaderEffect>();
   
      partial void OnConstruction();
      
      public ColorKeyAlphaShaderEffect()
         :  base(s_pixelShader)
      {
            
         OnConstruction();
      }
   
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ColorTone.fx.ps
   
   /// <summary>
   /// ColorToneShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ColorTone.fx
   /// </summary>
   public sealed partial class ColorToneShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ColorToneShaderEffect>();
   
      partial void OnConstruction();
      
      public ColorToneShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(DesaturationProperty);
         UpdateShaderValue(TonedProperty);
         UpdateShaderValue(LightColorProperty);
         UpdateShaderValue(DarkColorProperty);
            
         OnConstruction();
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
               return Desaturation;
            }
         }
         else
         {
            return Desaturation;
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
               return Toned;
            }
         }
         else
         {
            return Toned;
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
               return LightColor;
            }
         }
         else
         {
            return LightColor;
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
               return DarkColor;
            }
         }
         else
         {
            return DarkColor;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ContrastAdjust.fx.ps
   
   /// <summary>
   /// ContrastAdjustShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ContrastAdjust.fx
   /// </summary>
   public sealed partial class ContrastAdjustShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ContrastAdjustShaderEffect>();
   
      partial void OnConstruction();
      
      public ContrastAdjustShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BrightnessProperty);
         UpdateShaderValue(ContrastProperty);
            
         OnConstruction();
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
               return Brightness;
            }
         }
         else
         {
            return Brightness;
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
               return Contrast;
            }
         }
         else
         {
            return Contrast;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Darken.fx.ps
   
   /// <summary>
   /// DarkenShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Darken.fx
   /// </summary>
   public sealed partial class DarkenShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<DarkenShaderEffect>();
   
      partial void OnConstruction();
      
      public DarkenShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(DarkenShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (DarkenShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Difference.fx.ps
   
   /// <summary>
   /// DifferenceShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Difference.fx
   /// </summary>
   public sealed partial class DifferenceShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<DifferenceShaderEffect>();
   
      partial void OnConstruction();
      
      public DifferenceShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
         UpdateShaderValue(MultiplierProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(DifferenceShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (DifferenceShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Multiplier
      public static System.Windows.DependencyProperty MultiplierProperty = System.Windows.DependencyProperty.Register(
         @"Multiplier",
         typeof(double),
         typeof(DifferenceShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(1),
            OnMultiplierCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnMultiplierCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnMultiplierCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (DifferenceShaderEffect)instance;
         var Multiplier = (double)baseValue;
       
         // Coerce
         Multiplier = Clamp(Multiplier, -1.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnMultiplierCoerceValue(
               Multiplier,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Multiplier;
            }
         }
         else
         {
            return Multiplier;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Multiplier (double)
      /// Multiplier to apply at end of calculation (can be used invert the result)
      /// Value coercion: Clamp(Multiplier, -1.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Multiplier
      {
         get
         {
            return (double)GetValue(MultiplierProperty);
         }
         set
         {
            SetValue(MultiplierProperty, value);
         }
      }

      // END_PROPERTY Multiplier
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\DirectionalBlur.fx.ps
   
   /// <summary>
   /// DirectionalBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: DirectionalBlur.fx
   /// </summary>
   public sealed partial class DirectionalBlurShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<DirectionalBlurShaderEffect>();
   
      partial void OnConstruction();
      
      public DirectionalBlurShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AngleProperty);
         UpdateShaderValue(BlurAmountProperty);
            
         OnConstruction();
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
               return Angle;
            }
         }
         else
         {
            return Angle;
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
               return BlurAmount;
            }
         }
         else
         {
            return BlurAmount;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Embossed.fx.ps
   
   /// <summary>
   /// EmbossedShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Embossed.fx
   /// </summary>
   public sealed partial class EmbossedShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<EmbossedShaderEffect>();
   
      partial void OnConstruction();
      
      public EmbossedShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
            
         OnConstruction();
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
               return Amount;
            }
         }
         else
         {
            return Amount;
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
               return Width;
            }
         }
         else
         {
            return Width;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\FadeTransition.fx.ps
   
   /// <summary>
   /// FadeTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: FadeTransition.fx
   /// </summary>
   public sealed partial class FadeTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<FadeTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public FadeTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(FadeTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (FadeTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Gloom.fx.ps
   
   /// <summary>
   /// GloomShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Gloom.fx
   /// </summary>
   public sealed partial class GloomShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<GloomShaderEffect>();
   
      partial void OnConstruction();
      
      public GloomShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(GloomIntensityProperty);
         UpdateShaderValue(BaseIntensityProperty);
         UpdateShaderValue(GloomSaturationProperty);
         UpdateShaderValue(BaseSaturationProperty);
            
         OnConstruction();
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
               return GloomIntensity;
            }
         }
         else
         {
            return GloomIntensity;
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
               return BaseIntensity;
            }
         }
         else
         {
            return BaseIntensity;
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
               return GloomSaturation;
            }
         }
         else
         {
            return GloomSaturation;
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
               return BaseSaturation;
            }
         }
         else
         {
            return BaseSaturation;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\GrowablePoissonDisk.fx.ps
   
   /// <summary>
   /// GrowablePoissonDiskShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: GrowablePoissonDisk.fx
   /// </summary>
   public sealed partial class GrowablePoissonDiskShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<GrowablePoissonDiskShaderEffect>();
   
      partial void OnConstruction();
      
      public GrowablePoissonDiskShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(DiscRadiusProperty);
         UpdateShaderValue(ScreenSizeProperty);
            
         OnConstruction();
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
               return DiscRadius;
            }
         }
         else
         {
            return DiscRadius;
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
               return ScreenSize;
            }
         }
         else
         {
            return ScreenSize;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Identity.fx.ps
   
   /// <summary>
   /// IdentityShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Identity.fx
   /// </summary>
   public sealed partial class IdentityShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<IdentityShaderEffect>();
   
      partial void OnConstruction();
      
      public IdentityShaderEffect()
         :  base(s_pixelShader)
      {
            
         OnConstruction();
      }
   
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\InvertColor.fx.ps
   
   /// <summary>
   /// InvertColorShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: InvertColor.fx
   /// </summary>
   public sealed partial class InvertColorShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<InvertColorShaderEffect>();
   
      partial void OnConstruction();
      
      public InvertColorShaderEffect()
         :  base(s_pixelShader)
      {
            
         OnConstruction();
      }
   
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\LeastBrightTransition.fx.ps
   
   /// <summary>
   /// LeastBrightTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: LeastBrightTransition.fx
   /// </summary>
   public sealed partial class LeastBrightTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<LeastBrightTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public LeastBrightTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(LeastBrightTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LeastBrightTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Lighten.fx.ps
   
   /// <summary>
   /// LightenShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Lighten.fx
   /// </summary>
   public sealed partial class LightenShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<LightenShaderEffect>();
   
      partial void OnConstruction();
      
      public LightenShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(LightenShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LightenShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\LightStreak.fx.ps
   
   /// <summary>
   /// LightStreakShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: LightStreak.fx
   /// </summary>
   public sealed partial class LightStreakShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<LightStreakShaderEffect>();
   
      partial void OnConstruction();
      
      public LightStreakShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(BrightThresholdProperty);
         UpdateShaderValue(ScaleProperty);
            
         OnConstruction();
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
               return BrightThreshold;
            }
         }
         else
         {
            return BrightThreshold;
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
               return Scale;
            }
         }
         else
         {
            return Scale;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\LineRevealTransition.fx.ps
   
   /// <summary>
   /// LineRevealTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: LineRevealTransition.fx
   /// </summary>
   public sealed partial class LineRevealTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<LineRevealTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public LineRevealTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(LineOriginProperty);
         UpdateShaderValue(LineNormalProperty);
         UpdateShaderValue(LineOffsetProperty);
         UpdateShaderValue(FuzzyAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(LineRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LineRevealTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY LineOrigin
      public static System.Windows.DependencyProperty LineOriginProperty = System.Windows.DependencyProperty.Register(
         @"LineOrigin",
         typeof(Point),
         typeof(LineRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1),
            OnLineOriginCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnLineOriginCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnLineOriginCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LineRevealTransitionShaderEffect)instance;
         var LineOrigin = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnLineOriginCoerceValue(
               LineOrigin,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return LineOrigin;
            }
         }
         else
         {
            return LineOrigin;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property LineOrigin (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point LineOrigin
      {
         get
         {
            return (Point)GetValue(LineOriginProperty);
         }
         set
         {
            SetValue(LineOriginProperty, value);
         }
      }

      // END_PROPERTY LineOrigin
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY LineNormal
      public static System.Windows.DependencyProperty LineNormalProperty = System.Windows.DependencyProperty.Register(
         @"LineNormal",
         typeof(Point),
         typeof(LineRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(2))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(2),
            OnLineNormalCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnLineNormalCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnLineNormalCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LineRevealTransitionShaderEffect)instance;
         var LineNormal = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnLineNormalCoerceValue(
               LineNormal,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return LineNormal;
            }
         }
         else
         {
            return LineNormal;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property LineNormal (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point LineNormal
      {
         get
         {
            return (Point)GetValue(LineNormalProperty);
         }
         set
         {
            SetValue(LineNormalProperty, value);
         }
      }

      // END_PROPERTY LineNormal
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY LineOffset
      public static System.Windows.DependencyProperty LineOffsetProperty = System.Windows.DependencyProperty.Register(
         @"LineOffset",
         typeof(Point),
         typeof(LineRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(3))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(3),
            OnLineOffsetCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnLineOffsetCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnLineOffsetCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LineRevealTransitionShaderEffect)instance;
         var LineOffset = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnLineOffsetCoerceValue(
               LineOffset,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return LineOffset;
            }
         }
         else
         {
            return LineOffset;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property LineOffset (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point LineOffset
      {
         get
         {
            return (Point)GetValue(LineOffsetProperty);
         }
         set
         {
            SetValue(LineOffsetProperty, value);
         }
      }

      // END_PROPERTY LineOffset
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY FuzzyAmount
      public static System.Windows.DependencyProperty FuzzyAmountProperty = System.Windows.DependencyProperty.Register(
         @"FuzzyAmount",
         typeof(double),
         typeof(LineRevealTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(4))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(4),
            OnFuzzyAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnFuzzyAmountCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnFuzzyAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (LineRevealTransitionShaderEffect)instance;
         var FuzzyAmount = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnFuzzyAmountCoerceValue(
               FuzzyAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return FuzzyAmount;
            }
         }
         else
         {
            return FuzzyAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property FuzzyAmount (double)
      /// Default Value: default(double)
      /// </summary>
      public double FuzzyAmount
      {
         get
         {
            return (double)GetValue(FuzzyAmountProperty);
         }
         set
         {
            SetValue(FuzzyAmountProperty, value);
         }
      }

      // END_PROPERTY FuzzyAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Magnify.fx.ps
   
   /// <summary>
   /// MagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Magnify.fx
   /// </summary>
   public sealed partial class MagnifyShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MagnifyShaderEffect>();
   
      partial void OnConstruction();
      
      public MagnifyShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(RadiiProperty);
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmountProperty);
            
         OnConstruction();
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
               return Radii;
            }
         }
         else
         {
            return Radii;
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return Amount;
            }
         }
         else
         {
            return Amount;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Monochrome.fx.ps
   
   /// <summary>
   /// MonochromeShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Monochrome.fx
   /// </summary>
   public sealed partial class MonochromeShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MonochromeShaderEffect>();
   
      partial void OnConstruction();
      
      public MonochromeShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(FilterColorProperty);
            
         OnConstruction();
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
               return FilterColor;
            }
         }
         else
         {
            return FilterColor;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\MostBrightTransition.fx.ps
   
   /// <summary>
   /// MostBrightTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: MostBrightTransition.fx
   /// </summary>
   public sealed partial class MostBrightTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MostBrightTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public MostBrightTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(MostBrightTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MostBrightTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Multiply.fx.ps
   
   /// <summary>
   /// MultiplyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Multiply.fx
   /// </summary>
   public sealed partial class MultiplyShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<MultiplyShaderEffect>();
   
      partial void OnConstruction();
      
      public MultiplyShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(MultiplyShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (MultiplyShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\NegationDifference.fx.ps
   
   /// <summary>
   /// NegationDifferenceShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: NegationDifference.fx
   /// </summary>
   public sealed partial class NegationDifferenceShaderEffect 
      : BaseTwoInputsShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<NegationDifferenceShaderEffect>();
   
      partial void OnConstruction();
      
      public NegationDifferenceShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AlphaProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Alpha
      public static System.Windows.DependencyProperty AlphaProperty = System.Windows.DependencyProperty.Register(
         @"Alpha",
         typeof(double),
         typeof(NegationDifferenceShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            1.0,
            PixelShaderConstantCallback(0),
            OnAlphaCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnAlphaCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnAlphaCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (NegationDifferenceShaderEffect)instance;
         var Alpha = (double)baseValue;
       
         // Coerce
         Alpha = Clamp(Alpha, 0.0, 1.0);
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnAlphaCoerceValue(
               Alpha,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Alpha;
            }
         }
         else
         {
            return Alpha;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Alpha (double)
      /// Amount of alpha applied on effect
      /// Value coercion: Clamp(Alpha, 0.0, 1.0)
      /// Default Value: 1.0
      /// </summary>
      public double Alpha
      {
         get
         {
            return (double)GetValue(AlphaProperty);
         }
         set
         {
            SetValue(AlphaProperty, value);
         }
      }

      // END_PROPERTY Alpha
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Pinch.fx.ps
   
   /// <summary>
   /// PinchShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pinch.fx
   /// </summary>
   public sealed partial class PinchShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PinchShaderEffect>();
   
      partial void OnConstruction();
      
      public PinchShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(RadiusProperty);
         UpdateShaderValue(AmountProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return Radius;
            }
         }
         else
         {
            return Radius;
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
               return Amount;
            }
         }
         else
         {
            return Amount;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Pixelate.fx.ps
   
   /// <summary>
   /// PixelateShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Pixelate.fx
   /// </summary>
   public sealed partial class PixelateShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PixelateShaderEffect>();
   
      partial void OnConstruction();
      
      public PixelateShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(PixelCountProperty);
            
         OnConstruction();
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
               return PixelCount;
            }
         }
         else
         {
            return PixelCount;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\PixelateInTransition.fx.ps
   
   /// <summary>
   /// PixelateInTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: PixelateInTransition.fx
   /// </summary>
   public sealed partial class PixelateInTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PixelateInTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public PixelateInTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(PixelateInTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateInTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\PixelateOutTransition.fx.ps
   
   /// <summary>
   /// PixelateOutTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: PixelateOutTransition.fx
   /// </summary>
   public sealed partial class PixelateOutTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PixelateOutTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public PixelateOutTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(PixelateOutTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateOutTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\PixelateTransition.fx.ps
   
   /// <summary>
   /// PixelateTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: PixelateTransition.fx
   /// </summary>
   public sealed partial class PixelateTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<PixelateTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public PixelateTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(PixelateTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (PixelateTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\RadialBlurTransition.fx.ps
   
   /// <summary>
   /// RadialBlurTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: RadialBlurTransition.fx
   /// </summary>
   public sealed partial class RadialBlurTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<RadialBlurTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public RadialBlurTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(RadialBlurTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RadialBlurTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Ripple.fx.ps
   
   /// <summary>
   /// RippleShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Ripple.fx
   /// </summary>
   public sealed partial class RippleShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<RippleShaderEffect>();
   
      partial void OnConstruction();
      
      public RippleShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(AmplitudeProperty);
         UpdateShaderValue(FrequencyProperty);
         UpdateShaderValue(PhaseProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return Amplitude;
            }
         }
         else
         {
            return Amplitude;
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
               return Frequency;
            }
         }
         else
         {
            return Frequency;
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
               return Phase;
            }
         }
         else
         {
            return Phase;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\RippleTransition.fx.ps
   
   /// <summary>
   /// RippleTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: RippleTransition.fx
   /// </summary>
   public sealed partial class RippleTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<RippleTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public RippleTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(RippleTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (RippleTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SaturateTransition.fx.ps
   
   /// <summary>
   /// SaturateTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SaturateTransition.fx
   /// </summary>
   public sealed partial class SaturateTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SaturateTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public SaturateTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(SaturateTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SaturateTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Sharpen.fx.ps
   
   /// <summary>
   /// SharpenShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Sharpen.fx
   /// </summary>
   public sealed partial class SharpenShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SharpenShaderEffect>();
   
      partial void OnConstruction();
      
      public SharpenShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(AmountProperty);
         UpdateShaderValue(WidthProperty);
         DdxUvDdyUvRegisterIndex = 2;
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Amount
      public static System.Windows.DependencyProperty AmountProperty = System.Windows.DependencyProperty.Register(
         @"Amount",
         typeof(double),
         typeof(SharpenShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.4,
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            0.4,
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
               return Amount;
            }
         }
         else
         {
            return Amount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Amount (double)
      /// Amount of sharpness
      /// Value coercion: Clamp(Amount, -1.0, 1.0)
      /// Default Value: 0.4
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
            2.0,
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            2.0,
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
         Width = Clamp(Width, 0.0, double.MaxValue);
      
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
               return Width;
            }
         }
         else
         {
            return Width;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Width (double)
      /// Width of sharpness in pixels
      /// Value coercion: Clamp(Width, 0.0, double.MaxValue)
      /// Default Value: 2.0
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
      
      // Skipped parameter: ddx_ddy as it's a DdxDdy register
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ShrinkTransition.fx.ps
   
   /// <summary>
   /// ShrinkTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ShrinkTransition.fx
   /// </summary>
   public sealed partial class ShrinkTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ShrinkTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public ShrinkTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(ShrinkTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (ShrinkTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SlideInTransition.fx.ps
   
   /// <summary>
   /// SlideInTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SlideInTransition.fx
   /// </summary>
   public sealed partial class SlideInTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SlideInTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public SlideInTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(SlideAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(SlideInTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SlideInTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY SlideAmount
      public static System.Windows.DependencyProperty SlideAmountProperty = System.Windows.DependencyProperty.Register(
         @"SlideAmount",
         typeof(Point),
         typeof(SlideInTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1),
            OnSlideAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnSlideAmountCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnSlideAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SlideInTransitionShaderEffect)instance;
         var SlideAmount = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnSlideAmountCoerceValue(
               SlideAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return SlideAmount;
            }
         }
         else
         {
            return SlideAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property SlideAmount (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point SlideAmount
      {
         get
         {
            return (Point)GetValue(SlideAmountProperty);
         }
         set
         {
            SetValue(SlideAmountProperty, value);
         }
      }

      // END_PROPERTY SlideAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SmoothMagnify.fx.ps
   
   /// <summary>
   /// SmoothMagnifyShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SmoothMagnify.fx
   /// </summary>
   public sealed partial class SmoothMagnifyShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SmoothMagnifyShaderEffect>();
   
      partial void OnConstruction();
      
      public SmoothMagnifyShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(InnerRadiusProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return InnerRadius;
            }
         }
         else
         {
            return InnerRadius;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SmoothSwirlGridTransition.fx.ps
   
   /// <summary>
   /// SmoothSwirlGridTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SmoothSwirlGridTransition.fx
   /// </summary>
   public sealed partial class SmoothSwirlGridTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SmoothSwirlGridTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public SmoothSwirlGridTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(TwistAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(SmoothSwirlGridTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SmoothSwirlGridTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY TwistAmount
      public static System.Windows.DependencyProperty TwistAmountProperty = System.Windows.DependencyProperty.Register(
         @"TwistAmount",
         typeof(Point),
         typeof(SmoothSwirlGridTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1),
            OnTwistAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnTwistAmountCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnTwistAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SmoothSwirlGridTransitionShaderEffect)instance;
         var TwistAmount = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnTwistAmountCoerceValue(
               TwistAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return TwistAmount;
            }
         }
         else
         {
            return TwistAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property TwistAmount (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point TwistAmount
      {
         get
         {
            return (Point)GetValue(TwistAmountProperty);
         }
         set
         {
            SetValue(TwistAmountProperty, value);
         }
      }

      // END_PROPERTY TwistAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Sobel.fx.ps
   
   /// <summary>
   /// SobelShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Sobel.fx
   /// </summary>
   public sealed partial class SobelShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SobelShaderEffect>();
   
      partial void OnConstruction();
      
      public SobelShaderEffect()
         :  base(s_pixelShader)
      {
         DdxUvDdyUvRegisterIndex = 2;
            
         OnConstruction();
      }
   
      // Skipped parameter: ddx_ddy as it's a DdxDdy register
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Swirl.fx.ps
   
   /// <summary>
   /// SwirlShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Swirl.fx
   /// </summary>
   public sealed partial class SwirlShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SwirlShaderEffect>();
   
      partial void OnConstruction();
      
      public SwirlShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(SpiralStrengthProperty);
         UpdateShaderValue(AngleFrequencyProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return SpiralStrength;
            }
         }
         else
         {
            return SpiralStrength;
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
               return AngleFrequency;
            }
         }
         else
         {
            return AngleFrequency;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SwirlGridTransition.fx.ps
   
   /// <summary>
   /// SwirlGridTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SwirlGridTransition.fx
   /// </summary>
   public sealed partial class SwirlGridTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SwirlGridTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public SwirlGridTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(TwistAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(SwirlGridTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlGridTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY TwistAmount
      public static System.Windows.DependencyProperty TwistAmountProperty = System.Windows.DependencyProperty.Register(
         @"TwistAmount",
         typeof(Point),
         typeof(SwirlGridTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1),
            OnTwistAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnTwistAmountCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnTwistAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlGridTransitionShaderEffect)instance;
         var TwistAmount = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnTwistAmountCoerceValue(
               TwistAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return TwistAmount;
            }
         }
         else
         {
            return TwistAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property TwistAmount (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point TwistAmount
      {
         get
         {
            return (Point)GetValue(TwistAmountProperty);
         }
         set
         {
            SetValue(TwistAmountProperty, value);
         }
      }

      // END_PROPERTY TwistAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\SwirlTransition.fx.ps
   
   /// <summary>
   /// SwirlTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: SwirlTransition.fx
   /// </summary>
   public sealed partial class SwirlTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<SwirlTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public SwirlTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(TwistAmountProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(SwirlTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY TwistAmount
      public static System.Windows.DependencyProperty TwistAmountProperty = System.Windows.DependencyProperty.Register(
         @"TwistAmount",
         typeof(Point),
         typeof(SwirlTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(Point),
            PixelShaderConstantCallback(1),
            OnTwistAmountCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnTwistAmountCoerceValue(
         Point baseValue,
         ref Point newValue,
         ref bool isProcessed
         );

      static object OnTwistAmountCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (SwirlTransitionShaderEffect)instance;
         var TwistAmount = (Point)baseValue;
      
         if(inst != null)
         {
            var newValue = default(Point);
            var isProcessed = false;
            inst.OnTwistAmountCoerceValue(
               TwistAmount,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return TwistAmount;
            }
         }
         else
         {
            return TwistAmount;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property TwistAmount (Point)
      /// Default Value: default(Point)
      /// </summary>
      public Point TwistAmount
      {
         get
         {
            return (Point)GetValue(TwistAmountProperty);
         }
         set
         {
            SetValue(TwistAmountProperty, value);
         }
      }

      // END_PROPERTY TwistAmount
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ToneMapping.fx.ps
   
   /// <summary>
   /// ToneMappingShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ToneMapping.fx
   /// </summary>
   public sealed partial class ToneMappingShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ToneMappingShaderEffect>();
   
      partial void OnConstruction();
      
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
            
         OnConstruction();
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
               return Exposure;
            }
         }
         else
         {
            return Exposure;
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
               return Defog;
            }
         }
         else
         {
            return Defog;
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
               return Gamma;
            }
         }
         else
         {
            return Gamma;
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
               return FogColor;
            }
         }
         else
         {
            return FogColor;
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
               return VignetteRadius;
            }
         }
         else
         {
            return VignetteRadius;
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
               return VignetteCenter;
            }
         }
         else
         {
            return VignetteCenter;
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
               return BlueShift;
            }
         }
         else
         {
            return BlueShift;
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
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\Toon.fx.ps
   
   /// <summary>
   /// ToonShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: Toon.fx
   /// </summary>
   public sealed partial class ToonShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ToonShaderEffect>();
   
      partial void OnConstruction();
      
      public ToonShaderEffect()
         :  base(s_pixelShader)
      {
            
         OnConstruction();
      }
   
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\WaterTransition.fx.ps
   
   /// <summary>
   /// WaterTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: WaterTransition.fx
   /// </summary>
   public sealed partial class WaterTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<WaterTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public WaterTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
         UpdateShaderValue(RandomSeedProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(WaterTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (WaterTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RandomSeed
      public static System.Windows.DependencyProperty RandomSeedProperty = System.Windows.DependencyProperty.Register(
         @"RandomSeed",
         typeof(double),
         typeof(WaterTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(1),
            OnRandomSeedCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnRandomSeedCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnRandomSeedCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (WaterTransitionShaderEffect)instance;
         var RandomSeed = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnRandomSeedCoerceValue(
               RandomSeed,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return RandomSeed;
            }
         }
         else
         {
            return RandomSeed;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property RandomSeed (double)
      /// Default Value: default(double)
      /// </summary>
      public double RandomSeed
      {
         get
         {
            return (double)GetValue(RandomSeedProperty);
         }
         set
         {
            SetValue(RandomSeedProperty, value);
         }
      }

      // END_PROPERTY RandomSeed
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\WaveTransition.fx.ps
   
   /// <summary>
   /// WaveTransitionShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: WaveTransition.fx
   /// </summary>
   public sealed partial class WaveTransitionShaderEffect 
      : BaseTwoInputsShaderEffect 
      , ITransitionShaderEffect
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<WaveTransitionShaderEffect>();
   
      partial void OnConstruction();
      
      public WaveTransitionShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(ProgressProperty);
            
         OnConstruction();
      }
   
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Progress
      public static System.Windows.DependencyProperty ProgressProperty = System.Windows.DependencyProperty.Register(
         @"Progress",
         typeof(double),
         typeof(WaveTransitionShaderEffect),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0))
#else
         new System.Windows.UIPropertyMetadata(
            default(double),
            PixelShaderConstantCallback(0),
            OnProgressCoerceValueStatic)
#endif
         );            

#if !SILVERLIGHT
      partial void OnProgressCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed
         );

      static object OnProgressCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var inst = (WaveTransitionShaderEffect)instance;
         var Progress = (double)baseValue;
      
         if(inst != null)
         {
            var newValue = default(double);
            var isProcessed = false;
            inst.OnProgressCoerceValue(
               Progress,
               ref newValue,
               ref isProcessed);
            if (isProcessed)
            {
               return newValue;
            }
            else
            {
               return Progress;
            }
         }
         else
         {
            return Progress;
         }
      }
#endif
      /// <summary>
      /// Gets or sets property Progress (double)
      /// Default Value: default(double)
      /// </summary>
      public double Progress
      {
         get
         {
            return (double)GetValue(ProgressProperty);
         }
         set
         {
            SetValue(ProgressProperty, value);
         }
      }

      // END_PROPERTY Progress
      // ----------------------------------------------------------------------
      
   
   }
   
   // Wrote to F:\Projects\wpfshadereffects\Shared\ShaderBinary\ZoomBlur.fx.ps
   
   /// <summary>
   /// ZoomBlurShaderEffect inherits System.Windows.Media.Effects.ShaderEffect
   /// This shader effect is based on the file: ZoomBlur.fx
   /// </summary>
   public sealed partial class ZoomBlurShaderEffect 
      : BaseSingleInputShaderEffect 
      
   {
      readonly static System.Windows.Media.Effects.PixelShader s_pixelShader = 
         Common.Utility.CreatePixelShader<ZoomBlurShaderEffect>();
   
      partial void OnConstruction();
      
      public ZoomBlurShaderEffect()
         :  base(s_pixelShader)
      {
         UpdateShaderValue(CenterProperty);
         UpdateShaderValue(BlurAmountProperty);
            
         OnConstruction();
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
               return Center;
            }
         }
         else
         {
            return Center;
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
               return BlurAmount;
            }
         }
         else
         {
            return BlurAmount;
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
