using System.Collections.ObjectModel;
using TaskManager.BL;

public class ProjectsViewModel
{
    private readonly IProjectService service;

    public ObservableCollection<ProjectListDto> Projects { get; set; }

    public ProjectsViewModel(IProjectService service)
    {
        this.service = service;
        
        var data = service.GetProjects();
        Projects = new ObservableCollection<ProjectListDto>(data);
    }
}
