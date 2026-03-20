using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskManager.DL.Models;

using TaskModel = TaskManager.DL.Models.Task;

namespace TaskManager.UI.Pages
{
    public sealed partial class TaskDetailsPage : Page
    {
        private TaskModel task;

        public TaskDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            task = (TaskModel)e.Parameter;

            TaskTitle.Text = task.Title;
            TaskDescription.Text = task.Description;
            TaskPriority.Text = $"Priority: {task.Priority}";
            TaskDueDate.Text = $"Due: {task.DueDate}";
            TaskOverdue.Text = $"Overdue: {task.IsOverdue}";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}

