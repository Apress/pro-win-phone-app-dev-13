using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CustomizingTheVisualStudioProject.Models;

namespace CustomizingTheVisualStudioProject.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            LoadData();
        }

        public ObservableCollection<ItemViewModel> AllItems { get; private set; }
        public ObservableCollection<ItemViewModel> RatedItems { get; private set; }

        private string _sectionTitle = "BING PHONEBOOK (RUN TIME)";
        public string SectionTitle
        {
            get { return _sectionTitle; }
            set
            {
                if (value != _sectionTitle)
                {
                    _sectionTitle = value;
                    NotifyPropertyChanged("SectionTitle");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Phonebook bingPhoneBook = new Phonebook();
            var allItems = from r in bingPhoneBook.Items
                           select new ItemViewModel()
                           {
                               UniqueId = r.UniqueId,
                               Title = r.Title,
                               PhoneNumber = r.PhoneNumber,
                               UserRating = r.UserRating
                           };

            this.AllItems = new ObservableCollection<ItemViewModel>(allItems);

            var ratedItems = from r in this.AllItems
                             where r.UserRating.HasValue
                             orderby r.UserRating descending
                             select r;

            this.RatedItems = new ObservableCollection<ItemViewModel>(ratedItems);
            this.IsDataLoaded = true;
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
