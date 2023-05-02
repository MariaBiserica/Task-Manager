using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
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
                    foreach (var tdl in _viewModel.Data.ItemsCollection)
                    {
                        if (tdl.SubCollection.Contains(_viewModel.SelectedTDL))
                        {
                            tdl.SubCollection.Remove(_viewModel.SelectedTDL);
                            break;
                        }
                    }
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }

}
