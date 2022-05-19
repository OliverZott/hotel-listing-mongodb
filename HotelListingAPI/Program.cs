using HotelListingAPI.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

// configuration instance to which the appsettings.json section binds is registered to DI container
builder.Services.Configure<HotelDatabaseSettings>(builder.Configuration.GetSection("HotelDatabase"));




var app = builder.Build();

// Middleware: Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
