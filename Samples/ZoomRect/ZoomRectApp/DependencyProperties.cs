
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
namespace ZoomRectApp
#endif
{
   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.MainWindow class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.MainWindow class
   /// </summary>
   public sealed partial class MainWindow
   {
      partial void OnConstruction();
      
      public MainWindow()
      {

         OnConstruction();
      }
      
   }
   // -------------------------------------------------------------------------

   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.RegionOfInterest class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.RegionOfInterest class
   /// </summary>
   public sealed partial class RegionOfInterest
   {
      partial void OnConstruction();
      
      public RegionOfInterest()
      {
         CoerceValue (RoiVisibilityProperty);
         CoerceValue (RoiZoomProperty);
         CoerceValue (RoiZoomFactorProperty);
         CoerceValue (RoiX0Property);
         CoerceValue (RoiY0Property);
         CoerceValue (RoiX1Property);
         CoerceValue (RoiY1Property);
         CoerceValue (RoiCenterXProperty);
         CoerceValue (RoiCenterYProperty);
         CoerceValue (RoiLeftProperty);
         CoerceValue (RoiTopProperty);
         CoerceValue (RoiRightProperty);
         CoerceValue (RoiBottomProperty);
         CoerceValue (RoiWidthProperty);
         CoerceValue (RoiHeightProperty);
         CoerceValue (ShadersProperty);
         CoerceValue (CurrentShaderProperty);

         OnConstruction();
      }
      
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiVisibility      
      
      public static System.Windows.DependencyProperty RoiVisibilityProperty = System.Windows.DependencyProperty.Register(
         "RoiVisibility",
         typeof(System.Windows.Visibility),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            System.Windows.Visibility.Visible,
            RoiVisibilityPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            System.Windows.Visibility.Visible, 
            RoiVisibilityPropertyChangedStatic,
            RoiVisibilityCoerceValueStatic));
#endif

   
                     
      partial void OnRoiVisibilityPropertyChanged(
         System.Windows.Visibility oldValue,
         System.Windows.Visibility newValue,
         ref bool isProcessed);
         
      static void RoiVisibilityPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Windows.Visibility)eventArgs.OldValue;
            var typedNewValue = (System.Windows.Visibility)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiVisibilityPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiVisibilityCoerceValue(
         System.Windows.Visibility baseValue,
         ref System.Windows.Visibility newValue,
         ref bool isProcessed);
         
      static object RoiVisibilityCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Windows.Visibility)baseValue;
            var typedNewValue = default(System.Windows.Visibility);
            var isProcessed = false;
            typedInstance.OnRoiVisibilityCoerceValue(
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
      /// Gets and sets RoiVisibility (System.Windows.Visibility)
      /// </summary>
      public System.Windows.Visibility RoiVisibility
      {
         get
         {
            return (System.Windows.Visibility)GetValue(RoiVisibilityProperty);
         }
         set
         {
            var currentValue = RoiVisibility;
            if (currentValue != value)
            {
               SetValue(RoiVisibilityProperty, value);
            }
         }
      }
   
      // END_PROPERTY RoiVisibility
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiZoom      
      
      public static System.Windows.DependencyProperty RoiZoomProperty = System.Windows.DependencyProperty.Register(
         "RoiZoom",
         typeof(decimal),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.0M,
            RoiZoomPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            1.0M, 
            RoiZoomPropertyChangedStatic,
            RoiZoomCoerceValueStatic));
#endif

   
                     
      partial void OnRoiZoomPropertyChanged(
         decimal oldValue,
         decimal newValue,
         ref bool isProcessed);
         
      static void RoiZoomPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (decimal)eventArgs.OldValue;
            var typedNewValue = (decimal)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiZoomPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiZoomCoerceValue(
         decimal baseValue,
         ref decimal newValue,
         ref bool isProcessed);
         
      static object RoiZoomCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (decimal)baseValue;
            var typedNewValue = default(decimal);
            var isProcessed = false;
            typedInstance.OnRoiZoomCoerceValue(
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
      /// Gets and sets RoiZoom (decimal)
      /// </summary>
      public decimal RoiZoom
      {
         get
         {
            return (decimal)GetValue(RoiZoomProperty);
         }
         set
         {
            var currentValue = RoiZoom;
            if (currentValue != value)
            {
               SetValue(RoiZoomProperty, value);
            }
         }
      }
   
      // END_PROPERTY RoiZoom
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiZoomFactor      
      
      public static System.Windows.DependencyProperty RoiZoomFactorProperty = System.Windows.DependencyProperty.Register(
         "RoiZoomFactor",
         typeof(decimal),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            1.2M,
            RoiZoomFactorPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            1.2M, 
            RoiZoomFactorPropertyChangedStatic,
            RoiZoomFactorCoerceValueStatic));
#endif

   
                     
      partial void OnRoiZoomFactorPropertyChanged(
         decimal oldValue,
         decimal newValue,
         ref bool isProcessed);
         
      static void RoiZoomFactorPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (decimal)eventArgs.OldValue;
            var typedNewValue = (decimal)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiZoomFactorPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiZoomFactorCoerceValue(
         decimal baseValue,
         ref decimal newValue,
         ref bool isProcessed);
         
      static object RoiZoomFactorCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (decimal)baseValue;
            var typedNewValue = default(decimal);
            var isProcessed = false;
            typedInstance.OnRoiZoomFactorCoerceValue(
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
      /// Gets and sets RoiZoomFactor (decimal)
      /// </summary>
      public decimal RoiZoomFactor
      {
         get
         {
            return (decimal)GetValue(RoiZoomFactorProperty);
         }
         set
         {
            var currentValue = RoiZoomFactor;
            if (currentValue != value)
            {
               SetValue(RoiZoomFactorProperty, value);
            }
         }
      }
   
      // END_PROPERTY RoiZoomFactor
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiX0      
      
      public static System.Windows.DependencyProperty RoiX0Property = System.Windows.DependencyProperty.Register(
         "RoiX0",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiX0PropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiX0PropertyChangedStatic,
            RoiX0CoerceValueStatic));
#endif

   
                     
      partial void OnRoiX0PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiX0PropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiX0PropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiX0CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiX0CoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiX0CoerceValue(
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
      /// Gets and sets RoiX0 (double)
      /// </summary>
      public double RoiX0
      {
         get
         {
            return (double)GetValue(RoiX0Property);
         }
         set
         {
            var currentValue = RoiX0;
            if (currentValue != value)
            {
               SetValue(RoiX0Property, value);
            }
         }
      }
   
      // END_PROPERTY RoiX0
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiY0      
      
      public static System.Windows.DependencyProperty RoiY0Property = System.Windows.DependencyProperty.Register(
         "RoiY0",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiY0PropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiY0PropertyChangedStatic,
            RoiY0CoerceValueStatic));
#endif

   
                     
      partial void OnRoiY0PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiY0PropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiY0PropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiY0CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiY0CoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiY0CoerceValue(
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
      /// Gets and sets RoiY0 (double)
      /// </summary>
      public double RoiY0
      {
         get
         {
            return (double)GetValue(RoiY0Property);
         }
         set
         {
            var currentValue = RoiY0;
            if (currentValue != value)
            {
               SetValue(RoiY0Property, value);
            }
         }
      }
   
      // END_PROPERTY RoiY0
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiX1      
      
      public static System.Windows.DependencyProperty RoiX1Property = System.Windows.DependencyProperty.Register(
         "RoiX1",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiX1PropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiX1PropertyChangedStatic,
            RoiX1CoerceValueStatic));
#endif

   
                     
      partial void OnRoiX1PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiX1PropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiX1PropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiX1CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiX1CoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiX1CoerceValue(
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
      /// Gets and sets RoiX1 (double)
      /// </summary>
      public double RoiX1
      {
         get
         {
            return (double)GetValue(RoiX1Property);
         }
         set
         {
            var currentValue = RoiX1;
            if (currentValue != value)
            {
               SetValue(RoiX1Property, value);
            }
         }
      }
   
      // END_PROPERTY RoiX1
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiY1      
      
      public static System.Windows.DependencyProperty RoiY1Property = System.Windows.DependencyProperty.Register(
         "RoiY1",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiY1PropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiY1PropertyChangedStatic,
            RoiY1CoerceValueStatic));
#endif

   
                     
      partial void OnRoiY1PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiY1PropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiY1PropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiY1CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiY1CoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiY1CoerceValue(
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
      /// Gets and sets RoiY1 (double)
      /// </summary>
      public double RoiY1
      {
         get
         {
            return (double)GetValue(RoiY1Property);
         }
         set
         {
            var currentValue = RoiY1;
            if (currentValue != value)
            {
               SetValue(RoiY1Property, value);
            }
         }
      }
   
      // END_PROPERTY RoiY1
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiCenterX      
      
      public static System.Windows.DependencyProperty RoiCenterXProperty = System.Windows.DependencyProperty.Register(
         "RoiCenterX",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiCenterXPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiCenterXPropertyChangedStatic,
            RoiCenterXCoerceValueStatic));
#endif

   
                     
      partial void OnRoiCenterXPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiCenterXPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiCenterXPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiCenterXCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiCenterXCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiCenterXCoerceValue(
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
      /// Gets and sets RoiCenterX (double)
      /// </summary>
      public double RoiCenterX
      {
         get
         {
            return (double)GetValue(RoiCenterXProperty);
         }
         set
         {
            var currentValue = RoiCenterX;
            if (currentValue != value)
            {
               SetValue(RoiCenterXProperty, value);
            }
         }
      }
   
      // END_PROPERTY RoiCenterX
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiCenterY      
      
      public static System.Windows.DependencyProperty RoiCenterYProperty = System.Windows.DependencyProperty.Register(
         "RoiCenterY",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            RoiCenterYPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            RoiCenterYPropertyChangedStatic,
            RoiCenterYCoerceValueStatic));
#endif

   
                     
      partial void OnRoiCenterYPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiCenterYPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnRoiCenterYPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnRoiCenterYCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiCenterYCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiCenterYCoerceValue(
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
      /// Gets and sets RoiCenterY (double)
      /// </summary>
      public double RoiCenterY
      {
         get
         {
            return (double)GetValue(RoiCenterYProperty);
         }
         set
         {
            var currentValue = RoiCenterY;
            if (currentValue != value)
            {
               SetValue(RoiCenterYProperty, value);
            }
         }
      }
   
      // END_PROPERTY RoiCenterY
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiLeft      
      
      static System.Windows.DependencyPropertyKey RoiLeftPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiLeft",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiLeftCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiLeftProperty = 
         RoiLeftPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiLeftCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiLeftCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiLeftCoerceValue(
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
      /// Gets RoiLeft (double)
      /// </summary>
      public double RoiLeft
      {
         get
         {
            return (double)GetValue(RoiLeftProperty);
         }
         private set
         {
            var currentValue = RoiLeft;
            if (currentValue != value)
            {
               SetValue(RoiLeftPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiLeft
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiTop      
      
      static System.Windows.DependencyPropertyKey RoiTopPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiTop",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiTopCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiTopProperty = 
         RoiTopPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiTopCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiTopCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiTopCoerceValue(
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
      /// Gets RoiTop (double)
      /// </summary>
      public double RoiTop
      {
         get
         {
            return (double)GetValue(RoiTopProperty);
         }
         private set
         {
            var currentValue = RoiTop;
            if (currentValue != value)
            {
               SetValue(RoiTopPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiTop
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiRight      
      
      static System.Windows.DependencyPropertyKey RoiRightPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiRight",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiRightCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiRightProperty = 
         RoiRightPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiRightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiRightCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiRightCoerceValue(
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
      /// Gets RoiRight (double)
      /// </summary>
      public double RoiRight
      {
         get
         {
            return (double)GetValue(RoiRightProperty);
         }
         private set
         {
            var currentValue = RoiRight;
            if (currentValue != value)
            {
               SetValue(RoiRightPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiRight
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiBottom      
      
      static System.Windows.DependencyPropertyKey RoiBottomPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiBottom",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiBottomCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiBottomProperty = 
         RoiBottomPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiBottomCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiBottomCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiBottomCoerceValue(
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
      /// Gets RoiBottom (double)
      /// </summary>
      public double RoiBottom
      {
         get
         {
            return (double)GetValue(RoiBottomProperty);
         }
         private set
         {
            var currentValue = RoiBottom;
            if (currentValue != value)
            {
               SetValue(RoiBottomPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiBottom
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiWidth      
      
      static System.Windows.DependencyPropertyKey RoiWidthPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiWidth",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiWidthCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiWidthProperty = 
         RoiWidthPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiWidthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiWidthCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiWidthCoerceValue(
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
      /// Gets RoiWidth (double)
      /// </summary>
      public double RoiWidth
      {
         get
         {
            return (double)GetValue(RoiWidthProperty);
         }
         private set
         {
            var currentValue = RoiWidth;
            if (currentValue != value)
            {
               SetValue(RoiWidthPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiWidth
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiHeight      
      
      static System.Windows.DependencyPropertyKey RoiHeightPropertyKey = System.Windows.DependencyProperty.RegisterReadOnly(
         "RoiHeight",
         typeof(double),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            null));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            null,
            RoiHeightCoerceValueStatic));
#endif

      public static System.Windows.DependencyProperty RoiHeightProperty = 
         RoiHeightPropertyKey.DependencyProperty;

   
   
#if !SILVERLIGHT
      partial void OnRoiHeightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiHeightCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnRoiHeightCoerceValue(
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
      /// Gets RoiHeight (double)
      /// </summary>
      public double RoiHeight
      {
         get
         {
            return (double)GetValue(RoiHeightProperty);
         }
         private set
         {
            var currentValue = RoiHeight;
            if (currentValue != value)
            {
               SetValue(RoiHeightPropertyKey, value);
            }
         }
      }
   
      // END_PROPERTY RoiHeight
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Shaders      
      
      public static System.Windows.DependencyProperty ShadersProperty = System.Windows.DependencyProperty.Register(
         "Shaders",
         typeof(System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>),
            ShadersPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            default(System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>), 
            ShadersPropertyChangedStatic,
            ShadersCoerceValueStatic));
#endif

   
                     
      partial void OnShadersPropertyChanged(
         System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo> oldValue,
         System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo> newValue,
         ref bool isProcessed);
         
      static void ShadersPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>)eventArgs.OldValue;
            var typedNewValue = (System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnShadersPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnShadersCoerceValue(
         System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo> baseValue,
         ref System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo> newValue,
         ref bool isProcessed);
         
      static object ShadersCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>)baseValue;
            var typedNewValue = default(System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>);
            var isProcessed = false;
            typedInstance.OnShadersCoerceValue(
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
      /// Gets and sets Shaders (System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>)
      /// </summary>
      public System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo> Shaders
      {
         get
         {
            return (System.Collections.ObjectModel.ObservableCollection<ZoomRectApp.ShaderEffectInfo>)GetValue(ShadersProperty);
         }
         set
         {
            var currentValue = Shaders;
            if (currentValue != value)
            {
               SetValue(ShadersProperty, value);
            }
         }
      }
   
      // END_PROPERTY Shaders
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY CurrentShader      
      
      public static System.Windows.DependencyProperty CurrentShaderProperty = System.Windows.DependencyProperty.Register(
         "CurrentShader",
         typeof(ZoomRectApp.ShaderEffectInfo),
         typeof(RegionOfInterest),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(ZoomRectApp.ShaderEffectInfo),
            CurrentShaderPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            default(ZoomRectApp.ShaderEffectInfo), 
            CurrentShaderPropertyChangedStatic,
            CurrentShaderCoerceValueStatic));
#endif

   
                     
      partial void OnCurrentShaderPropertyChanged(
         ZoomRectApp.ShaderEffectInfo oldValue,
         ZoomRectApp.ShaderEffectInfo newValue,
         ref bool isProcessed);
         
      static void CurrentShaderPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (ZoomRectApp.ShaderEffectInfo)eventArgs.OldValue;
            var typedNewValue = (ZoomRectApp.ShaderEffectInfo)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnCurrentShaderPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnCurrentShaderCoerceValue(
         ZoomRectApp.ShaderEffectInfo baseValue,
         ref ZoomRectApp.ShaderEffectInfo newValue,
         ref bool isProcessed);
         
      static object CurrentShaderCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (RegionOfInterest)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (ZoomRectApp.ShaderEffectInfo)baseValue;
            var typedNewValue = default(ZoomRectApp.ShaderEffectInfo);
            var isProcessed = false;
            typedInstance.OnCurrentShaderCoerceValue(
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
      /// Gets and sets CurrentShader (ZoomRectApp.ShaderEffectInfo)
      /// </summary>
      public ZoomRectApp.ShaderEffectInfo CurrentShader
      {
         get
         {
            return (ZoomRectApp.ShaderEffectInfo)GetValue(CurrentShaderProperty);
         }
         set
         {
            var currentValue = CurrentShader;
            if (currentValue != value)
            {
               SetValue(CurrentShaderProperty, value);
            }
         }
      }
   
      // END_PROPERTY CurrentShader
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.ShaderEffectInfo class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.ShaderEffectInfo class
   /// </summary>
   public sealed partial class ShaderEffectInfo
   {
      partial void OnConstruction();
      
      public ShaderEffectInfo()
      {
         CoerceValue (NameProperty);
         CoerceValue (ShaderEffectProperty);

         OnConstruction();
      }
      
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Name      
      
      public static System.Windows.DependencyProperty NameProperty = System.Windows.DependencyProperty.Register(
         "Name",
         typeof(string),
         typeof(ShaderEffectInfo),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(string),
            NamePropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            default(string), 
            NamePropertyChangedStatic,
            NameCoerceValueStatic));
#endif

   
                     
      partial void OnNamePropertyChanged(
         string oldValue,
         string newValue,
         ref bool isProcessed);
         
      static void NamePropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (string)eventArgs.OldValue;
            var typedNewValue = (string)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnNamePropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnNameCoerceValue(
         string baseValue,
         ref string newValue,
         ref bool isProcessed);
         
      static object NameCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (string)baseValue;
            var typedNewValue = default(string);
            var isProcessed = false;
            typedInstance.OnNameCoerceValue(
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
      /// Gets and sets Name (string)
      /// </summary>
      public string Name
      {
         get
         {
            return (string)GetValue(NameProperty);
         }
         set
         {
            var currentValue = Name;
            if (currentValue != value)
            {
               SetValue(NameProperty, value);
            }
         }
      }
   
      // END_PROPERTY Name
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY ShaderEffect      
      
      public static System.Windows.DependencyProperty ShaderEffectProperty = System.Windows.DependencyProperty.Register(
         "ShaderEffect",
         typeof(System.Windows.Media.Effects.ShaderEffect),
         typeof(ShaderEffectInfo),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Effects.ShaderEffect),
            ShaderEffectPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            default(System.Windows.Media.Effects.ShaderEffect), 
            ShaderEffectPropertyChangedStatic,
            ShaderEffectCoerceValueStatic));
#endif

   
                     
      partial void OnShaderEffectPropertyChanged(
         System.Windows.Media.Effects.ShaderEffect oldValue,
         System.Windows.Media.Effects.ShaderEffect newValue,
         ref bool isProcessed);
         
      static void ShaderEffectPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (System.Windows.Media.Effects.ShaderEffect)eventArgs.OldValue;
            var typedNewValue = (System.Windows.Media.Effects.ShaderEffect)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnShaderEffectPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnShaderEffectCoerceValue(
         System.Windows.Media.Effects.ShaderEffect baseValue,
         ref System.Windows.Media.Effects.ShaderEffect newValue,
         ref bool isProcessed);
         
      static object ShaderEffectCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Windows.Media.Effects.ShaderEffect)baseValue;
            var typedNewValue = default(System.Windows.Media.Effects.ShaderEffect);
            var isProcessed = false;
            typedInstance.OnShaderEffectCoerceValue(
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
      /// Gets and sets ShaderEffect (System.Windows.Media.Effects.ShaderEffect)
      /// </summary>
      public System.Windows.Media.Effects.ShaderEffect ShaderEffect
      {
         get
         {
            return (System.Windows.Media.Effects.ShaderEffect)GetValue(ShaderEffectProperty);
         }
         set
         {
            var currentValue = ShaderEffect;
            if (currentValue != value)
            {
               SetValue(ShaderEffectProperty, value);
            }
         }
      }
   
      // END_PROPERTY ShaderEffect
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

   
   // -------------------------------------------------------------------------
   // WpfShaderEffects.MouseDragBehavior class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfShaderEffects.MouseDragBehavior class
   /// </summary>
   public sealed partial class MouseDragBehavior
   {
      partial void OnConstruction();
      
      public MouseDragBehavior()
      {
         CoerceValue (XProperty);
         CoerceValue (YProperty);

         OnConstruction();
      }
      
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY X      
      
      public static System.Windows.DependencyProperty XProperty = System.Windows.DependencyProperty.Register(
         "X",
         typeof(double),
         typeof(MouseDragBehavior),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            XPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            XPropertyChangedStatic,
            XCoerceValueStatic));
#endif

   
                     
      partial void OnXPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void XPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnXPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnXCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object XCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnXCoerceValue(
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
      /// Gets and sets X (double)
      /// </summary>
      public double X
      {
         get
         {
            return (double)GetValue(XProperty);
         }
         set
         {
            var currentValue = X;
            if (currentValue != value)
            {
               SetValue(XProperty, value);
            }
         }
      }
   
      // END_PROPERTY X
      // ----------------------------------------------------------------------
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Y      
      
      public static System.Windows.DependencyProperty YProperty = System.Windows.DependencyProperty.Register(
         "Y",
         typeof(double),
         typeof(MouseDragBehavior),
#if SILVERLIGHT
         new System.Windows.PropertyMetadata(
            0.0,
            YPropertyChangedStatic));
#else
         new System.Windows.UIPropertyMetadata(
            0.0, 
            YPropertyChangedStatic,
            YCoerceValueStatic));
#endif

   
                     
      partial void OnYPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void YPropertyChangedStatic(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null)
         {
            var typedOldValue = (double)eventArgs.OldValue;
            var typedNewValue = (double)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnYPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
#if !SILVERLIGHT
      partial void OnYCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object YCoerceValueStatic(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (double)baseValue;
            var typedNewValue = default(double);
            var isProcessed = false;
            typedInstance.OnYCoerceValue(
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
      /// Gets and sets Y (double)
      /// </summary>
      public double Y
      {
         get
         {
            return (double)GetValue(YProperty);
         }
         set
         {
            var currentValue = Y;
            if (currentValue != value)
            {
               SetValue(YProperty, value);
            }
         }
      }
   
      // END_PROPERTY Y
      // ----------------------------------------------------------------------
   }
   // -------------------------------------------------------------------------

}

