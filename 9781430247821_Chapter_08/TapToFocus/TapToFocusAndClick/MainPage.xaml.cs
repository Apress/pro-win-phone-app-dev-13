using System;
using System.Windows.Controls;
using TapToFocus.ViewModels;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using System.Windows.Input;

namespace TapToFocus
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
            CameraButtons.ShutterKeyHalfPressed += CameraButtons_ShutterKeyHalfPressed;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.LayoutRoot.DataContext = null;
            _vm.Dispose();
            _vm = null;

            CameraButtons.ShutterKeyPressed -= CameraButtons_ShutterKeyPressed;
            CameraButtons.ShutterKeyHalfPressed -= CameraButtons_ShutterKeyHalfPressed;

            base.OnNavigatedFrom(e);
        }

        void CameraButtons_ShutterKeyPressed(object sender, System.EventArgs e)
        {
            string captureName = "picture" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            _vm.Capture(captureName);
        }

        void CameraButtons_ShutterKeyHalfPressed(object sender, EventArgs e)
        {
            // place "focus brackets" graphic at screen center.
            Canvas.SetLeft(this.FocusBrackets,
                LayoutRoot.ActualWidth / 2 - (this.FocusBrackets.ActualWidth / 2));
            Canvas.SetTop(this.FocusBrackets,
                LayoutRoot.ActualHeight / 2 - (this.FocusBrackets.ActualHeight / 2));

            _vm.Focus();
        }

private void LayoutRoot_Tap_1(object sender, GestureEventArgs e)
{
    if (!_vm.IsFocusing)
    {
        System.Windows.Point point = e.GetPosition(this.LayoutRoot);
        double x = point.X / this.LayoutRoot.ActualWidth;
        double y = point.Y / this.LayoutRoot.ActualHeight;

        Dispatcher.BeginInvoke(() =>
        {
            Canvas.SetLeft(this.FocusBrackets, point.X - (this.FocusBrackets.ActualWidth / 2));
            Canvas.SetTop(this.FocusBrackets, point.Y - (this.FocusBrackets.ActualHeight / 2));
        });

        _vm.FocusAtPoint(x, y);
    }
}

        private void LayoutRoot_Hold_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string captureName = "picture" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            _vm.Capture(captureName);
        }
    }
}