using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Core;
using Task_Manager.Models;

namespace Task_Manager.ViewModels
{
    public class FindTasksWindowVM : ObservableObject
    {
        private readonly MainViewVM _mainViewModel;
        private string _searchText;
        private bool _isSearchInCurrentViewOnly;

        public FindTasksWindowVM(MainViewVM mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SearchCommand = new RelayCommand(OnSearch);
            CancelCommand = new RelayCommand(OnCancel);
            TaskList = new ObservableCollection<Task>();
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsSearchInCurrentViewOnly
        {
            get => _isSearchInCurrentViewOnly;
            set
            {
                _isSearchInCurrentViewOnly = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Task> TaskList { get; }

        public ICommand SearchCommand { get; }

        public ICommand CancelCommand { get; }

        private void OnSearch(object obj)
        {
            var allTasks = new List<Task>();
            CollectTasks(allTasks, _mainViewModel.Data.ItemsCollection);

            if (IsSearchInCurrentViewOnly)
            {
                allTasks = _mainViewModel.SelectedTDL.Tasks.ToList();
            }

            var filteredTasks = allTasks.Where(t => t.Name.Contains(SearchText) ||
                                                    t.Deadline.ToString("MM/dd/yyyy").Contains(SearchText))
                                        .Select(t => new { t.Name, Location = FindParentTDL(t).Name });

            //SearchResults = new ObservableCollection<dynamic>(filteredTasks);
        }

        private void CollectTasks(List<Task> tasks, ObservableCollection<TDL> collection)
        {
            foreach (var item in collection)
            {
                if (item is TDL tdl)
                {
                    CollectTasks(tasks, tdl.SubCollection);
                    tasks.AddRange(tdl.Tasks);
                }
            }
        }

        private TDL FindParentTDL(Task task)
        {
            foreach (var tdl in _mainViewModel.Data.ItemsCollection)
            {
                if (tdl.Tasks.Contains(task))
                {
                    return tdl;
                }
                else
                {
                    foreach (var subCollection in tdl.SubCollection)
                    {
                        if (subCollection.Tasks.Contains(task))
                        {
                            return subCollection;
                        }
                    }
                }
            }

            return null; // Parent TDL not found
        }

        private void OnCancel(object obj)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
