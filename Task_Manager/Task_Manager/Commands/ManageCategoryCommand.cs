using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;
using Task_Manager.Views;
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
            ManageCategoriesView dialog = new ManageCategoriesView();
            dialog.Owner = Application.Current.MainWindow; // Set the owner of the dialog window
            dialog.ShowDialog();
        }
    }
}