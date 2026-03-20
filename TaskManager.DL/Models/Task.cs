using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskStatus = TaskManager.DL.Models.TaskStatus;

namespace TaskManager.DL.Models
{
    public class Task
    {
        private static int _idCounter = 1;

        public int Id { get; }
        public int ProjectId { get; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public bool IsCompleted => Status == TaskStatus.Completed;

        public bool IsOverdue
        {
            get
            {
                return !IsCompleted && DateTime.Now > DueDate;
            }
        }

        public Task(int projectId, string title, string description,
                    Priority priority, DateTime dueDate)
        {
            Id = _idCounter++;
            ProjectId = projectId;
            Title = title;
            Description = description;
            Priority = priority;
            DueDate = dueDate;
            Status = TaskStatus.Open;
        }
    }
}
