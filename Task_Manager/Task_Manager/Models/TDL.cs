using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;

namespace Task_Manager.Models
{
    internal class TDL : ObservableObject
    {
        public TDL()
        {
            SubCollection = new ObservableCollection<TDL>();
        }
        
        public ObservableCollection<TDL> SubCollection { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Icon { get; set; }
    }
}
