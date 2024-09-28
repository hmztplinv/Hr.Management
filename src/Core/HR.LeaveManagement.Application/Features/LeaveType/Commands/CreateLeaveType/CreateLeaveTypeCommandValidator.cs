using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class CreateLeaveTypeCommandValidator: AbstractValidator<CreateLeaveTypeCommandRequest>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(365).WithMessage("{PropertyName} must be less than 365")
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than 1");

        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave Type with the same name already exists");
    }

    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommandRequest command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}