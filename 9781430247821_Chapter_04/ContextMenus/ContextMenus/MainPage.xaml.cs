using System.Windows;
using Microsoft.Phone.Controls;

namespace ContextMenus
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Context_Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            MessageBox.Show(item.Tag.ToString()); 
        }
     }
}