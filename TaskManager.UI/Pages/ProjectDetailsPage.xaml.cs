using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.BL;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectDetailsPage : Page
    {
        private readonly ProjectDetailsViewModel viewModel;

        public ProjectDetailsPage()
        {
            this.InitializeComponent();

            viewModel = App.Services.GetRequiredService<ProjectDetailsViewModel>();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int id = (int)e.Parameter;
            await viewModel.LoadAsync(id);
        }

        private void Back_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListView)sender;
            var selectedTask = (TaskListDto)list.SelectedItem;

            if (selectedTask != null)
            {
                Frame.Navigate(typeof(TaskDetailsPage), selectedTask.Id);
                list.SelectedItem = null;
            }
        }
    }

}
