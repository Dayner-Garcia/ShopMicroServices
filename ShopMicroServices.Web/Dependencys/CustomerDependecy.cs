using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Services;

namespace ShopMicroServices.Web.DependencyInjection
{
    public static class CustomerDependecy
    {
        public static void AddCustomersDependency(this IServiceCollection service)
        {
            service.AddHttpClient<ICustomersServices, CustomerServices>();
        }
    }
}