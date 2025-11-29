using TaskManagementApi.Data;
using TaskManagementApi.Models;
using TaskManagementApi.Models.DTOs;

namespace TaskManagementApi.Services;

public class TaskService : ITaskService
{
    private readonly TaskDbContext _context;

    public TaskService(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request)
    {
        // Parse the status string to enum
        if (!Enum.TryParse<TaskStatus>(request.Status, true, out var statusEnum))
        {
            throw new ArgumentException($"Invalid status: {request.Status}");
        }

        var taskItem = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Status = statusEnum,
            DueDateTime = request.DueDateTime,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(taskItem);
        await _context.SaveChangesAsync();

        return new TaskResponse
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            Status = taskItem.Status.ToString(),
            DueDateTime = taskItem.DueDateTime,
            CreatedAt = taskItem.CreatedAt
        };
    }
}