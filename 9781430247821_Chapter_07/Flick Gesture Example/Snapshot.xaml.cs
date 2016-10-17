using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FlickGestureExample
{
    // http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207076(v=vs.105).aspx march 15, 2013

    public partial class Snapshot : UserControl
    {
        public Snapshot()
        {
            InitializeComponent();
        }

        private void GestureListener_GestureBegin(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            Canvas canvas = this.Parent as Canvas;
            if (canvas != null)
            {
                var topIndex = canvas.Children
                    .Where(el => el.GetType().Equals(typeof(Snapshot)))
                    .Max(el => Canvas.GetZIndex(el));
                Canvas.SetZIndex(this, topIndex + 1);
                e.Handled = true;
            }
        }


        private void GestureListener_DragDelta(object sender, Microsoft.Phone.Controls.DragDeltaGestureEventArgs e)
        {

            CompositeTransform transform =
                this.RenderTransform as CompositeTransform;
            transform.TranslateX += e.HorizontalChange;
            transform.TranslateY += e.VerticalChange;
            // stop handling to prevent all
            // images under touch point from being dragged
            e.Handled = true;
        }
        private void GestureListener_Flick(object sender, Microsoft.Phone.Controls.FlickGestureEventArgs e)
        {

            CompositeTransform transform =
                this.RenderTransform as CompositeTransform;

            DoubleAnimation animationX = new DoubleAnimation()
            {
                EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                To = transform.TranslateX + (e.HorizontalVelocity / 10)
            };
            DoubleAnimation animationY = new DoubleAnimation()
            {
                EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                To = transform.TranslateY + (e.VerticalVelocity / 10)
            };
            Storyboard storyBoard = new Storyboard()
            {
                Duration = new Duration(new System.TimeSpan(0, 0, 0, 0, 250)),
            };

            storyBoard.Children.Add(animationX);
            storyBoard.Children.Add(animationY);
            Storyboard.SetTarget(animationX, transform);
            Storyboard.SetTarget(animationY, transform);
            Storyboard.SetTargetProperty(animationX, new PropertyPath("TranslateX"));
            Storyboard.SetTargetProperty(animationY, new PropertyPath("TranslateY"));
            storyBoard.Begin();
            e.Handled = true;
        }

        private void GestureListener_PinchStarted(object sender, Microsoft.Phone.Controls.PinchStartedGestureEventArgs e)
        {

        }

        private void GestureListener_PinchDelta(object sender, Microsoft.Phone.Controls.PinchGestureEventArgs e)
        {

            CompositeTransform transform =
                this.RenderTransform as CompositeTransform;

            transform.Rotation = e.TotalAngleDelta;

            e.Handled = true;
        }

        private void GestureListener_PinchCompleted(object sender, Microsoft.Phone.Controls.PinchGestureEventArgs e)
        {

        }
    }
}