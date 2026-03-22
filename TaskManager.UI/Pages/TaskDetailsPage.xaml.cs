using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.DL.Models;
using TaskManager.UI.ViewModels;
using TaskModel = TaskManager.DL.Models.Task;

namespace TaskManager.UI.Pages
{
    public sealed partial class TaskDetailsPage : Page
    {
        private TaskDetailsViewModel ViewModel;

        public TaskDetailsPage()
        {
            this.InitializeComponent();

            ViewModel = App.Services.GetRequiredService<TaskDetailsViewModel>();
            DataContext = ViewModel;
        }

    }
}

