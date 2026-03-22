using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BL
{
    public class TaskListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Priority { get; set; }

        public bool IsCompleted { get; set; }
    }
}
