using Microsoft.Phone.Controls;

namespace SavingAndRestoringPageState
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MyPageViewModel _myPageViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.State["MyPageViewModel"] = _myPageViewModel;
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            _myPageViewModel = this.State.ContainsKey("MyPageViewModel") ?
                this.State["MyPageViewModel"] as MyPageViewModel : new MyPageViewModel();
            this.DataContext = _myPageViewModel;
            base.OnNavigatedTo(e);
        }

        //protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    this.State["Address"] = "123 Pleasant Way";
        //    base.OnNavigatedFrom(e);
        //}
        //protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    string address = this.State.ContainsKey("Address") ?
        //        this.State["Address"].ToString() : String.Empty;
        //    base.OnNavigatedTo(e);
        //}
    }
}