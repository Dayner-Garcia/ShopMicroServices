using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Services;

namespace ShopMicroServices.Web.DependencyInjection
{
    public static class OrdersDependency
    {
        public static void AddOrdersDependency(this IServiceCollection services)
        {
            services.AddHttpClient<IOrdersServices, OrdersServices>();
        }
    }
}