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

        public async Task<TaskDetailsDto?> GetTaskDetailsAsync(int id)
        {
            var task = await repository.GetTaskByIdAsync(id);

            if (task is null)
            {
                return null;
            }

            return new TaskDetailsDto
            {
                Id = task.Id,
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
