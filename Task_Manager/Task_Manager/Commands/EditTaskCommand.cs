using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Task_Manager.Commands
{
    public class EditTaskCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("You can edit your tasks by clicking and modifying directly in the DataGrid cells.", "Edit Task", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
