using System;
using System.Windows;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public DeleteTaskCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedTask != null;
        }

        public void Execute(object parameter)
        {
            if (MessageBox.Show("Are you sure you want to delete this task?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _viewModel.SelectedTDL.Tasks.Remove(_viewModel.SelectedTask);
                _viewModel.SelectedTask = null;
                _viewModel.NotifyPropertyChanged("SelectedTDL");
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
