using ShopMicroServices.Orders.Domain.Interfaces;
using ShopMicroServices.Orders.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using ShopMicroServices.Orders.Application.Contracts;
using ShopMicroServices.Orders.Application.Services;

namespace ShopMicroServices.Orders.IOC.Dependencies
{
    public static class OrdersDependency
    {
        public static void AddOrdersDependency(this IServiceCollection services)
        {
            #region"Orders Repositories"

            services.AddScoped<IOrdersRepository, OrdersRepository>();

            #endregion

            #region "Orders Services"

            services.AddTransient<IOrdersServices, OrderServices>();

            #endregion
        }
    }
}