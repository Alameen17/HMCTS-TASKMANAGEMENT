namespace TaskManagementApi.Models.DTOs;

public class CreateTaskRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime DueDateTime { get; set; }
}