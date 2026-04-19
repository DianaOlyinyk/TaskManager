using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;


namespace TaskManager.DAL
{
    public interface IStorageService
    {
        Task<List<Project>> LoadProjectsAsync();
        Task SaveProjectsAsync(List<Project> projects);
    }
}
