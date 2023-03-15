using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class Provider
{
    public long Id { get; set; }
}

public class ProviderContext : DbContext
{
    public ProviderContext(DbContextOptions<ProviderContext> options)
        : base(options)
    {
    }

    public DbSet<Provider> Providers { get; set; } = null!;
}
