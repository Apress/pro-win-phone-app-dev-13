using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace TheTouchObject
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            const string format = "Action: {0}\n # Points: {1}\n Position: x {2} y {3}\n Size: w {4} h {5}"; 

            TouchPointCollection points = e.GetTouchPoints(this);
            TouchPoint point = e.GetPrimaryTouchPoint(this);
            Point position = point.Position;
            Size size = point.Size;
            TouchAction action = point.Action;
            UIElement touchedElement = point.TouchDevice.DirectlyOver;
            var actionName = action.ToString(); 
            status.Text = String.Format(format,
                new object[] {actionName, points.Count, position.X, position.Y, size.Width, size.Height }); 
        }
    }
}