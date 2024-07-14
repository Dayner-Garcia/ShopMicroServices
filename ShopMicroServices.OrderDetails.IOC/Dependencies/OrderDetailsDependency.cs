using Microsoft.Extensions.DependencyInjection;
using ShopMicroServices.OrdersDetails.Application.Dtos;
using ShopMicroServices.OrdersDetails.Application.Services;
using ShopMicroServices.OrdersDetails.Domain.Interfaces;
using ShopMicroServices.OrdersDetails.Persistence.Repository;

namespace ShopMicroServices.OrderDetails.IOC.Dependencies
{
    public static class OrderDetailsDependency
    {
        public static void AddOrderDetailsDependency(this IServiceCollection service)
        {
            #region "Details Repositories"

            service.AddScoped<IOrdersDetailsRepository, OrdersDetailsRepository>();

            #endregion

            #region "Details Services"

            service.AddTransient<IOrderDetailsServices, OrderDetailsServices>();

            #endregion
        }
    }
}