﻿using System.Windows;

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

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxSearch.Text == "")
            {
                MessageBox.Show("Please Enter in an item to search for.");
            }
            else
            {
                searchTester.performSearch(textBoxSearch.Text);
            }
        }
    }
}