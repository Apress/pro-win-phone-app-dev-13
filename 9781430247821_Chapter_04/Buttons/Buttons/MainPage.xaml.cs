using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace Buttons
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTask searchTask = new SearchTask();
            searchTask.SearchQuery = "Windows Phone 8";
            searchTask.Show();
        }

    }
}