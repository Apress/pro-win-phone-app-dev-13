using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GestureService_FlickAndRotateElement.Extensions;
using GestureService_FlickAndRotateElement.ViewModels;

namespace GestureService_FlickAndRotateElement
{
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LayoutRoot.DataContext = new PicturesViewModel();
        }

        private void GestureListener_GestureBegin(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            // find the ContentPresenter element under the touch
            var touchedElement = (e.OriginalSource as DependencyObject).Ancestor<ContentPresenter>();

            // get all the other content presenter elements.
            // these are the elements hosted by the canvas in the ItemsControl
            var itemElements = this.LayoutRoot.Descendants<ContentPresenter>();
            // get the topmost z-index, increment and assign to the touched element
            var topIndex = itemElements
                .Max(item => Canvas.GetZIndex(item));
            Canvas.SetZIndex(touchedElement, topIndex + 1);
            e.Handled = true;
        }

        private void GestureListener_DragDelta(object sender, Microsoft.Phone.Controls.DragDeltaGestureEventArgs e)
        {
            // find the element user control being dragged
            var element = (e.OriginalSource as DependencyObject).Ancestor<Grid>();
            // get the Snapshot's Transform element and adjust the new coordinates
            CompositeTransform transform =
                element.RenderTransform as CompositeTransform;
            transform.TranslateX += e.HorizontalChange;
            transform.TranslateY += e.VerticalChange;
            // stop handling to prevent all
            // images under touch point from being dragged
            e.Handled = true;
        }

        private void GestureListener_Flick(object sender, Microsoft.Phone.Controls.FlickGestureEventArgs e)
        {
            // find the element being flicked
            var element = (e.OriginalSource as DependencyObject).Ancestor<Grid>();
            // get the element's Transform and calculate the new coordinates
            CompositeTransform transform =
                element.RenderTransform as CompositeTransform;
            // divide by 10 to tone down the amount of inertia
            var x = transform.TranslateX + (e.HorizontalVelocity / 10);
            var y = transform.TranslateY + (e.VerticalVelocity / 10);

            // animate the flick
            transform.Animate(new Dictionary<string, double>()
            {
                {"TranslateX", x},
                {"TranslateY", y}
            });
            e.Handled = true;
        }

        private void GestureListener_PinchDelta(object sender, Microsoft.Phone.Controls.PinchGestureEventArgs e)
        {
            // find the element being zoomed or rotated
            var element = (e.OriginalSource as DependencyObject).Ancestor<Grid>();
            // get the element's Transform and adjust to the new scale and rotation
            CompositeTransform transform =
                element.RenderTransform as CompositeTransform;
            transform.ScaleX = e.DistanceRatio;
            transform.ScaleY = e.DistanceRatio;
            transform.Rotation = e.TotalAngleDelta;
            e.Handled = true;
        }

        private void GestureListener_DoubleTap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            // find the element being double tapped
            var element = (e.OriginalSource as DependencyObject).Ancestor<Grid>();

            // get the transform of the element
            CompositeTransform transform =
                element.RenderTransform as CompositeTransform;

            // calculate left and top to place the element in the center.
            var left = (LayoutRoot.ActualWidth - element.ActualWidth) / 2;
            var top = (LayoutRoot.ActualHeight - element.ActualHeight) / 2;

            // animate movement, scale and rotation
            transform.Animate(new Dictionary<string, double>()
            {
                {"TranslateX", left},
                {"TranslateY", top},
                {"ScaleX", 1.5},
                {"ScaleY", 1.5},
                {"Rotation", 0}
            });

            e.Handled = true;
        }
    }
}