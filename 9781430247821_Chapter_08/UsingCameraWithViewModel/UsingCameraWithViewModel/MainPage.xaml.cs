using System;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using UsingCameraWithViewModel.ViewModels;

namespace UsingCameraWithViewModel
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private CameraViewModel _vm;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _vm = new CameraViewModel();
            this.LayoutRoot.DataContext = _vm;

            CameraButtons.ShutterKeyPressed += CameraButtons_ShutterKeyPressed;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.LayoutRoot.DataContext = null;
            _vm.Dispose();
            _vm = null;

            CameraButtons.ShutterKeyPressed -= CameraButtons_ShutterKeyPressed;

            base.OnNavigatedFrom(e);
        }

        void CameraButtons_ShutterKeyPressed(object sender, System.EventArgs e)
        {
            string captureName = "picture" +
                DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
            _vm.Capture(captureName);
        }
    }
}