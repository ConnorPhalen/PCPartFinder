using System.Windows;

using Google.Apis.Customsearch.v1.Data;
using System.Windows.Controls;
using System;
using System.Collections.Generic;

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
        /// Takes the text from textBoxSearch and searches for that text. Results are stored in a new tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

                    textBoxSearch.Clear();

                    // ---- Might change to a Table View so we can get all the information of one result onto one row. ----
                    ListView resultList = new ListView();

                    // For each result, insert into the new tab.
                    foreach (Result result in results.Items)
                    {
                        // If it contains a price, print it off in a special way..
                        if(result.Pagemap.ContainsKey("hproduct"))
                        {
                            resultList.Items.Add(result.Title + "\n" + result.Link + "\n"
                                                 + result.Pagemap["hproduct"].ToString() + "\n"); // !!!! FIX !!!!
                        }
                        else // else, print it off normally.
                        {
                            //resultList.Items.Add(result.Title + "\n" + result.Link + "\n");
                        }
                    }

                    searchTabItem.Content = resultList;

                    // Add the tab to the Tab Control and select it.
                    tabControl.Items.Add(searchTabItem);
                    tabControl.SelectedItem = (TabItem) searchTabItem;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Items were returned from the search.");
            }
        }
    }
}
