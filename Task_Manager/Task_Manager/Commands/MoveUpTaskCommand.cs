using System;
using System.Windows;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class MoveUpTaskCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public MoveUpTaskCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedTask != null;
        }

        public void Execute(object parameter)
        {
            int currentIndex = _viewModel.SelectedTDL.Tasks.IndexOf(_viewModel.SelectedTask);
            if (currentIndex > 0)
            {
                _viewModel.SelectedTDL.Tasks.Move(currentIndex, currentIndex - 1);
                _viewModel.NotifyPropertyChanged("SelectedTDL");
            }
            else
            {
                MessageBox.Show("Cannot move task up any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
