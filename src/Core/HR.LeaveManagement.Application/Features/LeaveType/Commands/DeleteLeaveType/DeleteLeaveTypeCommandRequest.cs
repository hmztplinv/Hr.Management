﻿using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandRequest: IRequest<Unit>
{
    public int Id { get; set; }
}