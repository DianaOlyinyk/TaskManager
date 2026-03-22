using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL;

namespace TaskManager.BL
{
    public class TaskService : ITaskService
    {
        private readonly IProjectRepository repository;

        public TaskService(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public TaskDetailsDto GetTaskDetails(int id)
        {
            var task = repository.GetAll()
                .SelectMany(p => p.Tasks)
                .FirstOrDefault(t => t.Id == id);

            return new TaskDetailsDto
            {
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted,
                IsOverdue = task.IsOverdue
            };
        }
    }

}
