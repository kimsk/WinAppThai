using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplashScreenSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Splash : Page
    {
        internal bool dismissed = false;
        internal Frame rootFrame; 

        public Splash(SplashScreen splashScreen, bool loadState)
        {
            this.InitializeComponent();

            splashScreen.Dismissed += splashScreen_Dismissed;

            rootFrame = new Frame(); 

        }

        void splashScreen_Dismissed(SplashScreen sender, object args)
        {
            dismissed = true;

            // Navigate away from the app's extended splash screen after completing setup operations here...
            // This sample navigates away from the extended splash screen when the "Learn More" button is clicked.

            // Need dispatcher to inject code to UI thread
            var dispatcher = rootFrame.Dispatcher;

            // start loading
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                loadingSomething.IsActive = true;
                countDown.Text = "5";
            });

            // load something for 5 seconds
            for (int i = 5; i > 0; i--)
            {
                new System.Threading.ManualResetEvent(false).WaitOne(1000);
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    countDown.Text = i.ToString();
                });
            }
            
            // load end and navigate to MainPage
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                rootFrame.Navigate(typeof(MainPage));
                Window.Current.Content = rootFrame;
            });

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
