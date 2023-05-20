using GeoChat.Geolocation.Api.DbAccess;
using GeoChat.Geolocation.Api.Entities;
using GeoChat.Geolocation.Api.Repo;
using GeoChat.Geolocation.Api.AuthExtensions;
using Microsoft.EntityFrameworkCore;
using GeoChat.Geolocation.Api.EventBus;
using GeoChat.Geolocation.Api.RabbitMqEventBus.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.RegisterAuthServices(builder.Configuration);

builder.Services.RegisterSwaggerWithAuthInformation();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GeolocationDb"));
});

builder.Services.AddScoped<IGenericRepo<Location>, GenericRepo<Location>>();

builder.Services.AddScoped<IGenericRepo<Server>, GenericRepo<Server>>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IEventBus, MockEventBus>();
}
else
{
    builder.Services.RegisterEventBus();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
 
app.Run();
