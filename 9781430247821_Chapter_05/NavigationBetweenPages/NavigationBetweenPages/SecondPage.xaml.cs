using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace NavigationBetweenPages
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MessageBox.Show("NavigatedTo: " + e.Uri);
            base.OnNavigatedTo(e);
        }

        protected override void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            MessageBox.Show("Fragment: " + e.Fragment);
            base.OnFragmentNavigation(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("You have unsaved data, do you want to exit?", "Unsaved data",
                MessageBoxButton.OKCancel) == MessageBoxResult.Cancel;
            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MainPage mainPage = e.Content as MainPage;
            if (mainPage != null)
                mainPage.StatusText.Text = "A message from SecondPage OnNavigatedFrom";
            base.OnNavigatedFrom(e);
        }

    }
}