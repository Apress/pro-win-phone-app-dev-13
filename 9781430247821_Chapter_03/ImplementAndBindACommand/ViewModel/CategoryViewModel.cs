using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        public CategoryViewModel()
        {
            this.CategoriesCollection = new ObservableCollection<Category>(new Categories());
            this.CategoryTitle = "categories";
            this.CategoryDescription = "store departments";

            this.DisplayCommand = new DisplayCommand(); 
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string CategoryTitle
        {
            get { return this.title; }
            set
            {
                this.title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string description;
        public string CategoryDescription
        {
            get { return this.description; }
            set
            {
                this.description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public ObservableCollection<Category> CategoriesCollection { get; set; }

        public DisplayCommand DisplayCommand { get; set; }

    }

}
