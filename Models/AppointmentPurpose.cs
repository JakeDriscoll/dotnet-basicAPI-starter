using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class AppointmentPurpose
{
    public long Id { get; set; }
}

public class AppointmentPurposeContext : DbContext
{
    public AppointmentPurposeContext(DbContextOptions<AppointmentPurposeContext> options)
        : base(options)
    {
    }

    public DbSet<AppointmentPurpose> AppointmentPurposes { get; set; } = null!;
}
