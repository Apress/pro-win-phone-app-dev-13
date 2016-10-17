using Microsoft.Phone.Controls;
using PersistUserEntry.ViewModels;

namespace PersistUserEntry
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private UserViewModel _vm;

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.State["UserViewModel"] = _vm;
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            _vm = this.State.ContainsKey("UserViewModel") ?
                this.State["UserViewModel"] as UserViewModel : new UserViewModel();
            this.DataContext = _vm;
            base.OnNavigatedTo(e);
        }
    }
}