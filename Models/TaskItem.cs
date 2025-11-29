namespace TaskManagementApi.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime DueDateTime { get; set; }
    public DateTime CreatedAt { get; set; }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed,
    OnHold
}