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
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace WpfShaderEffects.Experimental
{
   [TemplatePart(Name = "PART_Content", Type = typeof(ContentPresenter))]
   public partial class EffectRepeater : ContentControl
   {
      static EffectRepeater()
      {
         DefaultStyleKeyProperty.OverrideMetadata(
            typeof(EffectRepeater),
            new FrameworkPropertyMetadata(typeof(EffectRepeater)));
      }

      partial void OnBeforeContentEffectsCoerceValue(ObservableCollection<Effect> baseValue, ref ObservableCollection<Effect> newValue, ref bool isProcessed)
      {
         if (baseValue == null)
         {
            newValue = new ObservableCollection<Effect>();
            isProcessed = true;
         }
      }

      partial void OnAfterContentEffectsCoerceValue(ObservableCollection<Effect> baseValue, ref ObservableCollection<Effect> newValue, ref bool isProcessed)
      {
         if (baseValue == null)
         {
            newValue = new ObservableCollection<Effect>();
            isProcessed = true;
         }
      }

      public EffectRepeater()
      {
         CoerceAllDependencyProperties();
      }

   }
}
