using Microsoft.EntityFrameworkCore;
using ShopMicroServices.Orders.Persistence.Context;
using ShopMicroServices.Orders.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrdersContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersContext")));

// agregar dependencias del modulo order.

builder.Services.AddOrdersDependency();



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
