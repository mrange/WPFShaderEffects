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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ZoomRectApp
{
   public partial class MouseDragBehavior : Behavior<FrameworkElement>
   {
      Canvas m_canvas;

      protected override void OnAttached()
      {
         AssociatedObject.MouseLeftButtonDown += AssociatedObjectMouseLeftButtonDown;

         UpdatePosition(new Point(X, Y));

         base.OnAttached();
      }

      partial void OnXPropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         UpdatePosition(new Point(newValue, Y));
      }

      partial void OnYPropertyChanged(double oldValue, double newValue, ref bool isProcessed)
      {
         UpdatePosition(new Point(X, newValue));
      }

      static T FindVisualElement<T>(DependencyObject source)
         where T : DependencyObject
      {
         var src = source as T;
         if(src != null)
         {
            return src;
         }

         if (source != null)
         {
            return FindVisualElement<T>(VisualTreeHelper.GetParent(source));
         }

         return null;
      }

      void CanvasMouseMove(object sender, MouseEventArgs e)
      {
         var point = e.GetPosition((IInputElement) sender);
         X = point.X;
         Y = point.Y;
         AssociatedObject.SetValue(Canvas.LeftProperty, point.X - AssociatedObject.Width / 2.0);
         AssociatedObject.SetValue(Canvas.TopProperty, point.Y - AssociatedObject.Height / 2.0);
      }

      void ClearHandlers()
      {
         if (m_canvas != null)
         {
            MouseEventHandler canvasMouseLeave = CanvasMouseLeave;
            m_canvas.RemoveHandler(UIElement.MouseLeaveEvent, canvasMouseLeave);

            MouseButtonEventHandler canvasMouseLeftButtonUp = CanvasMouseLeftButtonUp;
            m_canvas.RemoveHandler(UIElement.MouseLeftButtonUpEvent, canvasMouseLeftButtonUp);

            MouseEventHandler canvasMouseMove = CanvasMouseMove;
            m_canvas.RemoveHandler(UIElement.MouseMoveEvent, canvasMouseMove);
         }
         m_canvas = null;
      }

      void AddHandlers()
      {
         ClearHandlers();
         m_canvas = FindVisualElement<Canvas>(AssociatedObject);
         if (m_canvas != null)
         {
            MouseEventHandler canvasMouseLeave = CanvasMouseLeave;
            m_canvas.AddHandler(UIElement.MouseLeaveEvent, canvasMouseLeave, true);

            MouseButtonEventHandler canvasMouseLeftButtonUp = CanvasMouseLeftButtonUp;
            m_canvas.AddHandler(UIElement.MouseLeftButtonUpEvent, canvasMouseLeftButtonUp, true);

            MouseEventHandler canvasMouseMove = CanvasMouseMove;
            m_canvas.AddHandler(UIElement.MouseMoveEvent, canvasMouseMove, true);
         }
      }

      void CanvasMouseLeave(object sender, MouseEventArgs e)
      {
         ClearHandlers();
      }

      void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
         ClearHandlers();
      }

      void AssociatedObjectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         AddHandlers();
      }

      protected override void OnDetaching()
      {
         ClearHandlers();

         AssociatedObject.MouseLeftButtonDown -= AssociatedObjectMouseLeftButtonDown;

         base.OnDetaching();
      }

      void UpdatePosition(Point point)
      {
         if (AssociatedObject != null)
         {
            X = point.X;
            Y = point.Y;
            AssociatedObject.SetValue(Canvas.LeftProperty, point.X - AssociatedObject.Width / 2.0);
            AssociatedObject.SetValue(Canvas.TopProperty, point.Y - AssociatedObject.Height / 2.0);
         }
      }
   }
}
