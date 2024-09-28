namespace HR.LeaveManagement.Domain.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    
}
// neden abstract class kullandık?
// BaseEntity sınıfı, diğer sınıflar tarafından kalıtım alınarak kullanılacak bir sınıf olduğu için abstract olarak işaretledik.
// asbstract kullanmasaydık, BaseEntity sınıfından nesne oluşturulabilirdi. Bu durumda, BaseEntity sınıfından nesne oluşturulmasını istemiyoruz.