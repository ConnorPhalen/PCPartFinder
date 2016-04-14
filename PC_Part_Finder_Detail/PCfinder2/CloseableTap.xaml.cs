using System;
using System.Windows.Controls;
using Google.Apis.Customsearch.v1.Data;
using System.Windows;

namespace PCfinder2
{
    /// <summary>
    /// Interaction logic for CloseableTap.xaml
    /// </summary>
    public partial class CloseableTap : UserControl
    {
        public CloseableTap()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Takes in a Search Result and displays most of it in this tab.
        /// </summary>
        /// <param name="result"></param>
        internal void displayResultDetail(Result result)
        {
            // Creates a new result Page to display the result
            this.Content = new DisplayResultPage(ref result);
        }
    }
}
