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

using System.Net.Http;
using System.Xml.Linq;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BingImage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string bingUrlPrefix = "http://www.bing.com/HPImageArchive.aspx?format=xml&n=1&mkt=en-US&idx=";

        public MainPage()
        {
            this.InitializeComponent();

            getPhoto.Click += getPhoto_Click;
        }

        async void getPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(previousDays.Text))
                return;

            using (var client = new HttpClient())
            {
                var fullBingUrl = string.Format("{0}{1}", bingUrlPrefix, previousDays.Text);
                var xmlString = await client.GetStringAsync(new Uri(fullBingUrl));

                var doc = XDocument.Parse(xmlString);

                var imageUrlElement = doc
                    .Descendants("image")
                    .Descendants("url")
                    .FirstOrDefault();

                if (imageUrlElement != null)
                {
                    var imageUrl = imageUrlElement.Value;
                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("http://www.bing.com/" + imageUrl));                    
                    mainGrid.Background = imageBrush;
                }
            }
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
