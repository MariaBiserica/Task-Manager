using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class CloseDatabaseCommand: ICommand
    {
        private readonly MainViewVM _viewModel;

        public CloseDatabaseCommand(MainViewVM viewModel)
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
            _viewModel.Data = null;
            _viewModel.SelectedTDL = null;
            _viewModel.NotifyPropertyChanged("Data");
        }
    }
}
