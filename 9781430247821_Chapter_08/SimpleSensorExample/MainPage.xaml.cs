using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;

namespace Sensors
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Accelerometer _accelerometer;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (Accelerometer.IsSupported)
            {
                _accelerometer = new Accelerometer();
                _accelerometer.TimeBetweenUpdates = new TimeSpan(0, 0, 1);
                _accelerometer.CurrentValueChanged +=
                    accelerometer_CurrentValueChanged;
                try
                {
                    _accelerometer.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to start Accelerometer", MessageBoxButton.OK);
                }
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                StatusX.Text = String.Format("X: {0:N4}", e.SensorReading.Acceleration.X);
                StatusY.Text = String.Format("Y: {0:N4}", e.SensorReading.Acceleration.Y);
                StatusZ.Text = String.Format("Z: {0:N4}", e.SensorReading.Acceleration.Z);
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (Accelerometer.IsSupported)
            {
                _accelerometer.Stop();
                _accelerometer.CurrentValueChanged -= accelerometer_CurrentValueChanged;
                _accelerometer.Dispose();
                _accelerometer = null;
            }
            base.OnNavigatedFrom(e);
        }
    }
}