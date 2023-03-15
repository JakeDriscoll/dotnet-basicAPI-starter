using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class Location
{
    public long Id { get; set; }
}

public class LocationContext : DbContext
{
    public LocationContext(DbContextOptions<LocationContext> options)
        : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; } = null!;
}
