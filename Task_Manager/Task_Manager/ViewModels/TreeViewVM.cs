using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;
using Task_Manager.Models;
using Task = Task_Manager.Models.Task;

namespace Task_Manager.ViewModels
{
    internal class TreeViewVM : ObservableObject
    {
        public TreeViewVM()
        {
            /*ItemsCollection = new ObservableCollection<TDL>();
            ItemsCollection.Add(new TDL
            {
                Name = "a",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new TDL { Name = "b", SubCollection = new ObservableCollection<TDL>()
                    {
                        new TDL() { Name = "d", SubCollection = new ObservableCollection<TDL>() },
                        new TDL() { Name = "e", SubCollection = new ObservableCollection<TDL>() }
                    }
                    },
                    new TDL { Name = "c", SubCollection = new ObservableCollection<TDL>()
                    {
                        new TDL() { Name = "f", SubCollection = new ObservableCollection<TDL>() },
                        new TDL() { Name = "g", SubCollection = new ObservableCollection<TDL>() }
                    }
                    }
                }
            });
            ItemsCollection.Add(new TDL()
            {
                Name = "h",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new TDL { Name = "i", SubCollection = new ObservableCollection<TDL>()
                    {
                        new TDL() { Name = "j", SubCollection = new ObservableCollection<TDL>() }
                    }
                    }
                }
            });*/

            ItemsCollection = new ObservableCollection<TDL>();

            TDL tdl1 = new TDL
            {
                Name = "TDL 1",
                Icon = "../Resources/Icons/folder.jpg",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new TDL { Name = "Sub-TDL 1" },
                    new TDL { Name = "Sub-TDL 2" },
                    new Task { Name = "Task 1" },
                    new Task { Name = "Task 2" }
                }
                    };

            TDL tdl2 = new TDL
            {
                Name = "TDL 2",
                Icon = "../Resources/Icons/folder.jpg",
                SubCollection = new ObservableCollection<TDL>()
                {
                    new Task { Name = "Task 3" },
                    new Task { Name = "Task 4" }
                }
            };

            ItemsCollection.Add(tdl1);
            ItemsCollection.Add(tdl2);
        }
        
        public ObservableCollection<TDL> ItemsCollection { get; set; }
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

