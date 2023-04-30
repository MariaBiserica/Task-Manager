using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Linq;
using Task_Manager.Commands;
using Task_Manager.Core;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;

namespace Task_Manager.ViewModels
{
    internal class TreeViewVM : ObservableObject
    {
        public TreeViewVM()
        {
            Data = null;
            NewDatabaseCommand = new NewDatabaseCommand();
        }
        public DataModelVM Data { get; set; }

        private TDL selectedTDL;
        public TDL SelectedTDL
        {
            get
            {
                return selectedTDL;
            }
            set 
            {
                if (selectedTDL != value)
                {
                    selectedTDL = value;
                    NotifyPropertyChanged("SelectedTDL");
                }
            }
        }

        public ICommand NewDatabaseCommand { get; set; }
        
        public ICommand LoadDatabaseCommand => new RelayCommand(obj => LoadData());

        public ICommand SaveDatabaseCommand => new RelayCommand(obj => SaveData());

        public ICommand CloseDatabaseCommand => new RelayCommand(obj => CloseDatabase());

        private void LoadData()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Open data file";
            if (openFileDialog.ShowDialog() == true)
            {
                Data = new DataModelVM();
                Data.LoadDataModel(openFileDialog.FileName);
                NotifyPropertyChanged("Data");
            }
        }

        private void SaveData()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Save data file";
            if (saveFileDialog.ShowDialog() == true)
            {
                Data.SaveDataModel(saveFileDialog.FileName);
            }
        }

        private void CloseDatabase()
        {
            Data = null;
            NotifyPropertyChanged("Data");
        }

    }
}

