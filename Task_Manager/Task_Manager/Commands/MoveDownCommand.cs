using System;
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
            var selectedTDL = _viewModel.SelectedTDL;

            if (_viewModel.Data.ItemsCollection.Contains(selectedTDL))
            {
                var index = _viewModel.Data.ItemsCollection.IndexOf(selectedTDL);
                if (index < _viewModel.Data.ItemsCollection.Count - 1)
                {
                    _viewModel.Data.ItemsCollection.RemoveAt(index);
                    _viewModel.Data.ItemsCollection.Insert(index + 1, selectedTDL);
                }
                else
                {
                    MessageBox.Show("This is already the last item in the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                foreach (var tdl in _viewModel.Data.ItemsCollection)
                {
                    if (tdl.SubCollection.Contains(selectedTDL))
                    {
                        var index = tdl.SubCollection.IndexOf(selectedTDL);
                        if (index < tdl.SubCollection.Count - 1)
                        {
                            tdl.SubCollection.RemoveAt(index);
                            tdl.SubCollection.Insert(index + 1, selectedTDL);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("This is already the last item in the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}