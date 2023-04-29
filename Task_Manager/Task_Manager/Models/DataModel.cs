using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_Manager.Models
{
    [Serializable]
    [XmlInclude(typeof(Task))]
    public class DataModel
    {
        public ObservableCollection<TDL> ItemsCollection { get; set; }

        public DataModel()
        {
            ItemsCollection = new ObservableCollection<TDL>();
        }
    }
}
