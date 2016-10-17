using System;
using Microsoft.Devices.Sensors;

namespace ShakeGestures.Classes
{
    public class Shake : IDisposable
    {
        private Accelerometer _accelerometer;
        private AccelerometerReading _lastReading;
        public float ReadingThreshhold { get; set; }
        public int CountThreshold { get; set; }
        private int _shakeCount;

        public static bool IsSupported
        {
            get { return Accelerometer.IsSupported; }
        }
        public event EventHandler<SensorReadingEventArgs<ShakeReading>> CurrentValueChanged;

        public Shake()
        {
            _accelerometer = new Accelerometer();
            _accelerometer.CurrentValueChanged += _accelerometer_CurrentValueChanged;
        }

        void _accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            // if the difference between before/now acceleration X values is over the threshold,
            // bump the count.
            if (Math.Abs(_lastReading.Acceleration.X - e.SensorReading.Acceleration.X) > ReadingThreshhold)
            {
                _shakeCount++;
            }

            // if the number of shakes is over the threshold, the device is now official "shaken"
            bool shaken = false;
            if (_shakeCount > CountThreshold)
            {
                shaken = true;
                _shakeCount = 0; // reset
            }

            // if the phone is shaken and CurrentValueChanged is subscribed to,
            // fire the event handler.
            if (shaken && CurrentValueChanged != null)
            {
                CurrentValueChanged(this,
                    new SensorReadingEventArgs<ShakeReading>()
                    {
                        SensorReading = new ShakeReading() { Timestamp = e.SensorReading.Timestamp }
                    });
            }

            _lastReading = e.SensorReading;
        }

        public void Start()
        {
            _accelerometer.Start();
        }

        public void Stop()
        {
            _accelerometer.Stop();
        }

        public void Dispose()
        {
            _accelerometer.Stop();
            _accelerometer.CurrentValueChanged -= _accelerometer_CurrentValueChanged;
            _accelerometer.Dispose();
            _accelerometer = null;
        }
    }
}
