using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class AppointmentType
{
    public long Id { get; set; }
}

public class AppointmentTypeContext : DbContext
{
    public AppointmentTypeContext(DbContextOptions<AppointmentTypeContext> options)
        : base(options)
    {
    }

    public DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;
}
