using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        private TDL selectedItem;
        public TDL SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        public ICommand NewDatabaseCommand { get; set; }
        
        public ICommand LoadDataCommand => new RelayCommand(obj => LoadData());

        public ICommand SaveDataCommand => new RelayCommand(obj => SaveData());

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
    //public TreeViewVM()
    //{
    //    Data = new DataModel();
    //    Data.ItemsCollection = new ObservableCollection<TDL>();

    //    TDL tdl1 = new TDL
    //    {
    //        Name = "TDL 1",
    //        Icon = "../Resources/Icons/folder1.jpg",
    //        SubCollection = new ObservableCollection<TDL>()
    //        {
    //            new TDL { Name = "Sub-TDL 1", Icon = "../Resources/Icons/book1.jpg", 
    //                SubCollection = new ObservableCollection<TDL>()
    //                {
    //                    new TDL() { Name = "Sub-Sub-TDL 1", Icon = "../Resources/Icons/search1.jpg" },
    //                    new TDL() { Name = "Sub-Sub-TDL 2", Icon = "../Resources/Icons/settings1.jpg"}
    //                } 
    //            },
    //            new TDL { Name = "Sub-TDL 2", Icon = "../Resources/Icons/book2.jpg"},
    //            new Task { Name = "Task 1", Icon = "../Resources/Icons/checklist1.jpg" },
    //            new Task { Name = "Task 2", Icon = "../Resources/Icons/checklist2.jpg"}
    //        }
    //    };

    //    TDL tdl2 = new TDL
    //    {
    //        Name = "TDL 2",
    //        Icon = "../Resources/Icons/folder2.jpg",
    //        SubCollection = new ObservableCollection<TDL>()
    //        {
    //            new Task { Name = "Task 3", Icon = "../Resources/Icons/docs1.jpg" },
    //            new Task { Name = "Task 4", Icon = "../Resources/Icons/computer1.jpg"}
    //        }
    //    };

    //    Data.ItemsCollection.Add(tdl1);
    //    Data.ItemsCollection.Add(tdl2);
    //}
}

