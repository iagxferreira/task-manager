namespace TaskManager.Domain.Entities
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public List<Task> Tasks { get; set; } = [];
    }
}
