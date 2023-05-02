using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Core;

namespace Task_Manager.Models
{
    public class TDL : ObservableObject
    {
        public TDL()
        {
            SubCollection = new ObservableCollection<TDL>();
            Tasks = new ObservableCollection<Task>();
        }
        
        public ObservableCollection<TDL> SubCollection { get; set; }

        public ObservableCollection<Task> Tasks { get; set; }

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

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
