using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    internal class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Category { get; set; }

        public enum TaskStatus
        {
            Created,
            InProgress,
            Done
        }

        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }
    }
}
