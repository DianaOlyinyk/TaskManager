using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.Models;

namespace TaskManager.DAL
{
    public class ProjectRepository : IProjectRepository
    {
        private List<Project> projects = new();

        public ProjectRepository()
        {
            var p = new Project("Course", "Desc", ProjectType.Educational);
            projects.Add(p);
            var p2 = new Project("Exam preparation", "Desc", ProjectType.Personal);
            projects.Add(p2);
            var p3 = new Project("Presentation", "Desc", ProjectType.Work);
            projects.Add(p3);
       
        }
        public List<Project> GetAll()
        {
            return projects;
        }
    }
}
