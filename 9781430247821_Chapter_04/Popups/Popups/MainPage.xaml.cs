using System.Windows;
using Microsoft.Phone.Controls;

namespace Popups
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = true;
        }

        private void MyPopup_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MyPopup.IsOpen = false;
        }
    }
}