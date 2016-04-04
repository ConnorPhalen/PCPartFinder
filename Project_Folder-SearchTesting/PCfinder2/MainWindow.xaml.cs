using System.Windows;

using Google.Apis.Customsearch.v1.Data;
using System.Windows.Controls;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Navigation;

namespace PCfinder2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    /// @author Chiseong Oh
    /// @ReferenceCode 
    public partial class MainWindow : Window
    {
        SearchFunc searchTester; 

        public MainWindow()
        {
            InitializeComponent();

            searchTester = new SearchFunc();
        }
        /// <summary>
        /// To add a new tab with default name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClosableTap theTabItem = new ClosableTap();
            theTabItem.Title = "Batman";
            tabControl.Items.Add(theTabItem);
            theTabItem.Focus();
        }

        /// <summary>
        /// To add a new tab with longer name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClosableTap theTabItem = new ClosableTap();
            theTabItem.Title = "Robin Hood and Applesauce";
            tabControl.Items.Add(theTabItem);
            theTabItem.Focus();
        }

        /// <summary>
        /// Takes the text from textBoxSearch and searches for that text. Results are formatted and stored in a new tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttonSearch.IsEnabled = false;

                if (textBoxSearch.Text == "")
                {
                    MessageBox.Show("Please Enter in an item to search for.");
                }
                else
                {
                    // Performs a search, and gets the search results
                    Search results = searchTester.performSearch(textBoxSearch.Text);

                    // Creates a new tab.
                    ClosableTap searchTabItem = new ClosableTap();
                    searchTabItem.Title       = textBoxSearch.Text;
                    GroupBox resultBox        = new GroupBox();
                    textBoxSearch.Clear();
                    
                    // Creates a series of UIElements to store and display the results.
                    WrapPanel resultList   = new WrapPanel();
                    ScrollViewer resultHolder = new ScrollViewer();
                    string       resultOutput = "";
                    BitmapImage  resultImage;
                    RichTextBox  resultDetails;
                    Hyperlink    resultLink;

                    // For each result, insert into the new tab. !!!! Change later to have link as hyper text !!!!
                    foreach (Result result in results.Items)
                    {
                        resultBox     = new GroupBox();
                        resultImage   = new BitmapImage();
                        resultDetails = new RichTextBox();
                        resultLink    = new Hyperlink();

                        // If it contains a price, print it off in a special way...
                        if (result.Pagemap.ContainsKey("offer"))
                        {
                            // If it has an actual price...
                            if(result.Pagemap["offer"][0].ContainsKey("price"))
                            {
                                resultOutput = (result.Title + "\n" + "Price: " + result.Pagemap["offer"][0]["price"].ToString());

                                // If it has a specific currency...
                                if (result.Pagemap["offer"][0].ContainsKey("pricecurrency"))
                                {
                                    resultOutput += (" " + result.Pagemap["offer"][0]["pricecurrency"].ToString() + "\n");
                                }
                                else
                                {
                                    resultOutput += "\n";
                                }
                            }
                        }
                        else // else, print it off normally.
                        {
                            resultOutput = result.Title + "\n";
                        }
                        
                        // if the result has an image...
                        if (result.Pagemap.ContainsKey("cse_image"))
                        {
                            resultImage.UriSource = new Uri("\n" + (string)result.Pagemap["cse_image"][0]["src"]);
                        }

                        // Creates a clickable link to the original webpage.
                        resultLink.Inlines.Add(result.Link);
                        resultLink.NavigateUri = new Uri(result.Link);
                        resultLink.IsEnabled   = true;

                        // Set click, enter, and leave Event handlers for this hyperlink
                        resultLink.Click           += new RoutedEventHandler(hyperlink_Enter);
                        resultLink.MouseEnter      += new MouseEventHandler(hyperlink_Leave);
                        resultLink.RequestNavigate += new RequestNavigateEventHandler(Hyperlink_RequestNavigate);

                        // Adds the primary text content from the result to a RichTextBox
                        Paragraph resultBlock = new Paragraph();

                        resultBlock.Inlines.Add(resultOutput);
                        resultBlock.Inlines.Add(resultLink.NavigateUri.AbsoluteUri + "\n");

                        /* Do not directly use, control is deleted.
                        richTextBoxTest.Document.Blocks.Add(new Paragraph(new Run(resultLink.NavigateUri.AbsoluteUri)));
                        richTextBoxTest.IsDocumentEnabled = true;
                        */

                        resultDetails.IsDocumentEnabled = true;
                        resultDetails.IsEnabled         = true;
                        resultDetails.IsReadOnly        = true;
                        resultDetails.Document.Blocks.Add(resultBlock);

                        // Adds all of the items above into a GroupBox control
                        resultBox.Content   = resultDetails;
                        resultBox.IsEnabled = true;

                        // Add the GroupBox to the list.
                        resultList.Children.Add(resultBox);
                    }
                    // Places the resultList in a Scrollable area, and then into the actual tab.
                    resultHolder.Content   = resultList;
                    resultHolder.IsEnabled = true;

                    searchTabItem.Content   = resultHolder;
                    searchTabItem.IsEnabled = true;

                    // Add the tab to the Tab Control and select it.
                    tabControl.Items.Add(searchTabItem);
                    tabControl.SelectedItem = (TabItem) searchTabItem;
                    tabControl.IsEnabled    = true;                     // ---- Set all those things to be enabled. Could reset it later. ---- 

                    buttonSearch.IsEnabled  = true;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Items were returned from the search.");
            }
        }

        /// <summary>
        /// Sets the action for when the Hyperlink is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }

        /// <summary>
        /// When the users mouse enters the bounding area of the hyperlink, the mouse icon changes to the default click Icon,
        /// and the hyperlink changes colour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hyperlink_Enter(object sender, EventArgs e)
        {
            try
            {
                // Change cursor to clicky cursor

                // Change text colour
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("That is not a valid Hyperlink\n Message: " + ex.ToString());
            }
        }

        /// <summary>
        /// When the users mouse leaves the bounding area of the hyperlink, the mouse reverts to it's default state,
        /// and the hyperlink reverts to default colour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hyperlink_Leave(object sender, EventArgs e)
        {
            try
            {
                // Revert cursor to default cursor

                // Revert text colour
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("That is not a valid Hyperlink\n Message: " + ex.ToString());
            }
        }
    }
}
