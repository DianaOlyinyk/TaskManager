using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL;

namespace TaskManager.BL
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repository;

        public ProjectService(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public List<ProjectListDto> GetProjects()
        {
            return repository.GetAll()
                .Select(p => new ProjectListDto
                {
                    Name = p.Name,
                    Progress = p.Progress
                })
                .ToList();
        }
        public ProjectDetailsDto GetProjectDetails(int projectId)
        {
            var project = repository.GetAll()
                .FirstOrDefault(p => p.Id == projectId);

            if (project == null)
                return null;

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
    }
}
