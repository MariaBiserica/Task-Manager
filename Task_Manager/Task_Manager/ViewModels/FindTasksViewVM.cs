using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Core;
using Task_Manager.Models;
using System.Windows.Documents;

namespace Task_Manager.ViewModels
{
    public class FindTasksViewVM : ObservableObject
    {
        private readonly MainViewVM _mainViewModel;

        public FindTasksViewVM(MainViewVM mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SearchCommand = new RelayCommand(OnSearch);
            CancelCommand = new RelayCommand(OnCancel);
            TaskList = new ObservableCollection<Task>();
        }

        private string _searchByName;
        public string SearchByName
        {
            get { return _searchByName; }
            set
            {
                _searchByName = value;
                NotifyPropertyChanged("SearchByName");
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }

        private ObservableCollection<Task> _searchResults;
        public ObservableCollection<Task> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                NotifyPropertyChanged("SearchResults");
            }
        }

        private bool _isSearchInCurrentViewOnly;
        public bool IsSearchInCurrentViewOnly
        {
            get => _isSearchInCurrentViewOnly;
            set
            {
                _isSearchInCurrentViewOnly = value;
                NotifyPropertyChanged("IsSearchInCurrentViewOnly");
            }
        }

        public ObservableCollection<Task> TaskList { get; }

        public ICommand SearchCommand { get; }

        public ICommand CancelCommand { get; }

        private void OnSearch(object obj)
        {
            var allTasks = new List<Task>();
            allTasks = CollectTasks(allTasks, _mainViewModel.Data.ItemsCollection);

            if (SearchByName == null)
            {
                SearchByName = "";
            }

            if (IsSearchInCurrentViewOnly)
            {
                allTasks = _mainViewModel.SelectedTDL.Tasks.ToList();
            }

            var filteredTasks = allTasks.Where(t => t.Name.Contains(SearchByName) ||
                                                    t.Deadline == SelectedDate).ToList();

            foreach (var task in filteredTasks)
            {
                task.Location = FindLocation(task);
            }

            SearchResults = new ObservableCollection<Task>(filteredTasks);
        }

        private List<Task> CollectTasks(List<Task> tasks, ObservableCollection<TDL> collection)
        {
            foreach (var item in collection)
            {
                if (item is TDL tdl)
                {
                    CollectTasks(tasks, tdl.SubCollection);
                    tasks.AddRange(tdl.Tasks);
                }
            }

            return tasks;
        }

        private string FindLocation(Task task)
        {
            string path = "";
            
            foreach (var tdl in _mainViewModel.Data.ItemsCollection)
            {
                path = tdl.Name;
                
                if (tdl.Tasks.Contains(task))
                {
                    return path;
                }
                else
                {
                    foreach (var subCollection in tdl.SubCollection)
                    {
                        if (subCollection.Tasks.Contains(task))
                        {
                            path = subCollection.Name + ">>" + path;
                            return path;
                        }
                    }
                }
            }

            return path;
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
