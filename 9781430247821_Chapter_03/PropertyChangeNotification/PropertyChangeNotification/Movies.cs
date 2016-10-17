using System.ComponentModel;

namespace PropertyChangeNotification
{
public class Movie : INotifyPropertyChanged
{
    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            NotifyPropertyChanged("Title");
        }
    }

    private string _quote;
    public string Quote
    {
        get { return _quote; }
        set
        {
            _quote = value;
            NotifyPropertyChanged("Quote");
        }
    }

    private int _year;
    public int Year
    {
        get { return _year; }
        set
        {
            _year = value;
            NotifyPropertyChanged("Year");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
}
