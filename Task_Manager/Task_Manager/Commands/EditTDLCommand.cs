using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class EditTDLCommand: ICommand
    {
        private readonly MainViewVM _viewModel;

        public EditTDLCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.SelectedTDL == null) return;

            // Collect input from the user
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter new name for TDL", "Edit TDL", _viewModel.SelectedTDL.Name);
            if (!string.IsNullOrEmpty(name))
            {
                _viewModel.SelectedTDL.Name = name;
            }

            // Allow user to choose icon
            string iconPath = string.Empty;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Select Icon";

            if (openFileDialog.ShowDialog() == true)
            {
                iconPath = openFileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(iconPath))
            {
                _viewModel.SelectedTDL.Icon = iconPath;
            }

            _viewModel.NotifyPropertyChanged("SelectedTDL");
        }

        public event EventHandler CanExecuteChanged;
    }
}
