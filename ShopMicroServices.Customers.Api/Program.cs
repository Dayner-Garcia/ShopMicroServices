using Microsoft.EntityFrameworkCore;
using ShopMicroServices.Customers.Domain.Interfaces;
using ShopMicroServices.Customers.Persistence.Context;
using ShopMicroServices.Customers.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connstring = builder.Configuration.GetConnectionString("CustomersContext");


builder.Services.AddDbContext<CustomersContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomersContext")));

// Agregar dependencias del objeto a datos //
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();


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
