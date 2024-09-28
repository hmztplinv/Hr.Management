using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveTypesController: ControllerBase
{
    private readonly IMediator _mediator;
    
    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<List<LeaveTypeDto>> GetLeaveTypes()
    {
        var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQueryRequest());
        return leaveTypes;
    }
    
    [HttpGet("{id}")]
    public async Task<LeaveTypeDetailsDto> GetLeaveType(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQueryRequest(id));
        return leaveType;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLeaveType(CreateLeaveTypeCommandRequest leaveType)
    {
        var response = await _mediator.Send(leaveType);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateLeaveType(UpdateLeaveTypeCommandRequest leaveType)
    {
        var response = await _mediator.Send(leaveType);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveType(int id)
    {
        var response = await _mediator.Send(new DeleteLeaveTypeCommandRequest{Id=id});
        return Ok(response);
    }
}