
using Task = TaskManager.DL.Models.Task;
using TaskStatus = TaskManager.DL.Models.TaskStatus;
namespace TaskManager.DL.Models;
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProjectType Type { get; set; }
    public List<Task> Tasks { get; set; } = new();

    public double Progress => Tasks.Count == 0 ? 0 : (double)Tasks.Count(t => t.Status == TaskStatus.Completed) / Tasks.Count * 100;

    public Project() { }
    public Project(int id, string name, string description, ProjectType type)
            : this(name, description, type)
    {
        Id = id;
    }
    public Project(string name, string description, ProjectType type)
    {
        Name = name;
        Description = description;
        Type = type;
        Tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }
}
