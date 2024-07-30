using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Services;

namespace ShopMicroServices.Web.DependencyInjection
{
    public static class OrdersDetailsDependency
    {
        public static void AddOrdersDetailsDependency(this IServiceCollection services)
        {
            services.AddHttpClient<IOrdersDetailsServices, OrdersDetailsServices>();
        }
    }
}