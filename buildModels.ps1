function MakeClass([string]$className) {
$baseBody = 
@"
using Microsoft.EntityFrameworkCore;

namespace basicAPI.Models;

public class $($className)
{
    public long Id { get; set; }
}

public class $($className)Context : DbContext
{
    public $($className)Context(DbContextOptions<$($className)Context> options)
        : base(options)
    {
    }

    public DbSet<$($className)> $($className)s { get; set; } = null!;
}
"@

function MakeController([string]$className) {

    dotnet-aspnet-codegenerator controller -name $($className)Controller -async -api -m $($className) -dc $($className)Context -outDir Controllers
}

Write-Output $baseBody >> Models\$($className).cs
}

function WriteHelper([string]$className) {
    $helper = @"
builder.Services.AddDbContext<$($className)Context>(opt =>
    opt.UseInMemoryDatabase("$($className)List"));
"@

    Write-Host $helper
    
}

MakeClass "BasicSetting"
MakeClass "PracticeSetting"
MakeClass "AppointmentType"
MakeClass "Provider"
MakeClass "AppointmentPurpose"
MakeClass "Location"

Write-Host "Add the context to your Program.cs with"
WriteHelper "BasicSetting"
WriteHelper "PracticeSetting"
WriteHelper "AppointmentType"
WriteHelper "Provider"
WriteHelper "AppointmentPurpose"
WriteHelper "Location"


