﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;

namespace Task_Manager.Models
{
    internal class Task : TDL
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
                }
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    NotifyPropertyChanged();
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
