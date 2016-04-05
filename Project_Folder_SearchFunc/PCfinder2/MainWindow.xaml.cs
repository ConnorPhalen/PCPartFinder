using MahApps.Metro.Controls;
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
    public partial class MainWindow : MetroWindow
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
            theTabItem.Title = "Extended tabs";
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
            theTabItem.Title = "There are a few secrets";
            tabControl.Items.Add(theTabItem);
            theTabItem.Focus();
        }
        private delegate void searchDelegate(string query);
        /// <summary>
        /// Starts the Search process in a new Thread. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            // Create a new searchDelegate nd give it a method to use
            searchDelegate searchStarter = new searchDelegate(startSearch);
            sendQuery(searchStarter);
        }
        private MetroWindow accentThemeTestWindow;

        private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }

            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }

        private void sendQuery(searchDelegate searchStarter)
        {
            // Starts the search delagate function.
            searchStarter(textBoxSearch.Text);

            textBoxSearch.Clear();
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
                MessageBox.Show("That is not a valid Hyperlink.\n Error Message: " + ex.ToString());
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

        /// <summary>
        /// Takes the text from textBoxSearch and searches for that text. Results are formatted and stored in a new tab.
        /// </summary>
        private void startSearch(string query)
        {
            try
            {
                buttonSearch.IsEnabled = false;

                if (query == "")
                {
                    MessageBox.Show("Please Enter in an item to search for.");
                }
                else
                {
                    // Performs a search, and gets the search results
                    Search results = searchTester.performSearch(query);

                    // Creates a new tab.
                    ClosableTap searchTabItem = new ClosableTap();
                    searchTabItem.Title = query;

                    // Creates a series of UIElements to store and display the results.
                    GroupBox resultBox = new GroupBox();
                    WrapPanel resultList = new WrapPanel();
                    ScrollViewer resultHolder = new ScrollViewer();
                    string resultOutput = "";
                    BitmapImage resultImage;
                    RichTextBox resultDetails;
                    Hyperlink resultLink;
                    Grid resultBoxGrid;

                    // For each result, insert into the new tab. !!!! Change later to have link as hyper text !!!!
                    foreach (Result result in results.Items)
                    {
                        resultBox = new GroupBox();
                        resultImage = new BitmapImage();
                        resultDetails = new RichTextBox();
                        resultLink = new Hyperlink();
                        resultBoxGrid = new Grid();

                        // If it contains price details, print it off in a special way...
                        if (result.Pagemap.ContainsKey("offer"))
                        {
                            // If it has an actual price...
                            if (result.Pagemap["offer"][0].ContainsKey("price"))
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

                        // if the result has an image, add it to the Groupbox.
                        if (result.Pagemap.ContainsKey("cse_image"))
                        {
                            resultImage.UriSource = new Uri("\n" + (string)result.Pagemap["cse_image"][0]["src"]);

                            Image productImage = new Image(); // Figure this out, or delete it
                            productImage.Source = resultImage;
                            resultBoxGrid.Children.Add(productImage);
                        }

                        // Creates a clickable link to the original webpage.
                        resultLink.Inlines.Add(result.Link);
                        resultLink.NavigateUri = new Uri(result.Link);
                        resultLink.IsEnabled = true;

                        // Set click, enter, and leave Event handlers for this hyperlink
                        resultLink.Click += new RoutedEventHandler(hyperlink_Enter);
                        resultLink.MouseEnter += new MouseEventHandler(hyperlink_Leave);
                        resultLink.RequestNavigate += new RequestNavigateEventHandler(Hyperlink_RequestNavigate);

                        // Adds the primary text content from the result to a RichTextBox
                        Paragraph resultBlock = new Paragraph();

                        resultBlock.Inlines.Add(resultOutput);
                        resultBlock.Inlines.Add(resultLink.NavigateUri.AbsoluteUri + "\n");

                        resultDetails.IsDocumentEnabled = true;
                        resultDetails.IsEnabled = true;
                        resultDetails.IsReadOnly = true;
                        resultDetails.Document.Blocks.Add(resultBlock);

                        resultBoxGrid.Children.Add(resultDetails);

                        // Adds all of the items above into a GroupBox control
                        //resultBox.Content   = resultDetails;
                        resultBox.Content = resultBoxGrid;
                        resultBox.IsEnabled = true;

                        // Add the GroupBox to the list.
                        resultList.Children.Add(resultBox);
                    }
                    // Places the resultList in a Scrollable area, and then into the actual tab.
                    resultHolder.Content = resultList;
                    resultHolder.IsEnabled = true;

                    searchTabItem.Content = resultHolder;
                    searchTabItem.IsEnabled = true;

                    // Add the tab to the Tab Control and select it.
                    tabControl.Items.Add(searchTabItem);
                    tabControl.SelectedItem = (TabItem)searchTabItem;
                    tabControl.IsEnabled = true;                     // ---- Set all those things to be enabled. Could reset it later. ---- 

                    buttonSearch.IsEnabled = true;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Items were returned from the search.\n Error Message: " + ex.ToString());
            }
        }
    }
}
