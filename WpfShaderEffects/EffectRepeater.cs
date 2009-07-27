using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace WpfShaderEffects
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
