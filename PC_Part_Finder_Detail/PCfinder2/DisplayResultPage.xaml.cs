using Google.Apis.Customsearch.v1.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PCfinder2
{
    /// <summary>
    /// Interaction logic for DisplayResultPage.xaml
    /// </summary>
    public partial class DisplayResultPage : Page
    {
        Result result;

        public DisplayResultPage(ref Result searchResult)
        {
            InitializeComponent();

            result = searchResult;
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadResultData()
        {
            try
            {
                // if the resukt has an image...
                if (result.Pagemap.ContainsKey("cse_image"))
                {
                    BitmapImage resultImage = new BitmapImage();

                    // Initialize the Bitmap
                    resultImage.BeginInit();
                    // Set the Bitmap source
                    resultImage.UriSource = new Uri((string)result.Pagemap["cse_image"][0]["src"], System.UriKind.Absolute); // !!!! Needs to be fixed !!!!
                    resultImage.EndInit();

                    // Assign Bitmap to an image, and add it to the UI
                    imageResult.Source = resultImage;
                }

                textBoxMainDetails.Text = "Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text";
                textBoxSpecs.Text = "Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text";
                textBoxFeatures.Text = "Sample Text Sample Text Sample Text Sample Text Sample Text Sample Text";

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("One of the values could not be found in the search result.");
            }
        }
    }
}
