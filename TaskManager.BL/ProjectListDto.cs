using TaskManager.DL.Models;

namespace TaskManager.BL
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Progress { get; set; }
        public ProjectType Type { get; set; }
    }
}
