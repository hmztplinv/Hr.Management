using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandRequest: IRequest<int>
{
    public string Name { get; set; }= string.Empty;
    public int DefaultDays { get; set; }
}