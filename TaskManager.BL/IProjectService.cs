namespace TaskManager.BL
{
    public interface IProjectService
    {
        Task<List<ProjectListDto>> GetProjectsAsync(ProjectFilterDto? filter = null);
        Task<ProjectDetailsDto?> GetProjectDetailsAsync(int projectId);
        Task AddProjectAsync(CreateProjectDto dto);
        Task DeleteProjectAsync(int projectId);
    }
}
