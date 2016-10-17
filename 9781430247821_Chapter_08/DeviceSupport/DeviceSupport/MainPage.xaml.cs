using DeviceSupport.ViewModels;
using Microsoft.Phone.Controls;

namespace DeviceSupport
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.DataContext = new DeviceInformationViewModel(); 
        }
    }
}