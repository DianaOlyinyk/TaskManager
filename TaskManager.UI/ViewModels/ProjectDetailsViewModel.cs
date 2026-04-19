using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskManager.BL;

namespace TaskManager.UI.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        private readonly IProjectService service;

        private string name = string.Empty;
        private string description = string.Empty;
        private double progress;
        private ObservableCollection<TaskListDto> tasks = new();

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public double Progress
        {
            get => progress;
            set
            {
                if (SetProperty(ref progress, value))
                {
                    OnPropertyChanged(nameof(ProgressText));
                }
            }
        }

        public ObservableCollection<TaskListDto> Tasks
        {
            get => tasks;
            set => SetProperty(ref tasks, value);
        }

        public string ProgressText => $"Progress: {Progress}%";

        public ProjectDetailsViewModel(IProjectService service)
        {
            this.service = service;
        }

        public async Task LoadAsync(int projectId)
        {
            try
            {
                IsBusy = true;
                ErrorMessage = null;

                var project = await service.GetProjectDetailsAsync(projectId);

                if (project is null)
                {
                    ErrorMessage = "Project not found.";
                    return;
                }

                Name = project.Name;
                Description = project.Description;
                Progress = project.Progress;
                Tasks = new ObservableCollection<TaskListDto>(project.Tasks);
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
