using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;

namespace Task_Manager.Models
{
    public class Task : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private TaskStatus _status;
        public TaskStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }

        private TaskPriority _priority;
        public TaskPriority Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    NotifyPropertyChanged("Priority");
                }
            }
        }

        private DateTime _deadline;
        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline != value)
                {
                    _deadline = value;
                    NotifyPropertyChanged("Deadline");
                }
            }
        }

        private DateTime _completionDate;
        public DateTime CompletionDate
        {
            get { return _completionDate; }
            set
            {
                if (_completionDate != value)
                {
                    _completionDate = value;
                    NotifyPropertyChanged("CompletionDate");
                }
            }
        }

        private TaskCategory _category;
        public TaskCategory Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    NotifyPropertyChanged("Location");
                }
            }
        }

        public enum TaskStatus
        {
            Created,
            InProgress,
            Done
        }

        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }

    }
}
