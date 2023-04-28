using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    [Serializable]
    public class DataModel
    {
        public ObservableCollection<TDL> ItemsCollection { get; set; }
    }
}
