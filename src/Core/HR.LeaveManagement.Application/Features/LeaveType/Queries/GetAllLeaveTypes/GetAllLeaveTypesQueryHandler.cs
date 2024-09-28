using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryHandler: IRequestHandler<GetAllLeaveTypesQueryRequest, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetAllLeaveTypesQueryHandler> _logger;
    
    public GetAllLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetAllLeaveTypesQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }
    
    public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var allLeaveTypes = await _leaveTypeRepository.GetAsync();
        var data = _mapper.Map<List<LeaveTypeDto>>(allLeaveTypes);
        _logger.LogInformation("All Leave Types are retrieved");
        return data;
    }
}