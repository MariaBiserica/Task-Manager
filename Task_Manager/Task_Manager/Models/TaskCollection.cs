using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;

namespace Task_Manager.Models
{
    internal class TaskCollection: ObservableObject
    {
        public string name { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("CollectionName");
            }
        }

        public string Icon { get; set; }

        public ObservableCollection<TaskCollection> Items { get; set; } = new ObservableCollection<TaskCollection>();
    }
}
