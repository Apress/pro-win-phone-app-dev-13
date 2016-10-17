using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace CollectionChangeNotification
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Movies movies = new Movies();
        public MainPage()
        {
            InitializeComponent();
            this.MoviesList.ItemsSource = movies;
        }

        private void ChangeCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            this.movies.Add(new Movie()
            {
                Title = "New Movie",
                Quote = "Have you seen it?",
                Year = DateTime.Today.Year
            });
        }
    }
}