using ShopMicroServices.Orders.Application.Core;
using ShopMicroServices.Orders.Application.Dtos;

namespace ShopMicroServices.Orders.Application.Contracts
{
    public interface IOrdersServices
    {
        ServiceResults GetOrders();
        ServiceResults GetOrderById(int id);
        ServiceResults SaveOrder(OrderSaveDto orderSaveDto);
        ServiceResults UpdateOrder(OrderUpdateDto orderUpdateDto);
        ServiceResults RemoveOrder(OrderRemoveDto orderRemoveDto);
    }
}