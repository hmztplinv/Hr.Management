using HR.LeaveManagement.Domain.Entities.Common;

namespace HR.LeaveManagement.Domain.Entities;

public class LeaveType: BaseEntity
{
    public string Name { get; set; }=string.Empty;
    public int DefaultDays { get; set; }
}