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
            var viewModel = new FindTasksViewVM(_viewModel);
            window.DataContext = viewModel;

            // Show the FindTasksWindow as a dialog
            var result = window.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;
    }
}
