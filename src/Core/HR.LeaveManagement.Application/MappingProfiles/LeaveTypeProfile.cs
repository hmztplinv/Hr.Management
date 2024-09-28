using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile: Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>(); 
        // neden ReverseMap() kullanılmadı? Çünkü LeaveTypeDetailsDto sadece okunabilir bir sınıf olduğu için.
        CreateMap<CreateLeaveTypeCommandRequest, LeaveType>();
        CreateMap<UpdateLeaveTypeCommandRequest, LeaveType>();
    }
}