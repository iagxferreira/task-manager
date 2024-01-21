namespace TaskManager.Domain.Entities
{
    public class Task
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
    }
}