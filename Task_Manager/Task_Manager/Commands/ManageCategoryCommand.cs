﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;
using static Task_Manager.Models.Task;

namespace Task_Manager.Commands
{
    public class ManageCategoryCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public ManageCategoryCommand(MainViewVM viewModel)
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
            TaskCategory[] categories = (TaskCategory[])Enum.GetValues(typeof(TaskCategory));
            MessageBox.Show("Current categories:\n" + string.Join("\n", categories), "Categories", MessageBoxButton.OK, MessageBoxImage.Information);

            // Display a message box to ask the user if they want to add a new category to the enum TaskCategory type.
            MessageBoxResult result = MessageBox.Show("Do you want to add a new category?", "Add Category", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Get the name of the new category from the user.
                string categoryName = Interaction.InputBox("Enter the name of the new category:", "Add Category");

                // Add the new category to the enum TaskCategory.
                TaskCategory newCategory = (TaskCategory)Enum.Parse(typeof(TaskCategory), categoryName, true);
                // Check if the category already exists in the enum.
                if (!Enum.IsDefined(typeof(TaskCategory), newCategory))
                {
                    Array.Resize(ref categories, categories.Length + 1);
                    categories[categories.Length - 1] = newCategory;
                    Array.Sort(categories);
                    typeof(TaskCategory).GetField("values", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, categories);
                    MessageBox.Show("Category added successfully.", "Add Category", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Category already exists.", "Add Category", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Notify subscribers that the Categories have been updated
            _viewModel.NotifyPropertyChanged("Category");
        }
    }
}