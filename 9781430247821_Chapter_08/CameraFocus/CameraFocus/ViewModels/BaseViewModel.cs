﻿using System.ComponentModel;

namespace CameraFocus.ViewModels
{
public class BaseViewModel : INotifyPropertyChanged
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
