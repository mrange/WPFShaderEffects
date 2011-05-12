
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

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable HeuristicUnreachableCode
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable RedundantIfElseBlock

#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects.Experimental
#endif
{
   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.EffectStacker class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.EffectStacker class
   /// </summary>
   public sealed partial class EffectStacker
   {
      partial void OnConstruction();
      
      public EffectStacker()
      {
         CoerceValue (EffectsProperty);

         OnConstruction();
      }
      
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Effects      
      
      public static System.Windows.DependencyProperty EffectsProperty = System.Windows.DependencyProperty.Register(
         "Effects",
         typeof(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>),
         typeof(EffectStacker),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            null,
            EffectsPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            null, 
            EffectsPropertyChangedStatic,
            EffectsCoerceValueStatic));
#endif

   
                     
      partial void OnEffectsPropertyChanged(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> oldValue,
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static void EffectsPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (EffectStacker)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.OldValue;
            var typedNewValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnEffectsPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnEffectsCoerceValue(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> baseValue,
         ref System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static object EffectsCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (EffectStacker)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)baseValue;
            var typedNewValue = default(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>);
            var isProcessed = false;
            typedInstance.OnEffectsCoerceValue(
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
#endif
      /// <summary>
      /// Gets and sets Effects (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)
      /// </summary>
      public System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> Effects
      {
         get
         {
            return (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)GetValue(EffectsProperty);
         }
         set
         {
            var currentValue = Effects;
            if (currentValue != value)
            {
               SetValue(EffectsProperty, value);
            }
         }
      }
   
      // END_PROPERTY Effects
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.EffectRepeater class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.EffectRepeater class
   /// </summary>
   public sealed partial class EffectRepeater
   {
      partial void OnConstruction();
      
      public EffectRepeater()
      {
         CoerceValue (BeforeContentEffectsProperty);
         CoerceValue (AfterContentEffectsProperty);
         CoerceValue (ContentVisibilityProperty);

         OnConstruction();
      }
      
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY BeforeContentEffects      
      
      public static System.Windows.DependencyProperty BeforeContentEffectsProperty = System.Windows.DependencyProperty.Register(
         "BeforeContentEffects",
         typeof(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>),
         typeof(EffectRepeater),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            null,
            BeforeContentEffectsPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            null, 
            BeforeContentEffectsPropertyChangedStatic,
            BeforeContentEffectsCoerceValueStatic));
#endif

   
                     
      partial void OnBeforeContentEffectsPropertyChanged(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> oldValue,
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static void BeforeContentEffectsPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.OldValue;
            var typedNewValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnBeforeContentEffectsPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnBeforeContentEffectsCoerceValue(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> baseValue,
         ref System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static object BeforeContentEffectsCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)baseValue;
            var typedNewValue = default(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>);
            var isProcessed = false;
            typedInstance.OnBeforeContentEffectsCoerceValue(
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
#endif
      /// <summary>
      /// Gets and sets BeforeContentEffects (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)
      /// </summary>
      public System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> BeforeContentEffects
      {
         get
         {
            return (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)GetValue(BeforeContentEffectsProperty);
         }
         set
         {
            var currentValue = BeforeContentEffects;
            if (currentValue != value)
            {
               SetValue(BeforeContentEffectsProperty, value);
            }
         }
      }
   
      // END_PROPERTY BeforeContentEffects
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY AfterContentEffects      
      
      public static System.Windows.DependencyProperty AfterContentEffectsProperty = System.Windows.DependencyProperty.Register(
         "AfterContentEffects",
         typeof(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>),
         typeof(EffectRepeater),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            null,
            AfterContentEffectsPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            null, 
            AfterContentEffectsPropertyChangedStatic,
            AfterContentEffectsCoerceValueStatic));
#endif

   
                     
      partial void OnAfterContentEffectsPropertyChanged(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> oldValue,
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static void AfterContentEffectsPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.OldValue;
            var typedNewValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnAfterContentEffectsPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnAfterContentEffectsCoerceValue(
         System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> baseValue,
         ref System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> newValue,
         ref bool isProcessed);
         
      static object AfterContentEffectsCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)baseValue;
            var typedNewValue = default(System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>);
            var isProcessed = false;
            typedInstance.OnAfterContentEffectsCoerceValue(
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
#endif
      /// <summary>
      /// Gets and sets AfterContentEffects (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)
      /// </summary>
      public System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect> AfterContentEffects
      {
         get
         {
            return (System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.Effects.Effect>)GetValue(AfterContentEffectsProperty);
         }
         set
         {
            var currentValue = AfterContentEffects;
            if (currentValue != value)
            {
               SetValue(AfterContentEffectsProperty, value);
            }
         }
      }
   
      // END_PROPERTY AfterContentEffects
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY ContentVisibility      
      
      public static System.Windows.DependencyProperty ContentVisibilityProperty = System.Windows.DependencyProperty.Register(
         "ContentVisibility",
         typeof(System.Windows.Visibility),
         typeof(EffectRepeater),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            System.Windows.Visibility.Visible,
            ContentVisibilityPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            System.Windows.Visibility.Visible, 
            ContentVisibilityPropertyChangedStatic,
            ContentVisibilityCoerceValueStatic));
#endif

   
                     
      partial void OnContentVisibilityPropertyChanged(
         System.Windows.Visibility oldValue,
         System.Windows.Visibility newValue,
         ref bool isProcessed);
         
      static void ContentVisibilityPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Windows.Visibility)eventArgs.OldValue;
            var typedNewValue = (System.Windows.Visibility)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnContentVisibilityPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnContentVisibilityCoerceValue(
         System.Windows.Visibility baseValue,
         ref System.Windows.Visibility newValue,
         ref bool isProcessed);
         
      static object ContentVisibilityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (EffectRepeater)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Windows.Visibility)baseValue;
            var typedNewValue = default(System.Windows.Visibility);
            var isProcessed = false;
            typedInstance.OnContentVisibilityCoerceValue(
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
#endif
      /// <summary>
      /// Gets and sets ContentVisibility (System.Windows.Visibility)
      /// </summary>
      public System.Windows.Visibility ContentVisibility
      {
         get
         {
            return (System.Windows.Visibility)GetValue(ContentVisibilityProperty);
         }
         set
         {
            var currentValue = ContentVisibility;
            if (currentValue != value)
            {
               SetValue(ContentVisibilityProperty, value);
            }
         }
      }
   
      // END_PROPERTY ContentVisibility
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

}

