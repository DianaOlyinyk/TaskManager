using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BL;

namespace TaskManager.UI.ViewModels
{
    public class ProjectDetailsViewModel
    {
        private readonly IProjectService service;

        public string Name { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }

        public ObservableCollection<TaskListDto> Tasks { get; set; }
        public string ProgressText => $"Progress: {Progress}%";

        public ProjectDetailsViewModel(IProjectService service)
        {
            this.service = service;
        }

        public void Load(int projectId)
        {
            var project = service.GetProjectDetails(projectId);

            Name = project.Name;
            Description = project.Description;
            Progress = project.Progress;

            Tasks = new ObservableCollection<TaskListDto>(project.Tasks);
        }
    }

}
