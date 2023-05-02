﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Task_Manager.ViewModels;
using Task = Task_Manager.Models.Task;
using TaskStatus = Task_Manager.Models.Task.TaskStatus;
using TaskPriority = Task_Manager.Models.Task.TaskPriority;
using TaskCategory = Task_Manager.Models.Task.TaskCategory;
using System.Collections.ObjectModel;

namespace Task_Manager.Commands
{
    public class AddTaskCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public AddTaskCommand(MainViewVM viewModel)
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
            string name = Interaction.InputBox("Enter the task name:", "Add Name", "");
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Task name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string description = Interaction.InputBox("Enter the task description:", "Add Description", "");

            string[] statuses = Enum.GetNames(typeof(TaskStatus));
            string status = Interaction.InputBox("Enter a status:\n" + string.Join("\n", statuses), "Add Status");
            if (!statuses.Contains(status) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Invalid status!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] priorities = Enum.GetNames(typeof(TaskPriority));
            string priority = Interaction.InputBox("Enter a priority:\n" + string.Join("\n", priorities), "Add Priority", "");
            if (!priorities.Contains(priority) || string.IsNullOrEmpty(priority))
            {
                MessageBox.Show("Invalid priority!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //// Use a DatePicker control to select the deadline
            //_viewModel.IsDatePickerNeeded = true;
            //_viewModel.NotifyPropertyChanged("IsDatePickerNeeded");
            //DateTime deadline = _viewModel.Deadline;
            

            string[] categories = Enum.GetNames(typeof(TaskCategory));
            string category = Interaction.InputBox("Enter a category:\n" + string.Join("\n", categories), "Add Category", "");
            if (!categories.Contains(category) || string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Invalid category!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Task newTask = new Task
            {
                Name = name,
                Description = description,
                Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), status),
                Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), priority),
                // Deadline = deadline,
                Deadline = DateTime.Now.AddDays(5),
                CompletionDate = DateTime.MaxValue,
                Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), category)
            };

            _viewModel.SelectedTDL.Tasks.Add(newTask);
            _viewModel.NotifyPropertyChanged("SelectedTDL");
        }
    }
}