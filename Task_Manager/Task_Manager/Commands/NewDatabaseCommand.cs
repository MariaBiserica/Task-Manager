using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class NewDatabaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Ask user for new file name
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Create new data model with empty items collection
                var dataModel = new DataModelVM();
                dataModel.ItemsCollection = new ObservableCollection<TDL>();

                // Save data model to new file
                dataModel.SaveDataModel(saveFileDialog.FileName);

                // Load data model from new file
                dataModel.LoadDataModel(saveFileDialog.FileName);
            }
        }
    }
}
