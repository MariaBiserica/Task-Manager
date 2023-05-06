using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class TaskCategory
    {
        public TaskCategory()
        {
        }
        public TaskCategory(string name)
        {
            Name = name;
        }
        
        public static TaskCategory Work { get; } = new TaskCategory("Work");
        public static TaskCategory School { get; } = new TaskCategory("School");
        public static TaskCategory Home { get; } = new TaskCategory("Home");
        public static TaskCategory Other { get; } = new TaskCategory("Other");

        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Category name cannot be empty.");
                _name = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
