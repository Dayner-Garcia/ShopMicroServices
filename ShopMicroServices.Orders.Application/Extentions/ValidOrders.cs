using ShopMicroServices.Orders.Application.Core;
using ShopMicroServices.Orders.Application.Dtos;

namespace ShopMicroServices.Orders.Application.Extentions
{
    public static class ValidOrders
    {
        public static ServiceResults IsValidOrder(this BaseDto order)
        {
            ServiceResults results = new ServiceResults();

            if (order is null)
            {
                results.Success = false;
                results.Message = $"El Objeto {nameof(order)} es requerido.";
                return results;
            }
            
            if (!order.NewOrder && order.OrderId <= 0) 
            {
                results.Success = false;
                results.Message = "Orden no existente.";
                return results;
            }

            if (order.CustId <= 0 )
            {
                results.Success = false;
                results.Message = "El Id del customer no puede ser menor a 1.";
                return results;
            }
           
            if (order.EmpId <= 0)
            {
                results.Success = false;
                results.Message = "El Id del empleado no puede ser nulo ni negativo.";
                return results;
            }

            if (order.OrderDate == null || order.OrderDate < DateTime.Now)
            {
                results.Success = false;
                results.Message = "La fecha de la creacion de la orden no puede ser nula ni menor a la actual.";
                return results;
            }
            if (order.RequiredDate < DateTime.Now)
            {
                results.Success = false;
                results.Message = "La fecha requerida no puede ser menor a la actual.";
                return results;
            }
            if (order.ShipperId == null && order.ShipperId <= 0)
            {
                results.Success = false;
                results.Message = "El Id del shipper no puede ser nulo ni negativo.";
                return results;
            }
            if (order.Freight == null || order.Freight <= 0)
            {
                results.Success = false;
                results.Message = "El precio del transporte no puede ser nulo ni negativo.";
                return results;
            }
            if (string.IsNullOrEmpty(order.ShipName)) 
            {
                results.Success = false;
                results.Message = "El ShipName no puede ser nulo.";
                return results;
            }
            if (order.ShipName.Length > 40)
            {
                results.Success = false;
                results.Message = "El shipName no puede ser mayor a 40.";
                return results;
            }
            if (string.IsNullOrEmpty(order.ShipAddress))
            {
                results.Success = false;
                results.Message = "El ShipAdress no puede ser nulo.";
                return results;
            }
            if (order.ShipAddress.Length > 60)
            {
                results.Success = false;
                results.Message = "El shipAdrres no puede ser mayor a 60";
                return results;
            }

            if (string.IsNullOrEmpty(order.ShipCity))
            {
                results.Success = false;
                results.Message = "EL ShipCity no puede ser nulo.";
                return results;
            }
            if (order.ShipCity.Length > 15)
            {
                results.Success = false;
                results.Message = "El Shipcity no puede ser mayor a 15.";
                return results;
            }
            if (order.ShipRegion.Length > 15)
            {
                results.Success = false;
                results.Message = "El Shipregion no puede ser mayor a 15.";
                return results;
            }
            if (order.ShipPostalCode.Length > 10)
            {
                results.Success = false;
                results.Message = "El ShipPostalCode no puede ser mayor a 10.";
                return results;
            }
            if (string.IsNullOrEmpty(order.ShipCountry))
            {
                results.Success = false;
                results.Message = "El shipCounry no puede ser nulo.";
                return results;
            }
            if (order.ShipCountry.Length > 15)
            {
                results.Success = false;
                results.Message = "El shipCountry no puede ser mayor a 15.";
                return results;
            }
            return results;
        }
    }
}