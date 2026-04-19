using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Pages
{
    public sealed partial class TaskDetailsPage : Page
    {
        private readonly TaskDetailsViewModel viewModel;

        public TaskDetailsPage()
        {
            this.InitializeComponent();

            viewModel = App.Services.GetRequiredService<TaskDetailsViewModel>();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int taskId = (int)e.Parameter;
            await viewModel.LoadAsync(taskId);
        }

        private void Back_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}

