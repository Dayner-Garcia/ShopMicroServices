using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.IServices
{
    public interface IOrdersServices
    {
        Task<OrdersGetListResult> GetOrdersAsync();
        Task<OrdersGetResult> GetOrderByIdAsync(int id);
        Task<BaseResult> CreateOrderAsync(OrdersBaseModel order);
        Task<BaseResult> UpdateOrderAsync(int id, OrdersBaseModel order);
        Task<BaseResult> DeleteOrderAsync(int id);
    }
}