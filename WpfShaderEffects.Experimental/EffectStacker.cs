﻿/* ****************************************************************************
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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace WpfShaderEffects.Experimental
{
   [TemplatePart(Name = "PART_Root", Type = typeof(ContentControl))]
   [TemplatePart(Name = "PART_Content", Type = typeof(ContentPresenter))]
   public partial class EffectStacker : ContentControl
   {
      static EffectStacker()
      {
         DefaultStyleKeyProperty.OverrideMetadata(
            typeof(EffectStacker),
            new FrameworkPropertyMetadata(typeof(EffectStacker)));
      }

      ContentPresenter m_contentPresenter;
      ContentControl m_root;

      partial void OnEffectsCoerceValue(ObservableCollection<Effect> baseValue, ref ObservableCollection<Effect> newValue, ref bool isProcessed)
      {
         if(baseValue == null)
         {
            newValue = new ObservableCollection<Effect>();
            isProcessed = true;
         }
      }

      partial void OnEffectsPropertyChanged(ObservableCollection<Effect> oldValue, ObservableCollection<Effect> newValue, ref bool isProcessed)
      {
         if (oldValue != null)
         {
            oldValue.CollectionChanged -= OnCollectionChanged;
         }
         if (oldValue != null)
         {
            newValue.CollectionChanged += OnCollectionChanged;
         }
         RebuildEffectTree();
      }

      void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
      {
         RebuildEffectTree();
      }

      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();
         m_root = (ContentControl)GetTemplateChild("PART_Root"); ;
         m_contentPresenter = (ContentPresenter)GetTemplateChild("PART_Content");

         RebuildEffectTree();
      }

      void RebuildEffectTree()
      {
         if (m_root != null && m_contentPresenter != null)
         {
            var effects = Effects ?? new ObservableCollection<Effect>();

            m_root.Content = null;

            var root = effects
               .Select(effect => 
                  new ContentControl
                  {
                     Effect = effect,
                  })
               .Aggregate(
               (FrameworkElement) m_contentPresenter,
               (seed, contentControl) =>
                  {
                     contentControl.Content = seed;
                     return contentControl;
                  }
               );

            m_root.Content = root;
         }
      }
   }
}