using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class BasicSetting
{
    public long Id { get; set; }
}

public class BasicSettingContext : DbContext
{
    public BasicSettingContext(DbContextOptions<BasicSettingContext> options)
        : base(options)
    {
    }

    public DbSet<BasicSetting> BasicSettings { get; set; } = null!;
}
