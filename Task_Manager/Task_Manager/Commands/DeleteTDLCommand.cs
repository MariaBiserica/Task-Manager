using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class DeleteTDLCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public DeleteTDLCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            // This command can always execute
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedTDL != null)
            {
                if (_viewModel.Data.ItemsCollection.Contains(_viewModel.SelectedTDL))
                {
                    _viewModel.Data.ItemsCollection.Remove(_viewModel.SelectedTDL);
                }
                else
                {
                    bool deleted = false;
                    DeleteTDLRecursive(_viewModel.Data.ItemsCollection, _viewModel.SelectedTDL, ref deleted);
                    if (deleted)
                    {
                        MessageBox.Show("TDL deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("TDL not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a TDL to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event EventHandler CanExecuteChanged;

        private void DeleteTDLRecursive(ObservableCollection<TDL> collection, TDL tdl, ref bool deleted)
        {
            if (collection.Contains(tdl))
            {
                collection.Remove(tdl);
                deleted = true;
                return;
            }
            else
            {
                foreach (var subCollection in collection)
                {
                    DeleteTDLRecursive(subCollection.SubCollection, tdl, ref deleted);
                    if (deleted)
                    {
                        break;
                    }
                }
            }
        }
    }

}
