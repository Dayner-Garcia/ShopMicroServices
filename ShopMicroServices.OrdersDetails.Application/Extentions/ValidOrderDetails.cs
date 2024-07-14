using ShopMicroServices.OrdersDetails.Application.Core;
using ShopMicroServices.OrdersDetails.Application.Dtos;

namespace ShopMicroServices.OrdersDetails.Application.Extentions
{
    public static class ValidOrderDetails
    {
        public static ServiceResults IsvalidOrderDetails(this BaseDto orderDetails)
        {
            ServiceResults results = new ServiceResults();

            if (orderDetails is null)
            {
                results.Success = false;
                results.Message = $"El objeto {nameof(orderDetails)} es requerida.";
                return results;
            }

            if (!orderDetails.NewDetail && orderDetails.OrderId <= 0)
            {
                results.Success = false;
                results.Message = "Orden no existente.";
                return results;
            }

            if (orderDetails.ProductId <= 0)
            {
                results.Success = false;
                results.Message = "Producto no existente, seleccione un producto existente.";
                return results;
            }

            if (orderDetails.UnitPrice <= 0)
            {
                results.Success = false;
                results.Message = "El precio unitario no puede ser nulo";
                return results;
            }

            if (orderDetails.Qty <= 0)
            {
                results.Success = false;
                results.Message = "La cantidad no puede ser nulo.";
                return results;
            }

            if (orderDetails.Discount <= 0)
            {
                results.Success = false;
                results.Message = "El descuento no puede ser nulo.";
                return results;
            }

            if (orderDetails.Discount >= 10)
            {
                results.Success = false;
                results.Message =
                    "El descuento tiene que estar en un rango de max 4 numeros ejemplo 1.000 de descuento";
                return results;
            }

            return results;
        }
    }
}