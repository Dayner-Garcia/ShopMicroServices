using ShopMicroServices.OrdersDetails.Application.Core;

namespace ShopMicroServices.OrdersDetails.Application.Dtos
{
    public interface IOrderDetailsServices
    {
        ServiceResults GetOrdersDetails();
        ServiceResults GetOrderDetailsById(int Id);
        ServiceResults SaveOrderDetails(OrderDetailsSaveDto orderDetailsSaveDto);
        ServiceResults UpdateOrderDetails(OrderDetailsUpdateDto orderDetailsUpdateDto);
        ServiceResults RemoveOrderDetails(OrderDetailsRemoveDto orderDetailsRemoveDto);
    }
}