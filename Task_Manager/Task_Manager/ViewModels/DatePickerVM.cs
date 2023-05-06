using System;
using System.ComponentModel;
using System.Windows.Input;
using Task_Manager.Core;
using Task_Manager.Views;

namespace Task_Manager.ViewModels
{
    public class DatePickerVM : ObservableObject
    {
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }

        public ICommand ConfirmCommand => new RelayCommand(Confirm);

        private void Confirm(object parameter)
        {
            if (parameter is DateTime date)
            {
                SelectedDate = date;
            }
        }
    }
}

