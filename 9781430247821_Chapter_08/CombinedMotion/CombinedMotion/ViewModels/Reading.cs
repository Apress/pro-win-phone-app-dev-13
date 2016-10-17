
namespace CombinedMotion.ViewModels
{
    public class Reading : ViewModelBase
    {
        public SensorType SensorType { get; internal set; }
        public string Name { get; internal set; }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    }
}
