using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using TaskManagementApi.Models.DTOs;
using TaskManagementApi.Services;

namespace TaskManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IValidator<CreateTaskRequest> _validator;
    private readonly ILogger<TasksController> _logger;

    public TasksController(
        ITaskService taskService,
        IValidator<CreateTaskRequest> validator,
        ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _validator = validator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TaskResponse>> CreateTask([FromBody] CreateTaskRequest request)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation failed",
                    errors = validationResult.Errors.Select(e => new
                    {
                        field = e.PropertyName,
                        error = e.ErrorMessage
                    })
                });
            }

            var taskResponse = await _taskService.CreateTaskAsync(request);

            _logger.LogInformation("Task created successfully with ID: {TaskId}", taskResponse.Id);

            return CreatedAtAction(nameof(CreateTask), new { id = taskResponse.Id }, taskResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating task");
            return StatusCode(500, new { message = "An error occurred while creating the task" });
        }
    }
}