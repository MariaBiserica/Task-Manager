using System;
using System.Windows.Input;
using System.Windows;

namespace Task_Manager.Commands
{
    public class HelpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Student Name: Biserica Maria\nGroup: 10LF211\nEmail: maria.biserica@student.unitbv.ro", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
