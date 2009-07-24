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

   
namespace WpfApplication4
{

   // -------------------------------------------------------------------------
   // WpfApplication4.MainWindow class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfApplication4.MainWindow class
   /// </summary>
   public sealed partial class MainWindow
   {
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Shaders      
      
      public static System.Windows.DependencyProperty ShadersProperty = System.Windows.DependencyProperty.Register(
         "Shaders",
         typeof(System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>),
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            default(System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>), 
            ShadersPropertyChangedCallback, 
            ShadersCoerceValueCallback));

   
                     
      partial void OnShadersPropertyChanged(
         System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo> oldValue,
         System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo> newValue,
         ref bool isProcessed);
         
      static void ShadersPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>)eventArgs.OldValue;
            var typedNewValue = (System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnShadersPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnShadersCoerceValue(
         System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo> baseValue,
         ref System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo> newValue,
         ref bool isProcessed);
         
      static object ShadersCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>)baseValue;
            var typedNewValue = default(System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>);
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

      /// <summary>
      /// Gets and sets Shaders (System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>)
      /// </summary>
      public System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo> Shaders
      {
         get
         {
            return (System.Collections.ObjectModel.ObservableCollection<WpfApplication4.ShaderEffectInfo>)GetValue(ShadersProperty);
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
         typeof(WpfApplication4.ShaderEffectInfo),
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            default(WpfApplication4.ShaderEffectInfo), 
            CurrentShaderPropertyChangedCallback, 
            CurrentShaderCoerceValueCallback));

   
                     
      partial void OnCurrentShaderPropertyChanged(
         WpfApplication4.ShaderEffectInfo oldValue,
         WpfApplication4.ShaderEffectInfo newValue,
         ref bool isProcessed);
         
      static void CurrentShaderPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
         {
            var typedOldValue = (WpfApplication4.ShaderEffectInfo)eventArgs.OldValue;
            var typedNewValue = (WpfApplication4.ShaderEffectInfo)eventArgs.NewValue;
            
            var isProcessed = false;
            
            typedInstance.OnCurrentShaderPropertyChanged(
               typedOldValue,
               typedNewValue,
               ref isProcessed);
            
         }
      }
   
      partial void OnCurrentShaderCoerceValue(
         WpfApplication4.ShaderEffectInfo baseValue,
         ref WpfApplication4.ShaderEffectInfo newValue,
         ref bool isProcessed);
         
      static object CurrentShaderCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null)
         {
            var typedBaseValue = (WpfApplication4.ShaderEffectInfo)baseValue;
            var typedNewValue = default(WpfApplication4.ShaderEffectInfo);
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

      /// <summary>
      /// Gets and sets CurrentShader (WpfApplication4.ShaderEffectInfo)
      /// </summary>
      public WpfApplication4.ShaderEffectInfo CurrentShader
      {
         get
         {
            return (WpfApplication4.ShaderEffectInfo)GetValue(CurrentShaderProperty);
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
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY RoiX0      
      
      public static System.Windows.DependencyProperty RoiX0Property = System.Windows.DependencyProperty.Register(
         "RoiX0",
         typeof(double),
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiX0PropertyChangedCallback, 
            RoiX0CoerceValueCallback));

   
                     
      partial void OnRoiX0PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiX0PropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiX0CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiX0CoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiY0PropertyChangedCallback, 
            RoiY0CoerceValueCallback));

   
                     
      partial void OnRoiY0PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiY0PropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiY0CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiY0CoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiX1PropertyChangedCallback, 
            RoiX1CoerceValueCallback));

   
                     
      partial void OnRoiX1PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiX1PropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiX1CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiX1CoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiY1PropertyChangedCallback, 
            RoiY1CoerceValueCallback));

   
                     
      partial void OnRoiY1PropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiY1PropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiY1CoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiY1CoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiCenterXPropertyChangedCallback, 
            RoiCenterXCoerceValueCallback));

   
                     
      partial void OnRoiCenterXPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiCenterXPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiCenterXCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiCenterXCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
            RoiCenterYPropertyChangedCallback, 
            RoiCenterYCoerceValueCallback));

   
                     
      partial void OnRoiCenterYPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void RoiCenterYPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MainWindow)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnRoiCenterYCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiCenterYCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiLeftCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiLeftProperty = 
         RoiLeftPropertyKey.DependencyProperty;

   
   
      partial void OnRoiLeftCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiLeftCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiTopCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiTopProperty = 
         RoiTopPropertyKey.DependencyProperty;

   
   
      partial void OnRoiTopCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiTopCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiRightCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiRightProperty = 
         RoiRightPropertyKey.DependencyProperty;

   
   
      partial void OnRoiRightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiRightCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiBottomCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiBottomProperty = 
         RoiBottomPropertyKey.DependencyProperty;

   
   
      partial void OnRoiBottomCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiBottomCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiWidthCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiWidthProperty = 
         RoiWidthPropertyKey.DependencyProperty;

   
   
      partial void OnRoiWidthCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiWidthCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
         typeof(MainWindow),
         new System.Windows.PropertyMetadata(
            0.0, 
                     
            null, 
            RoiHeightCoerceValueCallback));

      public static System.Windows.DependencyProperty RoiHeightProperty = 
         RoiHeightPropertyKey.DependencyProperty;

   
   
      partial void OnRoiHeightCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object RoiHeightCoerceValueCallback(
         System.Windows.DependencyObject instance, 
         object baseValue)
      {
         var typedInstance = (MainWindow)instance;
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
   }
   // -------------------------------------------------------------------------
}

   
namespace WpfApplication4
{

   // -------------------------------------------------------------------------
   // WpfApplication4.ShaderEffectInfo class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfApplication4.ShaderEffectInfo class
   /// </summary>
   public sealed partial class ShaderEffectInfo
   {
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY Name      
      
      public static System.Windows.DependencyProperty NameProperty = System.Windows.DependencyProperty.Register(
         "Name",
         typeof(string),
         typeof(ShaderEffectInfo),
         new System.Windows.PropertyMetadata(
            default(string), 
            NamePropertyChangedCallback, 
            NameCoerceValueCallback));

   
                     
      partial void OnNamePropertyChanged(
         string oldValue,
         string newValue,
         ref bool isProcessed);
         
      static void NamePropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnNameCoerceValue(
         string baseValue,
         ref string newValue,
         ref bool isProcessed);
         
      static object NameCoerceValueCallback(
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
         new System.Windows.PropertyMetadata(
            default(System.Windows.Media.Effects.ShaderEffect), 
            ShaderEffectPropertyChangedCallback, 
            ShaderEffectCoerceValueCallback));

   
                     
      partial void OnShaderEffectPropertyChanged(
         System.Windows.Media.Effects.ShaderEffect oldValue,
         System.Windows.Media.Effects.ShaderEffect newValue,
         ref bool isProcessed);
         
      static void ShaderEffectPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (ShaderEffectInfo)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnShaderEffectCoerceValue(
         System.Windows.Media.Effects.ShaderEffect baseValue,
         ref System.Windows.Media.Effects.ShaderEffect newValue,
         ref bool isProcessed);
         
      static object ShaderEffectCoerceValueCallback(
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
}

   
namespace WpfApplication4
{

   // -------------------------------------------------------------------------
   // WpfApplication4.MouseDragBehavior class
   // -------------------------------------------------------------------------
   /// <summary>
   /// WpfApplication4.MouseDragBehavior class
   /// </summary>
   public sealed partial class MouseDragBehavior
   {
      
      // ----------------------------------------------------------------------
      // BEGIN_PROPERTY X      
      
      public static System.Windows.DependencyProperty XProperty = System.Windows.DependencyProperty.Register(
         "X",
         typeof(double),
         typeof(MouseDragBehavior),
         new System.Windows.PropertyMetadata(
            0.0, 
            XPropertyChangedCallback, 
            XCoerceValueCallback));

   
                     
      partial void OnXPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void XPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnXCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object XCoerceValueCallback(
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
         new System.Windows.PropertyMetadata(
            0.0, 
            YPropertyChangedCallback, 
            YCoerceValueCallback));

   
                     
      partial void OnYPropertyChanged(
         double oldValue,
         double newValue,
         ref bool isProcessed);
         
      static void YPropertyChangedCallback(
         System.Windows.DependencyObject instance, 
         System.Windows.DependencyPropertyChangedEventArgs eventArgs)
      {
         var typedInstance = (MouseDragBehavior)instance;
         if (typedInstance != null && eventArgs != null)
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
   
      partial void OnYCoerceValue(
         double baseValue,
         ref double newValue,
         ref bool isProcessed);
         
      static object YCoerceValueCallback(
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

