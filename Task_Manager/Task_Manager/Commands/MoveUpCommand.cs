using System;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class MoveUpCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public MoveUpCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedTDL != null;
        }

        public void Execute(object parameter)
        {
            // Check if SelectedTDL is part of ItemsCollection
            if (_viewModel.Data.ItemsCollection.Contains(_viewModel.SelectedTDL))
            {
                // Get index of SelectedTDL in ItemsCollection
                int index = _viewModel.Data.ItemsCollection.IndexOf(_viewModel.SelectedTDL);
                // Check if SelectedTDL is not already at the top of ItemsCollection
                if (index > 0)
                {
                    // Swap SelectedTDL with TDL above it in ItemsCollection
                    _viewModel.Data.ItemsCollection[index] = _viewModel.Data.ItemsCollection[index - 1];
                    _viewModel.Data.ItemsCollection[index - 1] = _viewModel.SelectedTDL;
                }
                else
                {
                    MessageBox.Show("Cannot move TDL up any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // SelectedTDL is part of a SubCollection
                foreach (TDL parentTDL in _viewModel.Data.ItemsCollection)
                {
                    if (parentTDL.SubCollection.Contains(_viewModel.SelectedTDL))
                    {
                        // Get index of SelectedTDL in parent TDL's SubCollection
                        int index = parentTDL.SubCollection.IndexOf(_viewModel.SelectedTDL);
                        // Check if SelectedTDL is not already at the top of SubCollection
                        if (index > 0)
                        {
                            // Swap SelectedTDL with TDL above it in SubCollection
                            parentTDL.SubCollection[index] = parentTDL.SubCollection[index - 1];
                            parentTDL.SubCollection[index - 1] = _viewModel.SelectedTDL;
                        }
                        else
                        {
                            MessageBox.Show("Cannot move TDL up any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    }
                }
            }

            // Refresh view
            _viewModel.NotifyPropertyChanged("SelectedTDL");
            _viewModel.NotifyPropertyChanged("ItemsCollection");
            _viewModel.NotifyPropertyChanged("SubCollection");
        }

        public event EventHandler CanExecuteChanged;
    }
}
