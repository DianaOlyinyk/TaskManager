using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;
using TaskManager.DL.Models;
using System;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectsPage : Page
    {
        private List<Project> projects;

        public ProjectsPage()
        {
            this.InitializeComponent(); 
            projects = PseudoRepository.GetProjects();
            ProjectsList.ItemsSource = projects;
        }


        private void ProjectsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var project = (Project)ProjectsList.SelectedItem;

            if (project != null)
            {
                Frame.Navigate(typeof(ProjectDetailsPage), project);
            }
        }
    }
}
