using System;
using System.Windows.Input;
using Task_Manager.ViewModels;
using TaskStatus = Task_Manager.Models.Task.TaskStatus;

namespace Task_Manager.Commands
{
    public class SetDoneCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public SetDoneCommand(MainViewVM viewModel)
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
            if (_viewModel.SelectedTask != null)
            {
                _viewModel.SelectedTask.Status = TaskStatus.Done;
                _viewModel.SelectedTask.CompletionDate = DateTime.Now;
                _viewModel.NotifyPropertyChanged("SelectedTask");
            }
        }
    }
}

