using TaskManager.DAL;
using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.BL
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repository;

        public ProjectService(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProjectListDto>> GetProjectsAsync(ProjectFilterDto? filter = null)
        {
            var projects = await repository.GetAllAsync();
            var query = projects.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filter?.SearchText))
            {
                var searchText = filter.SearchText.Trim();
                query = query.Where(p =>
                    p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            if (filter?.Type is ProjectType type)
            {
                query = query.Where(p => p.Type == type);
            }

            query = (filter?.SortBy ?? ProjectSortBy.Name) switch
            {
                ProjectSortBy.Progress => query.OrderBy(p => p.Progress),
                ProjectSortBy.Type => query.OrderBy(p => p.Type),
                _ => query.OrderBy(p => p.Name)
            };

            if (filter?.SortDescending == true)
            {
                query = query.Reverse();
            }

            return query
                .Select(p => new ProjectListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Progress = p.Progress,
                    Type = p.Type
                })
                .ToList();
        }

        public async Task<ProjectDetailsDto?> GetProjectDetailsAsync(int projectId)
        {
            var project = await repository.GetByIdAsync(projectId);

            if (project is null)
            {
                return null;
            }

            return new ProjectDetailsDto
            {
                Name = project.Name,
                Description = project.Description,
                Progress = project.Progress,
                Tasks = project.Tasks.Select(t => new TaskListDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Priority = t.Priority.ToString(),
                    IsCompleted = t.IsCompleted
                }).ToList()
            };
        }

        public async Task AddProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name.Trim(),
                Description = dto.Description.Trim(),
                Type = dto.Type
            };

            await repository.AddProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            await repository.DeleteProjectAsync(projectId);
        }
    }
}
