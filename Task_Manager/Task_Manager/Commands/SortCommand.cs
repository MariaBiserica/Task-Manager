using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Commands
{
    public class SortCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("To sort the tasks, click on the column header you want to sort by.", "Sort", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
