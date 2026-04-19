using TaskManager.DL.Models;

namespace TaskManager.BL
{
    public class ProjectFilterDto
    {
        public string? SearchText { get; set; }
        public ProjectType? Type { get; set; }
        public ProjectSortBy SortBy { get; set; } = ProjectSortBy.Name;
        public bool SortDescending { get; set; }
    }
}
