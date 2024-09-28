using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDto>;