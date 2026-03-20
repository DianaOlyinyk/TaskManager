using TaskManager.DL.Models;
using System;
using System.Collections.Generic;
using Task = TaskManager.DL.Models.Task;
public static class PseudoRepository
{
    public static List<Project> GetProjects()
    {
        var p1 = new Project("Course project", "University project", ProjectType.Educational);

        p1.AddTask(new Task(p1.Id, "Write code", "Code",
            Priority.High, DateTime.Now.AddDays(3)));

        p1.AddTask(new Task(p1.Id, "Write report", "Documentation",
            Priority.Medium, DateTime.Now.AddDays(5)));

        return new List<Project> { p1 };
    }
}
