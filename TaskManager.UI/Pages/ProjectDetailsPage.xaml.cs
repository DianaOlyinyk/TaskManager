using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.BL;
using TaskManager.DL.Models;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectDetailsPage : Page
    {
        private ProjectDetailsViewModel ViewModel;

        public ProjectDetailsPage()
        {
            this.InitializeComponent();

            ViewModel = App.Services.GetRequiredService<ProjectDetailsViewModel>();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = (int)e.Parameter;
            ViewModel.Load(id);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
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
