using System;
using System.ComponentModel;

namespace BindingThreeStateButtons
{
public class ProjectViewModel : INotifyPropertyChanged
{
    public enum ProjectStatus { Unknown = 0, Started = 1, NotStarted = 2 };

    private ProjectStatus _status;

    public bool? Started
    {
        get
        {
            switch (this._status)
            {
                case ProjectStatus.Started: return true;
                case ProjectStatus.NotStarted: return false;
                default: return null; // unknown
            }
        }
        set
        {
            switch (value)
            {
                case true: { _status = ProjectStatus.Started; break; }
                case false: { _status = ProjectStatus.NotStarted; break; }
                case null: { _status = ProjectStatus.Unknown; break; }
            }
            OnPropertyChanged("Started");
            OnPropertyChanged("StatusCaption"); 
        }
    }

    public string StatusCaption
    {
        get
        {
            return Enum.GetName(typeof(ProjectStatus), this._status);
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
}
