using Microsoft.Extensions.Logging;
using ShopMicroServices.OrdersDetails.Application.Core;
using ShopMicroServices.OrdersDetails.Application.Dtos;
using ShopMicroServices.OrdersDetails.Application.Extentions;
using ShopMicroServices.OrdersDetails.Domain.Interfaces;

namespace ShopMicroServices.OrdersDetails.Application.Services
{
    public class OrderDetailsServices : IOrderDetailsServices
    {
        private readonly IOrdersDetailsRepository _orderDetailsRepository;
        private readonly ILogger<OrderDetailsServices> _logger;

        public OrderDetailsServices(IOrdersDetailsRepository ordersDetailsRepository,
            ILogger<OrderDetailsServices> logger)
        {
            this._orderDetailsRepository = ordersDetailsRepository;
            this._logger = logger;
        }

        public ServiceResults GetOrdersDetails()
        {
            var result = new ServiceResults();
            try
            {
                var orderDetails = this._orderDetailsRepository.GetAll();
                result.Result = orderDetails;
                result.Message = "OrderDetails retrieved successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieved Details.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResults GetOrderDetailsById(int Id)
        {
            var result = new ServiceResults();
            try
            {
                var orderDetails = _orderDetailsRepository.GetEntityBy(Id);
                if (orderDetails is null)
                {
                    result.Success = false;
                    result.Message = "Detail not found.";
                }
                else
                {
                    result.Result = orderDetails;
                    result.Message = "Detail retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving details.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResults SaveOrderDetails(OrderDetailsSaveDto orderDetailsSaveDto)
        {
            var result = new ServiceResults();
            try
            {
                result = orderDetailsSaveDto.IsvalidOrderDetails();
                if (!result.Success)
                    return result;

                var detail = new Domain.Entities.OrdersDetails
                {
                    Id = orderDetailsSaveDto.OrderId,
                    ProductId = orderDetailsSaveDto.ProductId,
                    UnitPrice = orderDetailsSaveDto.UnitPrice,
                    Qty = orderDetailsSaveDto.Qty,
                    Discount = orderDetailsSaveDto.Discount
                };

                _orderDetailsRepository.Save(detail);
                result.Result = detail;
                result.Message = "Detail saved successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Saving detail.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResults UpdateOrderDetails(OrderDetailsUpdateDto orderDetailsUpdateDto)
        {
            var result = new ServiceResults();
            try
            {
                result = orderDetailsUpdateDto.IsvalidOrderDetails();
                if (!result.Success)
                    return result;

                var detail = _orderDetailsRepository.GetEntityBy(orderDetailsUpdateDto.OrderId);

                detail.Id = orderDetailsUpdateDto.OrderId;
                detail.ProductId = orderDetailsUpdateDto.ProductId;
                detail.UnitPrice = orderDetailsUpdateDto.UnitPrice;
                detail.Qty = orderDetailsUpdateDto.Qty;
                detail.Discount = orderDetailsUpdateDto.Discount;

                _orderDetailsRepository.Update(detail);
                result.Result = detail;
                result.Message = "Detail Updated successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating detail.");
            }

            return result;
        }

        public ServiceResults RemoveOrderDetails(OrderDetailsRemoveDto orderDetailsRemoveDto)
        {
            var result = new ServiceResults();
            try
            {
                var detail = _orderDetailsRepository.GetEntityBy(orderDetailsRemoveDto.OrderId);
                _orderDetailsRepository.Remove(detail);
                result.Message = "Detail removed successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error removing order.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}