using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;
using TaskModel = TaskManager.DL.Models.Task;

namespace TaskManager.DAL
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IStorageService storageService;

        public ProjectRepository(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await storageService.LoadProjectsAsync();
        }

        public async Task<Project?> GetByIdAsync(int projectId)
        {
            var projects = await storageService.LoadProjectsAsync();
            return projects.FirstOrDefault(p => p.Id == projectId);
        }

        public async Task<TaskModel?> GetTaskByIdAsync(int taskId)
        {
            var projects = await storageService.LoadProjectsAsync();

            return projects
                .SelectMany(p => p.Tasks)
                .FirstOrDefault(t => t.Id == taskId);
        }

        public async Task AddProjectAsync(Project project)
        {
            var projects = await storageService.LoadProjectsAsync();

            project.Id = GetNextProjectId(projects);
            projects.Add(project);

            await storageService.SaveProjectsAsync(projects);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var projects = await storageService.LoadProjectsAsync();
            var existingProject = projects.FirstOrDefault(p => p.Id == project.Id);

            if (existingProject is null)
            {
                return;
            }

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.Type = project.Type;

            await storageService.SaveProjectsAsync(projects);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var projects = await storageService.LoadProjectsAsync();
            var project = projects.FirstOrDefault(p => p.Id == projectId);

            if (project is null)
            {
                return;
            }

            projects.Remove(project);
            await storageService.SaveProjectsAsync(projects);
        }

        public async Task AddTaskAsync(int projectId, TaskModel task)
        {
            var projects = await storageService.LoadProjectsAsync();
            var project = projects.FirstOrDefault(p => p.Id == projectId);

            if (project is null)
            {
                return;
            }

            task.Id = GetNextTaskId(projects);
            task.ProjectId = projectId;

            project.Tasks.Add(task);
            await storageService.SaveProjectsAsync(projects);
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            var projects = await storageService.LoadProjectsAsync();

            var existingTask = projects
                .SelectMany(p => p.Tasks)
                .FirstOrDefault(t => t.Id == task.Id);

            if (existingTask is null)
            {
                return;
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;

            await storageService.SaveProjectsAsync(projects);
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var projects = await storageService.LoadProjectsAsync();

            var project = projects.FirstOrDefault(p => p.Tasks.Any(t => t.Id == taskId));
            if (project is null)
            {
                return;
            }

            var task = project.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is null)
            {
                return;
            }

            project.Tasks.Remove(task);
            await storageService.SaveProjectsAsync(projects);
        }

        private static int GetNextProjectId(List<Project> projects)
        {
            return projects.Count == 0 ? 1 : projects.Max(p => p.Id) + 1;
        }

        private static int GetNextTaskId(List<Project> projects)
        {
            var tasks = projects.SelectMany(p => p.Tasks).ToList();
            return tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        }
    }
}