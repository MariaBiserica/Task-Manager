using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class AddTDLCommand : ICommand
    {
        private readonly MainViewVM _viewModel;

        public AddTDLCommand(MainViewVM viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Collect input from the user
            string name = Interaction.InputBox("Enter TDL Name", "Add TDL", "");

            // Check if name already exists
            bool nameExists = _viewModel.Data.ItemsCollection
                .Concat(_viewModel.Data.ItemsCollection.SelectMany(t => t.SubCollection))
                .Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            // Check if the name already exists
            if (_viewModel.Data.ItemsCollection.Any(tdl => tdl.Name == name) ||
                _viewModel.Data.ItemsCollection.Any(tdl => tdl.SubCollection.Any(subTDL => subTDL.Name == name)))
            {
                MessageBox.Show("A TDL with the same name already exists.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
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

            // Create the TDL
            var newTDL = new TDL()
            {
                Name = name,
                Icon = iconPath
            };

            // Check if there is a selected TDL
            if (_viewModel.SelectedTDL == null)
            {
                // Add the TDL to the root level
                _viewModel.Data.ItemsCollection.Add(newTDL);
            }
            else
            {
                // Add the TDL to the selected TDL's subcollection
                _viewModel.SelectedTDL.SubCollection.Add(newTDL);
            }
        }

        public event EventHandler CanExecuteChanged;
    }

}
