//using TaskManager.DL.Models;
using Task = TaskManager.DL.Models.Task;
using TaskStatus = TaskManager.DL.Models.TaskStatus;
namespace TaskManager.DL.Models;
public class Project
{
    private static int _idCounter = 1;

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ProjectType Type { get; set; }
    public List<Task> Tasks { get; set; }

    public Project(string name, string description, ProjectType type)
    {
        Id = _idCounter++;
        Name = name;
        Description = description;
        Type = type;
        Tasks = new List<Task>();
    }

    public double Progress
    {
        get
        {
            if (Tasks.Count == 0) return 0;

            int completed = Tasks.Count(t => t.Status == TaskStatus.Completed);
            return (double)completed / Tasks.Count * 100;
        }
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }
}
