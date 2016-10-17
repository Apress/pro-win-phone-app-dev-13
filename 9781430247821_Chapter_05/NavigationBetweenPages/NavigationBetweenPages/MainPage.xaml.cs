using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NavigationBetweenPages.Resources;

namespace NavigationBetweenPages
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneAppFrame_Click(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
         }

        private void PageFragment_Click(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/SecondPage.xaml#detail", UriKind.Relative));
        }

        private void NavService_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

    }
}