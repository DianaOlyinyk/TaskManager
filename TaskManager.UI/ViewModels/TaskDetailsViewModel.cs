using System;
using TaskManager.BL;

public class TaskDetailsViewModel
{
    private readonly ITaskService service;

    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsOverdue { get; set; }

    public string PriorityText => $"Priority: {Priority}";
    public string DueDateText => $"Due: {DueDate:dd.MM.yyyy}";
    public string CompletedText => $"Completed: {IsCompleted}";
    public string OverdueText => $"Overdue: {IsOverdue}";

    public TaskDetailsViewModel(ITaskService service)
    {
        this.service = service;
    }

    public void Load(int taskId)
    {
        var task = service.GetTaskDetails(taskId);

        Title = task.Title;
        Description = task.Description;
        Priority = task.Priority;
        DueDate = task.DueDate;
        IsCompleted = task.IsCompleted;
        IsOverdue = task.IsOverdue;
    }
}

