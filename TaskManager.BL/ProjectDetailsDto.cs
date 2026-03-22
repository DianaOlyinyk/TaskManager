using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BL
{
    public class ProjectDetailsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public List<TaskListDto> Tasks { get; set; }
    }
}
