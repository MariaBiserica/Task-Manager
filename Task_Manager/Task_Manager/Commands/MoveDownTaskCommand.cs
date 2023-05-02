using System;
using System.Windows;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class MoveDownTaskCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public MoveDownTaskCommand(MainViewVM viewModel)
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
            if (currentIndex < _viewModel.SelectedTDL.Tasks.Count - 1)
            {
                _viewModel.SelectedTDL.Tasks.Move(currentIndex, currentIndex + 1);
                _viewModel.NotifyPropertyChanged("SelectedTDL");
            }
            else
            {
                MessageBox.Show("Cannot move task down any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
