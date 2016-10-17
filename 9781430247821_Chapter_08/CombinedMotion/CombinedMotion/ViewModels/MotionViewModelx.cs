using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using Microsoft.Devices.Sensors;
using System.Linq;
using CombinedMotion.Classes;

namespace CombinedMotion.ViewModels
{
    public class SensorReading : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SensorReadings
    {
        public string Name { get; internal set; }
        public ObservableCollection<SensorReading> Readings { get; internal set; }
    }

    public class MotionViewModelx : IDisposable
    {
        private Motion _motion;
        private Dispatcher _dispatcher;
        public ObservableCollection<Group<string, SensorReadings>> GroupedReadings{ get; set; }
        public string Title { get { return "motion"; } }


        public MotionViewModelx(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _motion = new Motion();
            if (Motion.IsSupported)
            {
                var sensorReadings = (new SensorReadings()
                {
                    Name = "Attitude",
                    Readings = new ObservableCollection<SensorReading>() {
                        new SensorReading() { Name = "Yaw" },
                        new SensorReading() { Name = "Pitch" },
                        new SensorReading() { Name = "Roll" } }
                });

                this.GroupedReadings =
                    from reading in sensorReadings.Readings
                    group reading by reading.Name into grouped
                    select new Group<string, SensorReadings>(grouped.Key, grouped) 

                _motion.CurrentValueChanged += _motion_CurrentValueChanged;
            }
            _motion.Start();
        }

        public void _motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            this._dispatcher.BeginInvoke(() =>
            {
     
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
