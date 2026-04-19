using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;
using TaskModel = TaskManager.DL.Models.Task;
using TaskStatus = TaskManager.DL.Models.TaskStatus;

namespace TaskManager.DAL
{
    public class StorageInitializer
    {
        private readonly IStorageService storageService;

        public StorageInitializer(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task InitializeAsync()
        {
            var projects = await storageService.LoadProjectsAsync();

            if (projects.Any())
            {
                return;
            }

            var seedProjects = CreateSeedProjects();
            await storageService.SaveProjectsAsync(seedProjects);
        }

        private static List<Project> CreateSeedProjects()
        {
            var project1 = new Project
            {
                Id = 1,
                Name = "Course project",
                Description = "University project",
                Type = ProjectType.Educational,
                Tasks = new List<TaskModel>
                {
                    new TaskModel
                    {
                        Id = 1,
                        ProjectId = 1,
                        Title = "Write code",
                        Description = "Implement functionality",
                        Priority = Priority.High,
                        DueDate = DateTime.Now.AddDays(3),
                        Status = TaskStatus.InProgress
                    },
                    new TaskModel
                    {
                        Id = 2,
                        ProjectId = 1,
                        Title = "Write report",
                        Description = "Prepare documentation",
                        Priority = Priority.Medium,
                        DueDate = DateTime.Now.AddDays(5),
                        Status = TaskStatus.Open
                    }
                }
            };

            var project2 = new Project
            {
                Id = 2,
                Name = "Exam preparation",
                Description = "Prepare for final exam",
                Type = ProjectType.Personal,
                Tasks = new List<TaskModel>
                {
                    new TaskModel
                    {
                        Id = 3,
                        ProjectId = 2,
                        Title = "Read notes",
                        Description = "Review lecture materials",
                        Priority = Priority.Medium,
                        DueDate = DateTime.Now.AddDays(2),
                        Status = TaskStatus.Open
                    },
                    new TaskModel
                    {
                        Id = 4,
                        ProjectId = 2,
                        Title = "Solve exercises",
                        Description = "Practice tasks",
                        Priority = Priority.High,
                        DueDate = DateTime.Now.AddDays(4),
                        Status = TaskStatus.Open
                    }
                }
            };

            return new List<Project> { project1, project2 };
        }
    }
}
