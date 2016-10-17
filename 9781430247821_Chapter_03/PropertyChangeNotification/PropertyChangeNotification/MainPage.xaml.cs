using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PropertyChangeNotification.Resources;

namespace PropertyChangeNotification
{

    public partial class MainPage : PhoneApplicationPage
    {
        private Movie movie;

        public MainPage()
        {
            InitializeComponent();

            movie = new Movie()
            {
                Title = "The Matrix",
                Quote = "Why oh why didn't I take the BLUE pill?",
                Year = 1999
            };
            ContentPanel.DataContext = movie; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.movie.Quote = "You've been living in a dream world, Neo."; 
        }
    }
}