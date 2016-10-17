using System.Windows.Navigation;
using CombinedMotion.ViewModels;
using Microsoft.Phone.Controls;

namespace CombinedMotion
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new MotionViewModel();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            (this.DataContext as MotionViewModel).Dispose();
            base.OnNavigatedFrom(e);
        }
    }
}