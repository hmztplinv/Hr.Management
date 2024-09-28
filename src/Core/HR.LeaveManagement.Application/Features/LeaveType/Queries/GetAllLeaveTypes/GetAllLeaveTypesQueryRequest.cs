using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

// public class GetLeaveTypesQueryRequest : IRequest<List<LeaveTypeDto>>
// {
//     
// }

public record GetAllLeaveTypesQueryRequest : IRequest<List<LeaveTypeDto>>;

// record kullanmamızın sebebi immutable olmasıdır.
// Bu sayede nesnelerimiz değişmez olur ve daha güvenli bir yapı oluşturmuş oluruz.
// recordlar varsayılan olarak immutable'dır. Yani içerisindeki property'lerin değerleri değiştirilemez.
// Bu sayede nesnelerimiz daha güvenli olur.
// recordlar varsayılan olarak değer tipidir. Yani stack'te tutulurlar.
// recordlar varsayılan olarak readonly'dir. Yani sadece constructor içerisinde değer atanabilirler.
// recordlar varsayılan olarak structural equality'e sahiptir. Yani iki record nesnesi aynı property değerlerine sahipse eşit kabul edilirler.