using System;
using System.Windows.Input;
using Microsoft.Phone.Tasks;

namespace Buttons
{
    public class SearchCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            SearchTask searchTask = new SearchTask();
            searchTask.SearchQuery = "Windows Phone 8";
            searchTask.Show();
        }
    }
}
