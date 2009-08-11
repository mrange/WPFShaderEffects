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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

#if SILVERLIGHT
namespace SilverlightShaderEffects
#else
namespace WpfShaderEffects
#endif
{
   [TemplatePart(Name = "PART_Left", Type = typeof(ContentControl))]
   [TemplatePart(Name = "PART_Right", Type = typeof(ContentControl))]
   public partial class TransitionEffectMixer : Control
   {
      const double MinDiff = 0.0001;

      enum State
      {
         ShowingLeft,
         ShowingRight,
         InTransition,
      }
      ContentControl m_left;
      ContentControl m_right;

      bool m_settingEffect;

      State m_state;
#if SILVERLIGHT
      partial void OnConstruction()
      {
         DefaultStyleKey = typeof(TransitionEffectMixer);
      }
#else
      static TransitionEffectMixer()
      {
         DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TransitionEffectMixer),
            new FrameworkPropertyMetadata(typeof(TransitionEffectMixer)));
      }
#endif
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         m_left = (ContentControl)GetTemplateChild("PART_Left"); ;
         m_right = (ContentControl)GetTemplateChild("PART_Right");
         SetEffect();
      }

#if !SILVERLIGHT
      partial void OnMixCoerceValue(double baseValue, ref double newValue, ref bool isProcessed)
      {
         newValue = Math.Max(0.0, Math.Min(1.0, baseValue));
         isProcessed = true;
      }

      partial void OnMixPropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         SetEffect();
         isProcessed = true;
      }

      partial void OnTransitionShaderEffectCoerceValue(ITransitionShaderEffect baseValue, ref ITransitionShaderEffect newValue, ref bool isProcessed)
      {
         if (!(baseValue is Effect))
         {
            newValue = null;
            isProcessed = true;
         }
      }

#endif

      void SetEffect()
      {
         if (m_left == null || m_right == null || m_settingEffect)
         {
            return;
         }

         m_settingEffect = true;
         try
         {
            var mix = Mix;
            if (mix < MinDiff && m_state != State.ShowingLeft)
            {
               m_left.IsHitTestVisible = true;
               m_right.IsHitTestVisible = false;
               m_left.Visibility = Visibility.Visible;
               m_right.Visibility = Visibility.Collapsed;
               m_right.Effect = null;
               m_state = State.ShowingLeft;
            }
            else if (mix > (1 - MinDiff) && m_state != State.ShowingRight)
            {
               m_left.IsHitTestVisible = false;
               m_right.IsHitTestVisible = true;
               m_left.Visibility = Visibility.Collapsed;
               m_right.Visibility = Visibility.Visible;
               m_right.Effect = null;
               m_state = State.ShowingRight;
            }
            else if(m_state != State.InTransition)
            {
               m_left.IsHitTestVisible = false;
               m_right.IsHitTestVisible = false;
               m_left.Visibility = Visibility.Visible;
               m_right.Visibility = Visibility.Visible;
               m_state = State.InTransition;
            }

            if (m_state == State.InTransition)
            {
               var oldEffect = m_right.Effect as ITransitionShaderEffect;
               var transitionShaderEffect = TransitionShaderEffect;
               if (!ReferenceEquals(oldEffect, transitionShaderEffect))
               {
                  if (oldEffect != null)
                  {
                     oldEffect.SecondInput = null;
                  }

                  var newEffect = transitionShaderEffect as Effect;

                  if (newEffect != null && transitionShaderEffect != null)
                  {
                     transitionShaderEffect.SecondInput =
                        new VisualBrush(m_left)
                           {
                              AutoLayoutContent = false,
                           };
                  }

                  m_right.Effect = newEffect;
               }
               if (
                     transitionShaderEffect != null 
                  && Math.Abs(transitionShaderEffect.Progress - mix) > MinDiff)
               {
                  transitionShaderEffect.Progress = mix;
               }

            }
         }
         finally
         {
            m_settingEffect = false;
         }
      }

      partial void OnTransitionShaderEffectPropertyChanged(ITransitionShaderEffect oldValue, ITransitionShaderEffect newValue, ref bool isProcessed)
      {
         SetEffect();
      }
   }
}
