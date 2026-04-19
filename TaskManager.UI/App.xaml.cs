using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using TaskManager.BL;
using TaskManager.DAL;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        private Window? m_window;

        public App()
        {
            this.InitializeComponent();

            var services = new ServiceCollection();

            services.AddSingleton<IStorageService, FileStorageService>();
            services.AddSingleton<StorageInitializer>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddTransient<ProjectsViewModel>();
            services.AddTransient<TaskDetailsViewModel>();
            services.AddTransient<ProjectDetailsViewModel>();

            Services = services.BuildServiceProvider();
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();

            try
            {
                var storageInitializer = Services.GetRequiredService<StorageInitializer>();
                await storageInitializer.InitializeAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Startup error: {ex}");
            }

            if (m_window is MainWindow mainWindow)
            {
                mainWindow.NavigateToProjects();
            }
        }
    }
}

