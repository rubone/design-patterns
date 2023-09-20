using Factory.Constants;
using Factory.DI;
using Factory.Models;
using Plane = Factory.Models.Plane;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransportFactory()
    .AddTransport<Truck>(TransportType.Truck)
    .AddTransport<Ship>(TransportType.Ship)
    .AddTransport<Plane>(TransportType.Plane);

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