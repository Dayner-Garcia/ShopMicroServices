using Microsoft.Extensions.Logging;
using ShopMicroServices.Orders.Application.Core;
using ShopMicroServices.Orders.Application.Contracts;
using ShopMicroServices.Orders.Application.Dtos;
using ShopMicroServices.Orders.Domain.Interfaces;
using ShopMicroServices.Orders.Application.Extentions;

namespace ShopMicroServices.Orders.Application.Services
{
    public class OrderServices : IOrdersServices
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ILogger<OrderServices> _logger;

        public OrderServices(IOrdersRepository orderRepository, ILogger<OrderServices> logger)
        {
            this._orderRepository = orderRepository;
            this._logger = logger;
        }

        public ServiceResults GetOrderById(int id)
        {
            var result = new ServiceResults();
            try
            {
                var order = _orderRepository.GetEntityBy(id);
                if (order is null)
                {
                    result.Success = false;
                    result.Message = "Order not found.";
                }
                else
                {
                    result.Result = order;
                    result.Message = "Order retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Order.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults GetOrders()
        {
            var result = new ServiceResults();
            try
            {
                var orders = this._orderRepository.GetAll();
                result.Result = orders;
                result.Message = "Orders retrieved successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults RemoveOrder(OrderRemoveDto orderRemoveDto)
        {
            var result = new ServiceResults();
            try
            {
                var order = _orderRepository.GetEntityBy(orderRemoveDto.OrderId);
                _orderRepository.Remove(order);
                result.Message = "Order removed successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing order.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults SaveOrder(OrderSaveDto orderSaveDto)
        {
            var result = new ServiceResults(); 
            try
            {
                result = orderSaveDto.IsValidOrder();
                if (!result.Success)
                    return result;

                var order = new Domain.Entities.Orders
                {
                    Id = orderSaveDto.OrderId,
                    CustId = orderSaveDto.CustId,
                    EmpId = orderSaveDto.EmpId,
                    OrderDate = orderSaveDto.OrderDate,
                    RequiredDate = orderSaveDto.RequiredDate,
                    ShippedDate = orderSaveDto.ShippedDate,
                    ShipperId = orderSaveDto.ShipperId,
                    Freight = orderSaveDto.Freight,
                    ShipName = orderSaveDto.ShipName,
                    ShipAddress = orderSaveDto.ShipAddress,
                    ShipCity = orderSaveDto.ShipCity,
                    ShipRegion = orderSaveDto.ShipRegion,
                    ShipPostalCode = orderSaveDto.ShipPostalCode,
                    ShipCountry = orderSaveDto.ShipCountry
                };
                
                _orderRepository.Save(order);
                result.Result = order;
                result.Message = "Order saved succesfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving order.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults UpdateOrder(OrderUpdateDto orderUpdateDto)
        {
            var result = new ServiceResults();
            try
            {
                result = orderUpdateDto.IsValidOrder();
                if (!result.Success)
                    return result;

                var order = _orderRepository.GetEntityBy(orderUpdateDto.OrderId);

                order.Id = orderUpdateDto.OrderId;
                order.CustId = orderUpdateDto.CustId;
                order.EmpId = orderUpdateDto.EmpId;
                order.OrderDate = orderUpdateDto.OrderDate;
                order.RequiredDate = orderUpdateDto.RequiredDate;
                order.ShippedDate = orderUpdateDto.ShippedDate;
                order.ShipperId = orderUpdateDto.ShipperId;
                order.Freight = orderUpdateDto.Freight;
                order.ShipName = orderUpdateDto.ShipName;
                order.ShipAddress = orderUpdateDto.ShipAddress;
                order.ShipCity = orderUpdateDto.ShipCity;
                order.ShipRegion = orderUpdateDto.ShipRegion;
                order.ShipPostalCode = orderUpdateDto.ShipPostalCode;
                order.ShipCountry = orderUpdateDto.ShipCountry;

                _orderRepository.Update(order);
                result.Result = order;
                result.Message = "Order Updated succesfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Updating order.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}