using MahApps.Metro.Controls;
using System.Windows;
using Google.Apis.Customsearch.v1.Data;
using System.Windows.Controls;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Diagnostics;

namespace PCfinder2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    /// @author Chiseong Oh and Connor Phalen
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
            this.WindowState = WindowState.Maximized;
            this.UseNoneWindowStyle = true;
            this.IgnoreTaskbarOnMaximize = true;
        }
        /// <summary>
        /// To add a new tab with longer name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.UseNoneWindowStyle = false;
            this.ShowTitleBar = true; // <-- this must be set to true
            this.IgnoreTaskbarOnMaximize = false;
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

        /// <summary>
        /// 
        /// </summary>
        private MetroWindow accentThemeTestWindow;
        private MetroWindow wishlist;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 3.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 3.0;
            accentThemeTestWindow.Show();
        }
        private void OpenWishlist(object sender, RoutedEventArgs e)
        {
            if (wishlist != null)
            {
                wishlist.Activate();
                return;
            }

            //wishlist = new Wishlist();
            wishlist.Owner = this;
            wishlist.Closed += (o, args) => wishlist = null;
            wishlist.Left = this.Left + this.ActualWidth / 3.0;
            wishlist.Top = this.Top + this.ActualHeight / 3.0;
            wishlist.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchStarter"></param>
        private void sendQuery(searchDelegate searchStarter)
        {
            // Starts the search delagate function.
            searchStarter(textBoxSearch.Text);

            textBoxSearch.Clear();
        }

        /// <summary>
        /// When a Hyperlink is clicked, it will open it's webpage in a new tabe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Failed to open Web Page. Hyperlink is in bad state. Message: " + ex.ToString());
            }
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
            const int ELEMENTCOUNT = 4;
            try
            {
                buttonSearch.IsEnabled = false;

                if (query == "")
                {
                    MessageBox.Show("Please Enter in an item to search for.");
                    buttonSearch.IsEnabled = true;
                }
                else
                {
                    // Performs a search, and gets the search results
                    Search results = searchTester.performSearch(query);

                    // If search result failed, leave function.
                    if (results == null)
                    {
                        buttonSearch.IsEnabled = true;
                        return;
                    }

                    // Creates a series of UIElements to store and display the results.
                    GroupBox resultBox;
                    WrapPanel resultList = new WrapPanel();
                    ScrollViewer resultHolder = new ScrollViewer();
                    string resultOutput = "";
                    BitmapImage resultImage;
                    RichTextBox resultDetails;
                    Hyperlink resultLink;
                    Grid resultBoxGrid;

                    // List all of the elements vetically
                    resultList.Orientation = Orientation.Vertical;

                    if (results.Items.Count < 1)
                    {
                        MessageBox.Show("No results were returned by the search.");
                        return;
                    }

                    // For each result, insert into the new tab. !!!! Change later to have link as hyper text !!!!
                    foreach (Result result in results.Items)
                    {
                        resultBox = new GroupBox();
                        resultImage = new BitmapImage();
                        resultDetails = new RichTextBox();
                        resultLink = new Hyperlink();
                        resultBoxGrid = new Grid();
                        int i = 0;

                        // for each element, insert a column
                        for (int k = 0; k < ELEMENTCOUNT; k++)
                        {
                            resultBoxGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        }

                        resultBox.Width = tabControl.ActualWidth - 5;

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
                            // Initialize the Bitmap
                            resultImage.BeginInit();

                            // Set the Bitmap source
                            resultImage.UriSource = new Uri((string)result.Pagemap["cse_image"][0]["src"], UriKind.Absolute); // !!!! Needs to be fixed !!!!
                            resultImage.EndInit();

                            // Assign Bitmap to an image, and add it to the UI
                            Image productImage = new Image();
                            productImage.Source = resultImage;
                            resultBoxGrid.Children.Add(productImage);
                            Grid.SetColumn(productImage, i++);
                        }

                        // Creates a clickable link to the original webpage.
                        resultLink.Inlines.Add("Visit Webpage...");
                        resultLink.NavigateUri = new Uri(result.Link);
                        resultLink.IsEnabled = true;

                        // Set click, enter, and leave Event handlers for this hyperlink
                        resultLink.Click += new RoutedEventHandler(hyperlink_Enter);
                        resultLink.MouseEnter += new MouseEventHandler(hyperlink_Leave);
                        resultLink.RequestNavigate += new RequestNavigateEventHandler(Hyperlink_RequestNavigate);

                        // Adds the primary text content from the result to a RichTextBox
                        Paragraph resultBlock = new Paragraph();

                        resultBlock.Inlines.Add(resultOutput);
                        resultBlock.Inlines.Add(resultLink);

                        // Set the document to be enabled, and add the paragraph
                        resultDetails.IsDocumentEnabled = true;
                        resultDetails.IsReadOnly = true;
                        resultDetails.Document.Blocks.Add(resultBlock);

                        resultBoxGrid.Children.Add(resultDetails);
                        Grid.SetColumn(resultDetails, i++);

                        // Create a button to display specific product details in a new tab
                        Button openDetails = createOpenDetailTabButton((tabControl.Width / ELEMENTCOUNT), resultDetails.Height + 20, result);

                        resultBoxGrid.Children.Add(openDetails);
                        Grid.SetColumn(openDetails, i++);

                        // Create a button to add an item to your wishlist
                        Button addToWishlist = createAddToWishlistButton((tabControl.Width / ELEMENTCOUNT), resultDetails.Height + 20, result);

                        resultBoxGrid.Children.Add(addToWishlist);
                        Grid.SetColumn(addToWishlist, i++);

                        // Adds all of the items above into a GroupBox control
                        resultBox.Content = resultBoxGrid;

                        // Add the GroupBox to the list.
                        resultList.Children.Add(resultBox);
                    }
                    // Places the resultList in a Scrollable area, and then into the actual tab.
                    resultHolder.Content = resultList;
                    resultHolder.HorizontalAlignment = HorizontalAlignment.Stretch;

                    // Sets the Home Tab to be the resultList, and sets it as selected
                    tabHome.Content = resultHolder;
                    tabControl.SelectedItem = tabHome;

                    buttonSearch.IsEnabled = true;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Items were returned from the search.\n Error Message: " + ex.ToString());
            }
        }

        /// <summary>
        /// Button Method to display the current results details in a new tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDetailTab_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Create a new tab to displaythe specific results
            CloseableTap detailTab = new CloseableTap();
            Result result = (Result)clickedButton.Tag;

            // Display the search reults details on the new tab
            detailTab.displayResultDetail(result);

            // add the new tab to the tabControl
            tabControl.Items.Add(detailTab);

            // How do we display the tab again????

        }

        /// <summary>
        /// Button Method to add a result to the wishlist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToWishlist_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            Result result = (Result)clickedButton.Tag;


            //Grid.GetColumn()
            MessageBox.Show("");
        }

        /// <summary>
        /// Allows the user to click the "Enter" button while the textbox is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            // if key is down...
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                // ... start the result search
                buttonSearch_Click(sender, e);
            }
        }

        /// <summary>
        /// Create button to create a new tab to display the current result details.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Button createOpenDetailTabButton(double width, double height, Result searchResult)
        {
            // Create new button and give it an onClick method
            Button openDetailTab = new Button();
            openDetailTab.Click += OpenDetailTab_Click;

            // Assign a height and width
            openDetailTab.Width = width;
            openDetailTab.Height = height;

            // Place the search result as the tag for easy access (need to change later. This seems weird).
            openDetailTab.Tag = searchResult;

            // Assign some text
            TextBlock buttonText = new TextBlock();
            buttonText.Text = "Open Details in new Tab";

            openDetailTab.Content = buttonText;

            return openDetailTab;
        }

        /// <summary>
        /// Create button to add the current result to the wishlist.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Button createAddToWishlistButton(double width, double height, Result searchResult)
        {
            // Create new button and give it an onClick method
            Button addToWishlist = new Button();
            addToWishlist.Click += AddToWishlist_Click;

            // Assign a height and width
            addToWishlist.Width = width;
            addToWishlist.Height = height;

            // Place the search result as the tag for easy access (need to change later. This seems weird).
            addToWishlist.Tag = searchResult;

            // Assign some text
            TextBlock buttonText = new TextBlock();
            buttonText.Text = "Add To Wishlist";

            addToWishlist.Content = buttonText;

            return addToWishlist;
        }
    }
}
