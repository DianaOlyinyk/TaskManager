using System;
using System.Collections.ObjectModel;
using TaskManager.BL;
using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.UI.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        private readonly IProjectService service;
        private ObservableCollection<ProjectListDto> projects = new();
        private string searchText = string.Empty;
        private ProjectSortBy selectedSortBy = ProjectSortBy.Name;
        private ProjectType? selectedTypeFilter;
        private string newProjectName = string.Empty;
        private string newProjectDescription = string.Empty;
        private ProjectType selectedNewProjectType = ProjectType.Educational;

        public ObservableCollection<ProjectListDto> Projects
        {
            get => projects;
            set => SetProperty(ref projects, value);
        }

        public string SearchText
        {
            get => searchText;
            set => SetProperty(ref searchText, value);
        }

        public ProjectSortBy SelectedSortBy
        {
            get => selectedSortBy;
            set => SetProperty(ref selectedSortBy, value);
        }

        public ProjectType? SelectedTypeFilter
        {
            get => selectedTypeFilter;
            set => SetProperty(ref selectedTypeFilter, value);
        }

        public string NewProjectName
        {
            get => newProjectName;
            set => SetProperty(ref newProjectName, value);
        }

        public string NewProjectDescription
        {
            get => newProjectDescription;
            set => SetProperty(ref newProjectDescription, value);
        }

        public ProjectType SelectedNewProjectType
        {
            get => selectedNewProjectType;
            set => SetProperty(ref selectedNewProjectType, value);
        }

        public Array SortOptions => Enum.GetValues(typeof(ProjectSortBy));
        public Array ProjectTypes => Enum.GetValues(typeof(ProjectType));

        public ProjectsViewModel(IProjectService service)
        {
            this.service = service;
        }

        public async Task LoadAsync()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = null;

                var data = await service.GetProjectsAsync(new ProjectFilterDto
                {
                    SearchText = SearchText,
                    SortBy = SelectedSortBy,
                    Type = SelectedTypeFilter
                });

                Projects = new ObservableCollection<ProjectListDto>(data);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task AddProjectAsync()
        {
            if (string.IsNullOrWhiteSpace(NewProjectName))
            {
                ErrorMessage = "Project name is required.";
                return;
            }

            try
            {
                IsBusy = true;
                ErrorMessage = null;

                await service.AddProjectAsync(new CreateProjectDto
                {
                    Name = NewProjectName,
                    Description = NewProjectDescription,
                    Type = SelectedNewProjectType
                });

                NewProjectName = string.Empty;
                NewProjectDescription = string.Empty;
                SelectedNewProjectType = ProjectType.Educational;

                await LoadAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            try
            {
                IsBusy = true;
                ErrorMessage = null;

                await service.DeleteProjectAsync(projectId);
                await LoadAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
