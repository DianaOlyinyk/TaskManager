using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.DL.Models;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectDetailsPage : Page
    {
        private Project project;

        public ProjectDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            project = (Project)e.Parameter;

            ProjectTitle.Text = project.Name;
            ProjectDescription.Text = project.Description;
            ProjectProgress.Text = $"Progress: {project.Progress}%";

            TasksList.ItemsSource = project.Tasks;
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = (TaskManager.DL.Models.Task)TasksList.SelectedItem;

            Frame.Navigate(typeof(TaskDetailsPage), task);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
