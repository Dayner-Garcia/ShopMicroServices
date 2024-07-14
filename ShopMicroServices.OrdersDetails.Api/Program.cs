using Microsoft.EntityFrameworkCore;
using ShopMicroServices.OrderDetails.IOC.Dependencies;
using ShopMicroServices.OrdersDetails.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrdersDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDetailsContext")));

// Agregar dependencias del modulo.

builder.Services.AddOrderDetailsDependency();



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