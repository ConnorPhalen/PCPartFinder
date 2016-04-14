using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Google.Apis.Customsearch.v1.Data;

namespace PCfinder2
{
    class ClosableTap : TabItem
    {
        // CloseableTap Constructor 
        public ClosableTap()
        {
            // Instanciate CloseableTap to use customized tab appearance
            CloseableTap closableTabHeader = new CloseableTap();

            // naming
            this.Header = closableTabHeader;

            //Events list
            closableTabHeader.close.MouseEnter += new MouseEventHandler(button_close_MouseEnter);
            closableTabHeader.close.MouseLeave += new MouseEventHandler(button_close_MouseLeave);
            closableTabHeader.close.Click += new RoutedEventHandler(button_close_Click);
            closableTabHeader.title.SizeChanged += new SizeChangedEventHandler(label_TabTitle_SizeChanged);
        }

        /// <summary>
        /// Set title name.
        /// </summary>
        public string Title
        {
            set
            {
                ((CloseableTap)this.Header).title.Content = value;
            }
        }

        private TabItem GetTargetTabItem(object originalSource)
        {
            var current = originalSource as DependencyObject;

            while (current != null)
            {
                var tabItem = current as TabItem;
                if (tabItem != null)
                {
                    return tabItem;
                }

                current = VisualTreeHelper.GetParent(current);
            }

            return null;
        }

        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            var tabItemTarget = GetTargetTabItem(e.OriginalSource);
            if (tabItemTarget != null)
            {
                var tabItemSource = (TabItem)e.Data.GetData(typeof(TabItem));
                if (tabItemTarget != tabItemSource)
                {
                    // Do Nothing
                }
            }
        }
        // Override OnSelected to display X button
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((CloseableTap)this.Header).close.Visibility = Visibility.Visible;
        }

        // Override OnUnSelected to remove X button
        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((CloseableTap)this.Header).close.Visibility = Visibility.Hidden;
        }

        // Override OnMouseEnter to dispaly X button
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((CloseableTap)this.Header).close.Visibility = Visibility.Visible;
        }

        // Override OnMouseLeave to remove X button
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((CloseableTap)this.Header).close.Visibility = Visibility.Hidden;
            }
        }
        // mouseover color
        void button_close_MouseEnter(object sender, MouseEventArgs e)
        {
            ((CloseableTap)this.Header).close.Foreground = Brushes.DeepSkyBlue;
        }

        // moverleave color
        void button_close_MouseLeave(object sender, MouseEventArgs e)
        {
            ((CloseableTap)this.Header).close.Foreground = Brushes.Black;
        }

        // Button X click = remove
        void button_close_Click(object sender, RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
        }

        // resizing depending on the length of the label name
        void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((CloseableTap)this.Header).close.Margin = new Thickness(((CloseableTap)this.Header).title.ActualWidth + 5, 3, 4, 0);
        }
    }
}
