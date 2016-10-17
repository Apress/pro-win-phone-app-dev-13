using System.ComponentModel;

namespace BaseVM
{
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
}
