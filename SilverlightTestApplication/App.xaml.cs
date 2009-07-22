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
using System.Windows.Browser;

namespace SilverlightTestApplication
{
   public partial class App
   {

      public App()
      {
         Startup += ApplicationStartup;
         Exit += ApplicationExit;
         UnhandledException += ApplicationUnhandledException;

         InitializeComponent();
      }

      private void ApplicationStartup(object sender, StartupEventArgs e)
      {
         RootVisual = new MainPage();
      }

      private static void ApplicationExit(object sender, EventArgs e)
      {

      }
      private static void ApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
      {
         // If the app is running outside of the debugger then report the exception using
         // the browser's exception mechanism. On IE this will display it a yellow alert 
         // icon in the status bar and Firefox will display a script error.
         if (!System.Diagnostics.Debugger.IsAttached)
         {

            // NOTE: This will allow the application to continue running after an exception has been thrown
            // but not handled. 
            // For production applications this error handling should be replaced with something that will 
            // report the error to the website and stop the application.
            e.Handled = true;
            Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
         }
      }
      private static void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
      {
         try
         {
            var errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
            errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

            HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
         }
         catch (Exception)
         {
         }
      }
   }
}
