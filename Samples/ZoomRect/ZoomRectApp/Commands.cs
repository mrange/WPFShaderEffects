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

using System.Linq;
   
namespace ZoomRectApp
{
   public sealed partial class RegionOfInterest
   {

      public System.Windows.Input.CommandBinding AddZoomIn(
         System.Windows.Input.CommandBindingCollection commandBindings)
      {
         if(commandBindings != null)
         {
            var cb = 
               new System.Windows.Input.CommandBinding(
                  ZoomInCommand,
                  ZoomInExecuted,
                  CanExecuteZoomIn);
            commandBindings.Add(cb);
            return cb;
         }
         else
         {
            return null;
         }
      }
      
      public static System.Windows.Input.RoutedCommand ZoomInCommand = new System.Windows.Input.RoutedCommand(
         "ZoomIn",
         typeof(ZoomRectApp.RegionOfInterest));

      partial void OnCanExecuteZoomIn(ref bool isExecutable, ref bool isProcessed);

      void CanExecuteZoomIn(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
      {
         var isExecutable = false;
         var isProcessed = false;
         
         OnCanExecuteZoomIn(ref isExecutable, ref isProcessed);
         
         if(isProcessed)
         {
            e.CanExecute = isExecutable;
         }
         else
         {
            e.CanExecute = true;
         }
      }

      partial void OnZoomInExecuted(ref bool isProcessed);
      
      void ZoomInExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
      {
         var isProcessed = false;
         
         OnZoomInExecuted(ref isProcessed);
         
         e.Handled = isProcessed;
      }

      public System.Windows.Input.CommandBinding AddZoomOut(
         System.Windows.Input.CommandBindingCollection commandBindings)
      {
         if(commandBindings != null)
         {
            var cb = 
               new System.Windows.Input.CommandBinding(
                  ZoomOutCommand,
                  ZoomOutExecuted,
                  CanExecuteZoomOut);
            commandBindings.Add(cb);
            return cb;
         }
         else
         {
            return null;
         }
      }
      
      public static System.Windows.Input.RoutedCommand ZoomOutCommand = new System.Windows.Input.RoutedCommand(
         "ZoomOut",
         typeof(ZoomRectApp.RegionOfInterest));

      partial void OnCanExecuteZoomOut(ref bool isExecutable, ref bool isProcessed);

      void CanExecuteZoomOut(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
      {
         var isExecutable = false;
         var isProcessed = false;
         
         OnCanExecuteZoomOut(ref isExecutable, ref isProcessed);
         
         if(isProcessed)
         {
            e.CanExecute = isExecutable;
         }
         else
         {
            e.CanExecute = true;
         }
      }

      partial void OnZoomOutExecuted(ref bool isProcessed);
      
      void ZoomOutExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
      {
         var isProcessed = false;
         
         OnZoomOutExecuted(ref isProcessed);
         
         e.Handled = isProcessed;
      }

      public System.Windows.Input.CommandBinding AddGrowRoi(
         System.Windows.Input.CommandBindingCollection commandBindings)
      {
         if(commandBindings != null)
         {
            var cb = 
               new System.Windows.Input.CommandBinding(
                  GrowRoiCommand,
                  GrowRoiExecuted,
                  CanExecuteGrowRoi);
            commandBindings.Add(cb);
            return cb;
         }
         else
         {
            return null;
         }
      }
      
      public static System.Windows.Input.RoutedCommand GrowRoiCommand = new System.Windows.Input.RoutedCommand(
         "GrowRoi",
         typeof(ZoomRectApp.RegionOfInterest));

      partial void OnCanExecuteGrowRoi(ref bool isExecutable, ref bool isProcessed);

      void CanExecuteGrowRoi(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
      {
         var isExecutable = false;
         var isProcessed = false;
         
         OnCanExecuteGrowRoi(ref isExecutable, ref isProcessed);
         
         if(isProcessed)
         {
            e.CanExecute = isExecutable;
         }
         else
         {
            e.CanExecute = true;
         }
      }

      partial void OnGrowRoiExecuted(ref bool isProcessed);
      
      void GrowRoiExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
      {
         var isProcessed = false;
         
         OnGrowRoiExecuted(ref isProcessed);
         
         e.Handled = isProcessed;
      }

      public System.Windows.Input.CommandBinding AddShrinkRoi(
         System.Windows.Input.CommandBindingCollection commandBindings)
      {
         if(commandBindings != null)
         {
            var cb = 
               new System.Windows.Input.CommandBinding(
                  ShrinkRoiCommand,
                  ShrinkRoiExecuted,
                  CanExecuteShrinkRoi);
            commandBindings.Add(cb);
            return cb;
         }
         else
         {
            return null;
         }
      }
      
      public static System.Windows.Input.RoutedCommand ShrinkRoiCommand = new System.Windows.Input.RoutedCommand(
         "ShrinkRoi",
         typeof(ZoomRectApp.RegionOfInterest));

      partial void OnCanExecuteShrinkRoi(ref bool isExecutable, ref bool isProcessed);

      void CanExecuteShrinkRoi(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
      {
         var isExecutable = false;
         var isProcessed = false;
         
         OnCanExecuteShrinkRoi(ref isExecutable, ref isProcessed);
         
         if(isProcessed)
         {
            e.CanExecute = isExecutable;
         }
         else
         {
            e.CanExecute = true;
         }
      }

      partial void OnShrinkRoiExecuted(ref bool isProcessed);
      
      void ShrinkRoiExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
      {
         var isProcessed = false;
         
         OnShrinkRoiExecuted(ref isProcessed);
         
         e.Handled = isProcessed;
      }

      public System.Windows.Input.CommandBinding[] AddAllCommands(
         System.Windows.Input.CommandBindingCollection commandBindings)
      {
         var list = new System.Collections.Generic.List<System.Windows.Input.CommandBinding>();
         list.Add(AddZoomIn(commandBindings));
         list.Add(AddZoomOut(commandBindings));
         list.Add(AddGrowRoi(commandBindings));
         list.Add(AddShrinkRoi(commandBindings));
      
         return list.ToArray();
      }

   }
   // -------------------------------------------------------------------------
}

