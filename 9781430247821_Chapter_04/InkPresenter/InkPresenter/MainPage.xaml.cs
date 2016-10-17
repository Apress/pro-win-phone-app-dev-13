using System.Windows.Ink;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace InkPresenter
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Stroke _stroke;

        private void InkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _stroke = new Stroke();
            _stroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(InkCanvas));
            InkCanvas.Strokes.Add(_stroke);
        }

        private void InkCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_stroke != null)
            {
                _stroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(InkCanvas));
            }
        }

        private void InkCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _stroke = null;
        }

        private void InkCanvas_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            InkCanvas.Strokes.Clear();
        }
    }
}