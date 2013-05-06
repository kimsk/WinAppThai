using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win8YouTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var videos = new List<YouTubeVideo>
            {
                new YouTubeVideo
                { 
                    Title = "Windows 8: A Small Demonstration",
                    Description = "Is Windows 8 really that simple? Watch for the answer.. From Microsoft Portugal:",
                    EmbedUrl = "http://www.youtube.com/embed/G3xnq8d_Tdw?autoplay=1"
                },
                new YouTubeVideo
                { 
                    Title = "New PCs for a new Windows",
                    Description = "It's a new era for PCs. Sleek and lightweight, built for work and play, meet our new lineup designed specifically for the new Windows.",
                    EmbedUrl = "http://www.youtube.com/embed/aEtmB0oJ7Ls?autoplay=1"
                },
                new YouTubeVideo
                { 
                    Title = "The Surface Movement Commercial",
                    Description = "The Microsoft Surface Movement Commercial. From touch to type, office to living room, from your screen to the big screen, you can see more, share more, and do more with Surface.",
                    EmbedUrl = "http://www.youtube.com/embed/iB5txqIl8jQ?autoplay=1"
                },
                new YouTubeVideo
                { 
                    Title = "Surface by Microsoft ",
                    Description = "A tablet that's a unique expression of entertainment and creativity. A tablet that works and plays the way you want. A new type of computing. Surface.",
                    EmbedUrl = "http://www.youtube.com/embed/dpzu3HM2CIo?autoplay=1"
                },
                new YouTubeVideo
                { 
                    Title = "Windows 8 - ทุกสิ่งครบจบในเครื่องเดียว",
                    Description = "พบกับ Windows 8 ได้ที่นี่: http://windows.microsoft.com/th-TH",
                    EmbedUrl = "http://www.youtube.com/embed/W27gEo-BNEA?autoplay=1"
                },
            };

            videoList.ItemsSource = videos;

        }

        private void videoList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var youTubeVideo = e.AddedItems[0] as YouTubeVideo;

            if (youTubeVideo != null)
            {
                var iframeString = string.Format("<iframe width='560' height='315' src='{0}' frameborder='0'></iframe>", youTubeVideo.EmbedUrl);

                youTubeView.NavigateToString(iframeString);
                defaultText.Visibility = Visibility.Collapsed;
                youTubeView.Visibility = Visibility.Visible;
            }
            else
            {
                defaultText.Visibility = Visibility.Visible;
                youTubeView.Visibility = Visibility.Collapsed;
            }
        }
    }

    public class YouTubeVideo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string EmbedUrl { get; set; }
    }
}
