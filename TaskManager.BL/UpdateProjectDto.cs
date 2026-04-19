using TaskManager.DL.Models;

namespace TaskManager.BL
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProjectType Type { get; set; }
    }
}
