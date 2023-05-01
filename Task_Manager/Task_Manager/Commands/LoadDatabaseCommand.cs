using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Markup;
using Task_Manager.Core;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class LoadDatabaseCommand : ICommand 
    {
        private readonly MainViewVM _viewModel;

        public LoadDatabaseCommand(MainViewVM viewModel)
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
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open data file";
            if (openFileDialog.ShowDialog() == true)
            {
                _viewModel.Data = new DataModelVM();
                _viewModel.Data.LoadDataModel(openFileDialog.FileName);
                _viewModel.NotifyPropertyChanged("Data");
            }
        }
    }
}
