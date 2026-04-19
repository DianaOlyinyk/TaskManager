using Microsoft.UI.Xaml;

namespace TaskManager.UI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Task Manager";
        }

        public void NavigateToProjects()
        {
            if (MainFrame.Content?.GetType() != typeof(Pages.ProjectsPage))
            {
                MainFrame.Navigate(typeof(Pages.ProjectsPage));
            }
        }
    }
}
