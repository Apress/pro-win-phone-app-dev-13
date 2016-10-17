using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MultiScaleImage
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void msi_ImageOpenFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Log("ImageOpenFailed");
        }

        private void msi_ImageOpenSucceeded(object sender, RoutedEventArgs e)
        {
            Log("ImageOpenSucceeded");
        }

        private void msi_ImageFailed(object sender, RoutedEventArgs e)
        {
            Log("ImageFailed");
        }

        bool viewPortChanging;

        private void msi_ViewportChanged(object sender, RoutedEventArgs e)
        {
            var message = "ViewportChanged: " + msi.ViewportOrigin.X.ToString("F3") + ", " + msi.ViewportOrigin.Y.ToString("F3");
            if (!viewPortChanging)
            {
                Log(message);
                viewPortChanging = true;
            }
        }

        private void msi_MotionFinished(object sender, RoutedEventArgs e)
        {
            Log("MotionFinished");
            Log("ViewportChanged: " + msi.ViewportOrigin.X.ToString("F3") + ", " + msi.ViewportOrigin.Y.ToString("F3"));
            viewPortChanging = false; 
        }

        private void ZoomOutClick(object sender, EventArgs e)
        {
            msi.ZoomAboutLogicalPoint(0.8, 0.5, 0.5);
        }

        private void ZoomInClick(object sender, EventArgs e)
        {
            msi.ZoomAboutLogicalPoint(1.2, 0.5, 0.5);
        }

        private void msi_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // get the pointer position on the msi element
            var pos = e.GetPosition(msi);

            // offset by half the msi dimensions
            var x = -(pos.X - (msi.ActualWidth / 2));
            var y = -(pos.Y - (msi.ActualHeight / 2));

            // assign the new viewport origin
            msi.ViewportOrigin = msi.ElementToLogicalPoint(new Point(x, y));
        }

        private void Log(string message)
        {
            StatusText.Text = message + "\n" + StatusText.Text;
        }
    }
}