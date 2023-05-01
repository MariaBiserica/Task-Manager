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
    public class SaveDatabaseCommand: ICommand
    {
        private readonly MainViewVM _viewModel;

        public SaveDatabaseCommand(MainViewVM viewModel)
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
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Save data file";
            if (saveFileDialog.ShowDialog() == true)
            {
                _viewModel.Data.SaveDataModel(saveFileDialog.FileName);
            }
        }
    }
}
