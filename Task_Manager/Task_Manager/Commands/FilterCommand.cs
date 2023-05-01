using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;
using static Task_Manager.ViewModels.MainViewVM;
using Task = Task_Manager.Models.Task;
using TaskStatus = Task_Manager.Models.Task.TaskStatus;

namespace Task_Manager.Commands
{
    public class FilterCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public FilterCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DateTime currentDate = DateTime.Now;
            switch ((FilterType)parameter)
            {
                case FilterType.Category:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter category type", "Filter by Category", "");
                    if (!string.IsNullOrEmpty(input))
                    {
                        ObservableCollection<Task> filteredTasks = new ObservableCollection<Task>();
                        foreach (var task in _viewModel.SelectedTDL.Tasks)
                        {
                            if (task.Category == input)
                            {
                                filteredTasks.Add(task);
                            }
                        }
                        _viewModel.SelectedTDL.Tasks = filteredTasks;
                        _viewModel.NotifyPropertyChanged("SelectedTDL");
                    }
                    break;
                case FilterType.Done:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.SelectedTDL.Tasks.Where(t => t.Status == TaskStatus.Done));
                    _viewModel.NotifyPropertyChanged("SelectedTDL");
                    break;
                case FilterType.Delayed:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.SelectedTDL.Tasks.Where(t => t.CompletionDate > t.Deadline));
                    _viewModel.NotifyPropertyChanged("SelectedTDL");
                    break;
                case FilterType.Overdue:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.SelectedTDL.Tasks.Where(t => currentDate > t.Deadline && t.Status != TaskStatus.Done));
                    _viewModel.NotifyPropertyChanged("SelectedTDL");
                    break;
                case FilterType.DueFuture:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.SelectedTDL.Tasks.Where(t => currentDate < t.Deadline && t.Status != TaskStatus.Done));
                    _viewModel.NotifyPropertyChanged("SelectedTDL");
                    break;
                case FilterType.None:
                    _viewModel.SelectedTDL.Tasks = new ObservableCollection<Task>(_viewModel.OriginalTasks);
                    _viewModel.NotifyPropertyChanged("SelectedTDL");
                    break;
            }
            
        }
    }
}
