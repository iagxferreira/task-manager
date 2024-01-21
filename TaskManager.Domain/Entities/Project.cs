namespace TaskManager.Domain.Entities
{
    public class Project
    {
        public string Title { get; set; } = string.Empty;
        public List<Task> Tasks { get; set; } = [];
    }
}
