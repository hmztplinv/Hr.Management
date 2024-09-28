using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.LeaveManagement.Persistence.Contexts;

public class HrDatabaseContextFactory: IDesignTimeDbContextFactory<HrDatabaseContext>
{
    public HrDatabaseContext CreateDbContext(string[] args)
    {
        // Bu kısım, appsettings.json dosyasını kullanarak bağlamayı sağlar.
        var optionsBuilder = new DbContextOptionsBuilder<HrDatabaseContext>();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Api", "HR.LeaveManagement.Api"))
            .AddJsonFile("appsettings.json")
            .Build();


        // Bağlantı dizesini appsettings.json'dan alıyoruz.
        var connectionString = configuration.GetConnectionString("HrLeaveManagementConnectionString"); // Bağlantı dizesinin adı

        // DbContextOptions ayarlıyoruz.
        optionsBuilder.UseSqlServer(connectionString);

        // HrDatabaseContext oluşturuyoruz.
        return new HrDatabaseContext(optionsBuilder.Options);
    }
}