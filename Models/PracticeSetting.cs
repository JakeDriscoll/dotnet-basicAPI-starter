using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class PracticeSetting
{
    public long Id { get; set; }
}

public class PracticeSettingContext : DbContext
{
    public PracticeSettingContext(DbContextOptions<PracticeSettingContext> options)
        : base(options)
    {
    }

    public DbSet<PracticeSetting> PracticeSettings { get; set; } = null!;
}
