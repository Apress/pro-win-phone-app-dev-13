using System;
using System.Windows.Input;
using Microsoft.Phone.Tasks;

namespace LongListSelectorWithContextMenu.Commands
{
public class SearchCommand : ICommand
{
    public bool CanExecute(object parameter)
    {
        return parameter != null;
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
