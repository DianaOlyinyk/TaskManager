using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using TaskManager.BL;
using TaskManager.DAL;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        
        public App()
        {
            this.InitializeComponent();

            var services = new ServiceCollection();

            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddTransient<ProjectsViewModel>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddTransient<TaskDetailsViewModel>();
            services.AddTransient<ProjectDetailsViewModel>();

            Services = services.BuildServiceProvider();
        }
    }
}
