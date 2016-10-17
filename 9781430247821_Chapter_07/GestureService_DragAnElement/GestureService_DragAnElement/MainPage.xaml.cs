using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace GestureService_DragAnElement
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GestureListener_GestureBegin(object sender,
            Microsoft.Phone.Controls.GestureEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            if (ellipse != null)
            {
                ellipse.Stroke = new SolidColorBrush(Colors.Red);
            }
        }

        private void GestureListener_GestureCompleted(object sender,
          Microsoft.Phone.Controls.GestureEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            if (ellipse != null)
            {
                ellipse.Stroke = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void GestureListener_DragStarted(object sender, DragStartedGestureEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            if (ellipse != null)
            {
                ellipse.Fill.Opacity = 0.5;
            }
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            if (ellipse != null)
            {
                TranslateTransform translateTransform =
                    ellipse.RenderTransform as TranslateTransform;
                translateTransform.X += e.HorizontalChange;
                translateTransform.Y += e.VerticalChange;
            }
        }

        private void GestureListener_DragCompleted(object sender,
          DragCompletedGestureEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            if (ellipse != null)
            {
                ellipse.Fill.Opacity = 1;
            }
        }

    }
}