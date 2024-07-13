using Microsoft.Extensions.DependencyInjection;
using ShopMicroServices.Customers.Application.Contracts;
using ShopMicroServices.Customers.Application.Services;
using ShopMicroServices.Customers.Domain.Interfaces;
using ShopMicroServices.Customers.Persistence.Repository;

namespace ShopMicroServices.Customers.IOC.Dependencies
{
    public static class CustomersDependency
    {
        public static void AddCustomersDependency(this IServiceCollection service)
        {
            #region"Customer Repositories"

            service.AddScoped<ICustomersRepository, CustomersRepository>();
            
            #endregion

            #region "Customers Services"

            service.AddTransient<ICustomersService, CustomerServices>();

            #endregion
        }
    }
}
