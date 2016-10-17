using System;
using System.Windows.Input;
using Microsoft.Phone.Tasks;

namespace UsingCommandsWithMenuItem
{
    public class SearchCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (parameter != null) && (parameter is string);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            SearchTask searchTask = new SearchTask();
            searchTask.SearchQuery = parameter as string;
            searchTask.Show();
        }
    }
}
