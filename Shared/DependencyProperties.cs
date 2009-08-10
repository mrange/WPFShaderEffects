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

   
#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects
#endif
{

   // -------------------------------------------------------------------------
   // WpfShaderEffects.TransitionEffectMixer class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.TransitionEffectMixer class
   /// </summary>
   public sealed partial class TransitionEffectMixer
   {
      partial void OnConstruction();
      
      public TransitionEffectMixer()
      {
         CoerceAllDependencyProperties();
         OnConstruction();
      }
   
      public void CoerceAllDependencyProperties()
      {
         CoerceValue(LeftProperty);
         CoerceValue(RightProperty);
         CoerceValue(MixProperty);
         CoerceValue(TransitionShaderEffectProperty);
      
      }

      public void InvalidateAllDependencyProperties()
      {
         InvalidateProperty(LeftProperty);
         InvalidateProperty(RightProperty);
         InvalidateProperty(MixProperty);
         InvalidateProperty(TransitionShaderEffectProperty);
      
      }
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Left      
      
      public static System.Windows.DependencyProperty LeftProperty = System.Windows.DependencyProperty.Register(
         "Left",
         typeof(object),
         typeof(TransitionEffectMixer),
         new System.Windows.PropertyMetadata(
            null, 
            LeftPropertyChangedCallback, 
            LeftCoerceValueCallback));

   
                     
      partial void OnLeftPropertyChanged(
         object oldValue,
         object newValue,
         ref bool isProcessed);
         
      static void LeftPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (object)eventArgs.OldValue;
            var typedNewValue = (object)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnLeftPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnLeftCoerceValue(
         object baseValue,
         ref object newValue,
         ref bool isProcessed);
         
      static object LeftCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (object)baseValue;
            var typedNewValue = default(object);
            var isProcessed = false;
            typedInstance.OnLeftCoerceValue(
               typedBaseValue,
               ref typedNewValue,
               ref isProcessed);
            
            if (isProcessed)
            {
               return typedNewValue;
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
      /// Gets and sets Left (object)
      /// </summary>
      public object Left
      {
         get
         {
            return (object)GetValue(LeftProperty);
         }
         set
         {
            var currentValue = Left;
            if (currentValue != value)
            {
               SetValue(LeftProperty, value);
            }
         }
      }
   
      // END_PROPERTY Left
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Right      
      
      public static System.Windows.DependencyProperty RightProperty = System.Windows.DependencyProperty.Register(
         "Right",
         typeof(object),
         typeof(TransitionEffectMixer),
         new System.Windows.PropertyMetadata(
            null, 
            RightPropertyChangedCallback, 
            RightCoerceValueCallback));

   
                     
      partial void OnRightPropertyChanged(
         object oldValue,
         object newValue,
         ref bool isProcessed);
         
      static void RightPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (object)eventArgs.OldValue;
            var typedNewValue = (object)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRightPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnRightCoerceValue(
         object baseValue,
         ref object newValue,
         ref bool isProcessed);
         
      static object RightCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (object)baseValue;
            var typedNewValue = default(object);
            var isProcessed = false;
            typedInstance.OnRightCoerceValue(
               typedBaseValue,
               ref typedNewValue,
               ref isProcessed);
            
            if (isProcessed)
            {
               return typedNewValue;
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
      /// Gets and sets Right (object)
      /// </summary>
      public object Right
      {
         get
         {
            return (object)GetValue(RightProperty);
         }
         set
         {
            var currentValue = Right;
            if (currentValue != value)
            {
               SetValue(RightProperty, value);
            }
         }
      }
   
      // END_PROPERTY Right
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Mix      
      
      public static System.Windows.DependencyProperty MixProperty = System.Windows.DependencyProperty.Register(
         "Mix",
         typeof(double),
         typeof(TransitionEffectMixer),
         new System.Windows.PropertyMetadata(
            0.0, 
            MixPropertyChangedCallback, 
            MixCoerceValueCallback));

   
                     
      partial void OnMixPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void MixPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnMixPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnMixCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object MixCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnMixCoerceValue(
               typedBaseValue,
               ref typedNewValue,
               ref isProcessed);
            
            if (isProcessed)
            {
               return typedNewValue;
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
      /// Gets and sets Mix (double)
      /// </summary>
      public double Mix
      {
         get
         {
            return (double)GetValue(MixProperty);
         }
         set
         {
            var currentValue = Mix;
            if (currentValue != value)
            {
               SetValue(MixProperty, value);
            }
         }
      }
   
      // END_PROPERTY Mix
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY TransitionShaderEffect      
      
      public static System.Windows.DependencyProperty TransitionShaderEffectProperty = System.Windows.DependencyProperty.Register(
         "TransitionShaderEffect",
         typeof(ITransitionShaderEffect),
         typeof(TransitionEffectMixer),
         new System.Windows.PropertyMetadata(
            null, 
            TransitionShaderEffectPropertyChangedCallback, 
            TransitionShaderEffectCoerceValueCallback));

   
                     
      partial void OnTransitionShaderEffectPropertyChanged(
         ITransitionShaderEffect oldValue,
         ITransitionShaderEffect newValue,
         ref bool isProcessed);
         
      static void TransitionShaderEffectPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (ITransitionShaderEffect)eventArgs.OldValue;
            var typedNewValue = (ITransitionShaderEffect)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnTransitionShaderEffectPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnTransitionShaderEffectCoerceValue(
         ITransitionShaderEffect baseValue,
         ref ITransitionShaderEffect newValue,
         ref bool isProcessed);
         
      static object TransitionShaderEffectCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (TransitionEffectMixer)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (ITransitionShaderEffect)baseValue;
            var typedNewValue = default(ITransitionShaderEffect);
            var isProcessed = false;
            typedInstance.OnTransitionShaderEffectCoerceValue(
               typedBaseValue,
               ref typedNewValue,
               ref isProcessed);
            
            if (isProcessed)
            {
               return typedNewValue;
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
      /// Gets and sets TransitionShaderEffect (ITransitionShaderEffect)
      /// </summary>
      public ITransitionShaderEffect TransitionShaderEffect
      {
         get
         {
            return (ITransitionShaderEffect)GetValue(TransitionShaderEffectProperty);
         }
         set
         {
            var currentValue = TransitionShaderEffect;
            if (currentValue != value)
            {
               SetValue(TransitionShaderEffectProperty, value);
            }
         }
      }
   
      // END_PROPERTY TransitionShaderEffect
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------
}

