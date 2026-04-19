using System;
using System.Threading.Tasks;
using TaskManager.BL;

namespace TaskManager.UI.ViewModels
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        private readonly ITaskService service;

        private string title = string.Empty;
        private string description = string.Empty;
        private string priority = string.Empty;
        private DateTime dueDate;
        private bool isCompleted;
        private bool isOverdue;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Priority
        {
            get => priority;
            set
            {
                if (SetProperty(ref priority, value))
                {
                    OnPropertyChanged(nameof(PriorityText));
                }
            }
        }

        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                if (SetProperty(ref dueDate, value))
                {
                    OnPropertyChanged(nameof(DueDateText));
                }
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (SetProperty(ref isCompleted, value))
                {
                    OnPropertyChanged(nameof(CompletedText));
                }
            }
        }

        public bool IsOverdue
        {
            get => isOverdue;
            set
            {
                if (SetProperty(ref isOverdue, value))
                {
                    OnPropertyChanged(nameof(OverdueText));
                }
            }
        }

        public string PriorityText => $"Priority: {Priority}";
        public string DueDateText => $"Due: {DueDate:dd.MM.yyyy}";
        public string CompletedText => $"Completed: {IsCompleted}";
        public string OverdueText => $"Overdue: {IsOverdue}";

        public TaskDetailsViewModel(ITaskService service)
        {
            this.service = service;
        }

        public async Task LoadAsync(int taskId)
        {
            try
            {
                IsBusy = true;
                ErrorMessage = null;

                var task = await service.GetTaskDetailsAsync(taskId);

                if (task is null)
                {
                    ErrorMessage = "Task not found.";
                    return;
                }

                Title = task.Title;
                Description = task.Description;
                Priority = task.Priority;
                DueDate = task.DueDate;
                IsCompleted = task.IsCompleted;
                IsOverdue = task.IsOverdue;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
