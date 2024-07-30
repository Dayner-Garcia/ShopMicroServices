using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.IServices
{
    public interface IOrdersDetailsServices
    {
        Task<OrdersDetailsGetListResult> GetOrdersDetailsAsync();
        Task<OrdersDetailsGetResult> GetOrderDetailByIdAsync(int id);
        Task<BaseResult> CreateOrderDetailAsync(OrdersDetailsBaseModel orderDetail);
        Task<BaseResult> UpdateOrderDetailAsync(int id, OrdersDetailsBaseModel orderDetail);
        Task<BaseResult> DeleteOrderDetailAsync(int id);
    }
}