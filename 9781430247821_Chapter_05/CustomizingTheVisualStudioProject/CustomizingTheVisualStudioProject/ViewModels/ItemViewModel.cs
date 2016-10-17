using System;
using System.ComponentModel;

namespace CustomizingTheVisualStudioProject.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _uniqueId;
        public string UniqueId
        {
            get { return _uniqueId; }
            set
            {
                if (value != _uniqueId)
                {
                    _uniqueId = value;
                    NotifyPropertyChanged("UniqueId");
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private double? _userRating;
        public Double? UserRating
        {
            get { return _userRating; }
            set
            {
                if (value != _userRating)
                {
                    _userRating = value;
                    NotifyPropertyChanged("UserRating");
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}