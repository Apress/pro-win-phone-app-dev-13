using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ManipulationEvents_SimpleExample
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            // hook up manipulation events
            this.ManipulationStarted += MainPage_ManipulationStarted;
            this.ManipulationDelta += MainPage_ManipulationDelta;
            this.ManipulationCompleted += MainPage_ManipulationCompleted;
        }

        // user has started manipulation, change outline to red
        void MainPage_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Ellipse ellipse = e.ManipulationContainer as Ellipse;
            if (ellipse != null)
            {
                ellipse.Stroke = new SolidColorBrush(Colors.Red);
            }
        }

        // element is being dragged, provide new translate coordinates
        void MainPage_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Ellipse ellipse = e.ManipulationContainer as Ellipse;
            if (ellipse != null)
            {
                TranslateTransform transform = ellipse.RenderTransform as TranslateTransform;
                transform.X += e.DeltaManipulation.Translation.X;
                transform.Y += e.DeltaManipulation.Translation.Y;
            }
        }

        // element is dropped, make the outline transparent
        void MainPage_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Ellipse ellipse = e.ManipulationContainer as Ellipse;
            if (ellipse != null)
            {
                ellipse.Stroke = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}