using FluentValidation;
using TaskManagementApi.Models;
using TaskManagementApi.Models.DTOs;

namespace TaskManagementApi.Validators;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required")
            .Must(BeAValidStatus).WithMessage("Invalid status. Valid values are: Pending, InProgress, Completed, OnHold");

        RuleFor(x => x.DueDateTime)
            .NotEmpty().WithMessage("Due date/time is required")
            .GreaterThan(DateTime.Now).WithMessage("Due date/time must be in the future");
    }

    private bool BeAValidStatus(string status)
    {
        return Enum.TryParse<Models.TaskStatus>(status, true, out _);
    }
}