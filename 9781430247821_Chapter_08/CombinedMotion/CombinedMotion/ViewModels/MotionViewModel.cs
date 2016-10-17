using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Devices.Sensors;

namespace CombinedMotion.ViewModels
{
    public class MotionViewModel : IDisposable
    {
        private Motion _motion;
        public Readings Readings { get; private set; }

        public MotionViewModel()
        {
            if (Motion.IsSupported)
            {
                _motion = new Motion();
                _motion.TimeBetweenUpdates = new System.TimeSpan(0, 0, 1);

                this.Readings = new Readings(
                    new List<Reading>() 
                    { 
                        new Reading() { SensorType = SensorType.Attitude, Name = "Yaw" }, 
                        new Reading() { SensorType = SensorType.Attitude, Name = "Pitch" }, 
                        new Reading() { SensorType = SensorType.Attitude, Name = "Roll" }, 
                        new Reading() { SensorType = SensorType.DeviceAcceleration, Name = "X" },
                        new Reading() { SensorType = SensorType.DeviceAcceleration, Name = "Y" },
                        new Reading() { SensorType = SensorType.DeviceAcceleration, Name = "Z" },
                        new Reading() { SensorType = SensorType.DeviceRotationRate, Name = "X" },
                        new Reading() { SensorType = SensorType.DeviceRotationRate, Name = "Y" },
                        new Reading() { SensorType = SensorType.DeviceRotationRate, Name = "Z" },
                        new Reading() { SensorType = SensorType.Gravity, Name = "X" },
                        new Reading() { SensorType = SensorType.Gravity, Name = "Y" },
                        new Reading() { SensorType = SensorType.Gravity, Name = "Z" },
                    });

                _motion.CurrentValueChanged += _motion_CurrentValueChanged;
                _motion.Start();
            }
        }

        void _motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                this.Readings[SensorType.Attitude, "Yaw"].Value = e.SensorReading.Attitude.Yaw;
                this.Readings[SensorType.Attitude, "Pitch"].Value = e.SensorReading.Attitude.Pitch;
                this.Readings[SensorType.Attitude, "Roll"].Value = e.SensorReading.Attitude.Roll;

                this.Readings[SensorType.DeviceAcceleration, "X"].Value =
                    e.SensorReading.DeviceAcceleration.X;
                this.Readings[SensorType.DeviceAcceleration, "Y"].Value =
                    e.SensorReading.DeviceAcceleration.Y;
                this.Readings[SensorType.DeviceAcceleration, "Z"].Value =
                    e.SensorReading.DeviceAcceleration.Z;

                this.Readings[SensorType.DeviceRotationRate, "X"].Value =
                    e.SensorReading.DeviceRotationRate.X;
                this.Readings[SensorType.DeviceRotationRate, "Y"].Value =
                    e.SensorReading.DeviceRotationRate.Y;
                this.Readings[SensorType.DeviceRotationRate, "Z"].Value =
                    e.SensorReading.DeviceRotationRate.Z;

                this.Readings[SensorType.Gravity, "X"].Value = e.SensorReading.Gravity.X;
                this.Readings[SensorType.Gravity, "Y"].Value = e.SensorReading.Gravity.Y;
                this.Readings[SensorType.Gravity, "Z"].Value = e.SensorReading.Gravity.Z;
            });
        }

        public void Dispose()
        {
            if (Motion.IsSupported)
            {
                _motion.Stop();
                _motion.CurrentValueChanged -= _motion_CurrentValueChanged;
                _motion.Dispose();
                _motion = null;
            }
        }
    }
}
