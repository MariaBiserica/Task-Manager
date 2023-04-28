using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Task_Manager.Core;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;

namespace Task_Manager.ViewModels
{
    internal class TreeViewVM : ObservableObject
    {
        public TreeViewVM()
        {
            Data = new DataModel();
            Data.ItemsCollection = new ObservableCollection<TDL>();

            //ItemsCollection = new ObservableCollection<TDL>();

            TDL tdl1 = new TDL
            {
                Name = "TDL 1",
                Icon = "../Resources/Icons/folder1.jpg",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new TDL { Name = "Sub-TDL 1", Icon = "../Resources/Icons/book1.jpg", 
                        SubCollection = new ObservableCollection<TDL>()
                        {
                            new TDL() { Name = "Sub-Sub-TDL 1", Icon = "../Resources/Icons/search1.jpg" },
                            new TDL() { Name = "Sub-Sub-TDL 2", Icon = "../Resources/Icons/settings1.jpg"}
                        } 
                    },
                    new TDL { Name = "Sub-TDL 2", Icon = "../Resources/Icons/book2.jpg"},
                    new Task { Name = "Task 1", Icon = "../Resources/Icons/checklist1.jpg" },
                    new Task { Name = "Task 2", Icon = "../Resources/Icons/checklist2.jpg"}
                }
            };

            TDL tdl2 = new TDL
            {
                Name = "TDL 2",
                Icon = "../Resources/Icons/folder2.jpg",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new Task { Name = "Task 3", Icon = "../Resources/Icons/docs1.jpg" },
                    new Task { Name = "Task 4", Icon = "../Resources/Icons/computer1.jpg"}
                }
            };

            Data.ItemsCollection.Add(tdl1);
            Data.ItemsCollection.Add(tdl2);
        }

        public DataModel Data { get; set; }
        //public ObservableCollection<TDL> ItemsCollection { get; set; }
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
    }
}

