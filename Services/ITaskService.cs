using TaskManagementApi.Models.DTOs;

namespace TaskManagementApi.Services;

public interface ITaskService
{
    Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request);
}