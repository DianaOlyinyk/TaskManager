using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using TaskManager.DL.Models;

namespace TaskManager.UI.Pages
{
    public sealed partial class ProjectsPage : Page
    {
        public ProjectsPage()
        {
            this.InitializeComponent();

            DataContext = App.Services.GetRequiredService<ProjectsViewModel>();
        }
    }
}
