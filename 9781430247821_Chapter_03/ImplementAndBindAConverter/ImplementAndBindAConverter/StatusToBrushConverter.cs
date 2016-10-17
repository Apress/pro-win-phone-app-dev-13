using System;
using System.Windows.Data;
using System.Windows.Media;

namespace ImplementAndBindAConverter
{
    public class StatusToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            switch ((Status)value)
            {
                case Status.Complete: return new SolidColorBrush(Colors.Black);
                case Status.Deferred: return new SolidColorBrush(Colors.LightGray);
                case Status.InProgress: return new SolidColorBrush(Colors.Green);
                case Status.NotStarted: return new SolidColorBrush(Colors.Red);
                default: return Colors.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
