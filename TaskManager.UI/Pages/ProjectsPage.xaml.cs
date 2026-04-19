using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.BL;
using TaskManager.DL.Models;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectsPage : Page
    {
        private readonly ProjectsViewModel viewModel;

        public ProjectsPage()
        {
            InitializeComponent();

            viewModel = App.Services.GetRequiredService<ProjectsViewModel>();
            DataContext = viewModel;

            TypeFilterComboBox.SelectedIndex = 0;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await viewModel.LoadAsync();
        }

        private async void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            await viewModel.LoadAsync();
        }

        private async void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            await viewModel.LoadAsync();
        }

        private async void TypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            viewModel.SelectedTypeFilter = TypeFilterComboBox.SelectedIndex switch
            {
                1 => ProjectType.Educational,
                2 => ProjectType.Work,
                3 => ProjectType.Personal,
                _ => null
            };

            await viewModel.LoadAsync();
        }

        private async void AddProject_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            await viewModel.AddProjectAsync();
        }

        private async void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            if (sender is Button button && button.DataContext is ProjectListDto project)
            {
                await viewModel.DeleteProjectAsync(project.Id);
            }
        }

        private void ProjectsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListView)sender;
            var selectedProject = (ProjectListDto?)list.SelectedItem;

            if (selectedProject is null)
            {
                return;
            }

            Frame.Navigate(typeof(ProjectDetailsPage), selectedProject.Id);
            list.SelectedItem = null;
        }
    }
}
