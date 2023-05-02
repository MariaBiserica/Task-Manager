using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Linq;
using Task_Manager.Commands;
using Task_Manager.Core;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;

namespace Task_Manager.ViewModels
{
    public class MainViewVM : ObservableObject
    {
        public MainViewVM()
        {
            Data = null;
            IsStatisticsPanelVisible = false;
            
            NewDatabaseCommand = new NewDatabaseCommand();
            LoadDatabaseCommand = new LoadDatabaseCommand(this);
            SaveDatabaseCommand = new SaveDatabaseCommand(this);
            CloseDatabaseCommand = new CloseDatabaseCommand(this);
            AddTDLCommand = new AddTDLCommand(this);
            EditTDLCommand = new EditTDLCommand(this);
            DeleteTDLCommand = new DeleteTDLCommand(this);
            MoveUpCommand = new MoveUpCommand(this);
            MoveDownCommand = new MoveDownCommand(this);
            ChangePathCommand = new ChangePathCommand(this);
            SortCommand = new SortCommand();
            FilterCommand = new FilterCommand(this);
            HelpCommand = new HelpCommand();
        }
        public DataModelVM Data { get; set; }

        private TDL selectedTDL;
        public TDL SelectedTDL
        {
            get
            {
                return selectedTDL;
            }
            set 
            {
                if (selectedTDL != value)
                {
                    selectedTDL = value;
                    NotifyPropertyChanged("SelectedTDL");
                }
            }
        }

        private string selectedTDLName;
        public string SelectedTDLName
        {
            get
            {
                return selectedTDLName;
            }
            set
            {
                selectedTDLName = value;
                NotifyPropertyChanged("SelectedTDLName");
            }
        }

        private Task selectedTask;
        public Task SelectedTask
        {
            get
            {
                return selectedTask;
            }
            set
            {
                selectedTask = value;
                NotifyPropertyChanged("SelectedTask");
            }
        }

        private bool isStatisticsPanelVisible;
        public bool IsStatisticsPanelVisible
        {
            get { return isStatisticsPanelVisible; }
            set
            {
                if (isStatisticsPanelVisible != value)
                {
                    isStatisticsPanelVisible = value;
                    NotifyPropertyChanged("IsStatisticsPanelVisible");
                }
            }
        }

        private StatisticsVM statistics;
        public StatisticsVM Statistics
        {
            get { return statistics; }
            set
            {
                if (statistics != value)
                {
                    statistics = value;
                    NotifyPropertyChanged("Statistics");
                }
            }
        }

        private ObservableCollection<Task> originalTasks;
        public ObservableCollection<Task> OriginalTasks
        {
            get { return originalTasks; }
            set
            {
                if (originalTasks != value)
                {
                    originalTasks = value;
                    NotifyPropertyChanged("OriginalTasks");
                }
            }
        }

        private FilterType currentFilter;
        public FilterType CurrentFilter
        {
            get { return currentFilter; }
            set
            {
                currentFilter = value;
                NotifyPropertyChanged("CurrentFilter");
            }
        }

        public enum FilterType
        {
            Category,
            Done,
            Delayed,
            Overdue,
            DueFuture,
            None
        }


        public ICommand NewDatabaseCommand { get; set; }
       
        public ICommand LoadDatabaseCommand { get; set; }

        public ICommand SaveDatabaseCommand { get; set; }

        public ICommand CloseDatabaseCommand { get; set; }

        public ICommand AddTDLCommand { get; set; }

        public ICommand EditTDLCommand { get; set; }

        public ICommand DeleteTDLCommand { get; set; }

        public ICommand MoveUpCommand { get; set; }

        public ICommand MoveDownCommand { get; set; }

        public ICommand ChangePathCommand { get; set; }

        public ICommand SortCommand { get; set; }

        public ICommand FilterCommand { get; set; }

        public ICommand StatisticsCommand => new RelayCommand(obj => IsStatisticsPanelVisible = true);

        public ICommand HelpCommand { get; set; }

    }
}

