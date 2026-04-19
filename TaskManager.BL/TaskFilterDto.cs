using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.Models;
using TaskStatus = TaskManager.DL.Models.TaskStatus;

namespace TaskManager.BL
{
    public class TaskFilterDto
    {
        public int? ProjectId { get; set; }
        public string? SearchText { get; set; }
        public Priority? Priority { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskSortBy SortBy { get; set; } = TaskSortBy.Title;
        public bool SortDescending { get; set; }
    }
}
