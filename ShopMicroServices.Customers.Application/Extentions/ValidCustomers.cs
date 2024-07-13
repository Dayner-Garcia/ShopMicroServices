
using ShopMicroServices.Customers.Application.Base;
using ShopMicroServices.Customers.Application.Dtos;

namespace ShopMicroServices.Customers.Application.Extentions
{
    public static class ValidCustomers
    {
        public static ServiceResults IsValidCourse(this DtoBase baseCustomer)
        {
            ServiceResults results = new ServiceResults();

            if (baseCustomer is null)
            {
                results.Success = false;
                results.Message = $"El objeto{nameof(baseCustomer)} es requerido.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer?.CompanyName))
            {
                results.Success = false;
                results.Message = $"El nombre de la compañia es requerido.";
                return results;
            }

            // Otras validaciones !

            return results;
        }
    }
}
