using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ScrollViewer
{
    public partial class ScrollingProgrammatically : PhoneApplicationPage
    {
        public ScrollingProgrammatically()
        {
            InitializeComponent();
        }

        private void ScrollTopButton_Click(object sender, RoutedEventArgs e)
        {
            TextScrollViewer.ScrollToVerticalOffset(0);
        }

        private void ScrollBottomButton_Click(object sender, RoutedEventArgs e)
        {
            TextScrollViewer.ScrollToVerticalOffset(TextScrollViewer.ExtentHeight);
        }
    }
}