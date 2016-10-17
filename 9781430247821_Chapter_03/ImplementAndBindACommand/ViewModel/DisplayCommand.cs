using System;
using System.Windows;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class DisplayCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;
            else
                return !(parameter as Category).Title.Contains("Clothing");
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
                MessageBox.Show((parameter as Category).Title);
        }
    }
}
