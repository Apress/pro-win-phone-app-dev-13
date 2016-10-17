using System;
using System.Windows;
using LongListSelectorWithContextMenu.ViewModels;
using Microsoft.Phone.Controls;

namespace LongListSelectorWithContextMenu
{
    public partial class MainPage : PhoneApplicationPage
    {
        private AppViewModel _viewModel = new AppViewModel();

        public MainPage()
        {
            InitializeComponent();
            LayoutRoot.DataContext = _viewModel.Astronomy;
        }

        private void Delete_Subject(object sender, System.Windows.RoutedEventArgs e)
        {
            var subjectViewModel = LayoutRoot.DataContext as SubjectViewModel<string>;

            subjectViewModel.DeleteSubject((sender as MenuItem).Tag as string);
        }

        private void astronomy_click(object sender, EventArgs e)
        {
            LayoutRoot.DataContext = _viewModel.Astronomy;
        }

        private void cooking_click(object sender, EventArgs e)
        {
            LayoutRoot.DataContext = _viewModel.Cooking;
        }

        private void languages_click(object sender, EventArgs e)
        {
            LayoutRoot.DataContext = _viewModel.Languages;
        }

        private void ContextMenu_Unloaded_1(object sender, RoutedEventArgs e)
        {
            var contextMenu = sender as ContextMenu;
            contextMenu.ClearValue(FrameworkElement.DataContextProperty);
        }
    }
}