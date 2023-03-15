using Microsoft.EntityFrameworkCore;
using basicAPI.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BasicSettingContext>(opt =>
    opt.UseInMemoryDatabase("BasicSettingList"));
builder.Services.AddDbContext<PracticeSettingContext>(opt =>
    opt.UseInMemoryDatabase("PracticeSettingList"));
builder.Services.AddDbContext<AppointmentTypeContext>(opt =>
    opt.UseInMemoryDatabase("AppointmentTypeList"));
builder.Services.AddDbContext<ProviderContext>(opt =>
    opt.UseInMemoryDatabase("ProviderList"));
builder.Services.AddDbContext<AppointmentPurposeContext>(opt =>
    opt.UseInMemoryDatabase("AppointmentPurposeList"));
builder.Services.AddDbContext<LocationContext>(opt =>
    opt.UseInMemoryDatabase("LocationList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
