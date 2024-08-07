using ShopMicroServices.Web.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add customers Dependency
builder.Services.AddCustomersDependency();

// Add orders Dependency
builder.Services.AddOrdersDependency();

// ADdd OrdersDetails Dependency
builder.Services.AddOrdersDetailsDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();