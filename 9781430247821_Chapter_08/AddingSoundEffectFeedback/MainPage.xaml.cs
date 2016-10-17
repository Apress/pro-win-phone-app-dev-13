using System;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using AddingSoundEffectFeedback.ViewModels;
using System.IO;
using System.Windows.Resources;
using System.Windows;
using System.Windows.Controls;

namespace AddingSoundEffectFeedback
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
            string captureName = "picture" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            _vm.Capture(captureName);
        }
    }
}