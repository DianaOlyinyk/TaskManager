using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;
using TaskModel = TaskManager.DL.Models.Task;

namespace TaskManager.DAL
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int projectId);
        Task<TaskModel?> GetTaskByIdAsync(int taskId);
        
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);

        Task AddTaskAsync(int projectId, TaskModel task);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(int taskId);
    }
}