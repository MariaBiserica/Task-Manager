using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class MoveDownCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public MoveDownCommand(MainViewVM viewModel)
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
                // Check if SelectedTDL is not already the last of ItemsCollection
                if (index < _viewModel.Data.ItemsCollection.Count - 1)
                {
                    // Swap SelectedTDL with TDL above it in ItemsCollection
                    _viewModel.Data.ItemsCollection[index] = _viewModel.Data.ItemsCollection[index + 1];
                    _viewModel.Data.ItemsCollection[index + 1] = _viewModel.SelectedTDL;
                }
                else
                {
                    MessageBox.Show("Cannot move TDL down any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // SelectedTDL is part of a SubCollection
                bool found = false;
                foreach (TDL parentTDL in _viewModel.Data.ItemsCollection)
                {
                    if (found)
                    {
                        break;
                    }
                    found = MoveDownRecursive(parentTDL.SubCollection, _viewModel.SelectedTDL);
                }
                if (!found)
                {
                    MessageBox.Show("Could not find TDL in data structure.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Refresh view
            _viewModel.NotifyPropertyChanged("SelectedTDL");
            _viewModel.NotifyPropertyChanged("ItemsCollection");
            _viewModel.NotifyPropertyChanged("SubCollection");
        }
        
        public event EventHandler CanExecuteChanged;

        private bool MoveDownRecursive(ObservableCollection<TDL> subCollection, TDL selectedTDL)
        {
            bool found = false;
            for (int i = 0; i < subCollection.Count; i++)
            {
                TDL tdl = subCollection[i];
                if (tdl == selectedTDL)
                {
                    // Check if TDL is not already the last of SubCollection
                    if (i < subCollection.Count - 1)
                    {
                        // Swap TDL with TDL above it in SubCollection
                        subCollection[i] = subCollection[i + 1];
                        subCollection[i + 1] = selectedTDL;
                    }
                    else
                    {
                        MessageBox.Show("Cannot move TDL down any further.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    found = true;
                    break;
                }
                else if (tdl.SubCollection.Count > 0)
                {
                    found = MoveDownRecursive(tdl.SubCollection, selectedTDL);
                    if (found)
                    {
                        break;
                    }
                }
            }
            return found;
        }
    }
}