using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.Models;

namespace TaskManager.BL
{
    public class UpdateProjectDto
    {
        int Id;
        string Name;
        string Description;
        ProjectType Type;
    }
}
