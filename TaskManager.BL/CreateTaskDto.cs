using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.Models;
using TaskStatus = TaskManager.DL.Models.TaskStatus;

namespace TaskManager.BL
{
    public class CreateTaskDto
    {
        int ProjectId;
        string Title;
        string Description;
        Priority Priority;
        DateTime DueDate;
        TaskStatus Status;
    }
}
