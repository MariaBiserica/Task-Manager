using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Task_Manager.Core;
using Task_Manager.Models;
using TaskStatus = Task_Manager.Models.Task.TaskStatus;

namespace Task_Manager.ViewModels
{
    public class StatisticsVM : ObservableObject
    {
        private readonly TDL data;
        public string NumTasksToday { get; set; }
        public string NumTasksTomorrow { get; set; }
        public string NumTasksDelayed { get; set; }
        public string NumTasksCompleted { get; set; }
        public string NumTasksPending { get; set; }

        public StatisticsVM(TDL data)
        {
            this.data = data;
            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            if (data == null)
            {
                return;
            }

            // Get all tasks due today and tomorrow
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var tasksToday = data.Tasks.Where(t => t.Deadline == today);
            var tasksTomorrow = data.Tasks.Where(t => t.Deadline == tomorrow);

            // Calculate number of tasks due today and tomorrow
            NumTasksToday = "Tasks due today: " + tasksToday.Count();
            NumTasksTomorrow = "Tasks due tommorow: " + tasksTomorrow.Count();

            // Calculate number of tasks delayed and completed and to bo done
            var tasksDelayed = data.Tasks.Where(t => t.Deadline < today && t.Status != TaskStatus.Done);
            var tasksCompleted = data.Tasks.Where(t => t.Status == TaskStatus.Done);
            NumTasksDelayed = "Tasks overdue: " + tasksDelayed.Count();
            NumTasksCompleted = "Tasks done: " + tasksCompleted.Count();

            // Calculate number of pending tasks
            NumTasksPending = "Tasks to be done: " + (data.Tasks.Count() - tasksCompleted.Count());
        }
    }
}
