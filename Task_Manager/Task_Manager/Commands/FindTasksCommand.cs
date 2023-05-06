using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class FindTasksCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public FindTasksCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Create the FindTasksWindow
            var window = new Views.FindTasksWindow();
            var viewModel = new FindTasksWindowVM(_viewModel);
            window.DataContext = viewModel;

            // Show the FindTasksWindow as a dialog
            var result = window.ShowDialog();

            //if (result == true)
            //{
            //    // Get the search text and the flag to indicate if the search should be performed only in the selected TDL
            //    string searchText = viewModel.SearchText;
            //    bool isSearchInCurrentViewOnly = viewModel.IsSearchInCurrentViewOnly;

            //    // Perform the search

            //    var searchResults = _viewModel.Data.ItemsCollection
            //        .Where(tdl => !isSearchInCurrentViewOnly || tdl == _viewModel.SelectedTDL)
            //        .SelectMany(tdl => tdl.Tasks)
            //        .Where(task => task.Name.Contains(searchText) || task.Deadline.ToString().Contains(searchText)).ToList();

            //    // Update the search results in the FindTasksWindow
            //    viewModel.SearchResults = searchResults;
            //}
        }

        public event EventHandler CanExecuteChanged;
    }
}
