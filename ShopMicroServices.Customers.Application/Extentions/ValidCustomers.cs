using ShopMicroServices.Customers.Application.Base;
using ShopMicroServices.Customers.Application.Dtos;

namespace ShopMicroServices.Customers.Application.Extentions
{
    public static class ValidCustomers
    {
        public static ServiceResults IsValidCustomer(this DtoBase baseCustomer)
        {
            ServiceResults results = new ServiceResults();

            if (baseCustomer is null)
            {
                results.Success = false;
                results.Message = $"El objeto {nameof(baseCustomer)} es requerido.";
                return results;
            }

            if (!baseCustomer.NuevoCustomer && baseCustomer.CustId == 0)
            {
                results.Success = false;
                results.Message = "Customer no existente.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.CompanyName))
            {
                results.Success = false;
                results.Message = "El nombre de la compañia es requerido.";
                return results;
            }
            else if (baseCustomer.CompanyName.Length > 40)
            {
                results.Success = false;
                results.Message = "El nombre de la compañia no puede ser mayor a 40 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.ContactName))
            {
                results.Success = false;
                results.Message = "El nombre de contacto es invalido.";
                return results;
            }
            else if (baseCustomer.ContactName.Length > 30)
            {
                results.Success = false;
                results.Message = "El nombre de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.ContactTitle))
            {
                results.Success = false;
                results.Message = "El titulo de contacto es invalido.";
                return results;
            }
            else if (baseCustomer.ContactTitle.Length > 30)
            {
                results.Success = false;
                results.Message = "El titulo de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Address))
            {
                results.Success = false;
                results.Message = "La direccion es invalida.";
                return results;
            }
            else if (baseCustomer.Address.Length > 60)
            {
                results.Success = false;
                results.Message = "La direccion no puede ser mayor a 60 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Email))
            {
                results.Success = false;
                results.Message = "El email es invalido.";
                return results;
            }
            else if (baseCustomer.Email.Length > 50)
            {
                results.Success = false;
                results.Message = "El email no puede ser mayor a 50 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.City))
            {
                results.Success = false;
                results.Message = "La ciudad es invalida.";
                return results;
            }
            else if (baseCustomer.City.Length > 15)
            {
                results.Success = false;
                results.Message = "La ciudad no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (baseCustomer.Region.Length > 15)
            {
                results.Success = false;
                results.Message = "La region no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (baseCustomer.PostalCode.Length > 10)
            {
                results.Success = false;
                results.Message = "El codigo postal no puede ser mayor a 10 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Country))
            {
                results.Success = false;
                results.Message = "El pais es invalido.";
                return results;
            }
            else if (baseCustomer.Country.Length > 15)
            {
                results.Success = false;
                results.Message = "El pais no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Phone))
            {
                results.Success = false;
                results.Message = "El telefono es invalido.";
                return results;
            }
            else if (baseCustomer.Phone.Length > 24)
            {
                results.Success = false;
                results.Message = "El telefono no puede ser mayor a 24 caracteres.";
                return results;
            }

            if (baseCustomer.Fax.Length > 24)
            {
                results.Success = false;
                results.Message = "El fax no puede ser mayor a 24 caracteres.";
                return results;
            }

            results.Success = true;
            results.Message = "Validacion exitosa.";
            return results;
        }
    }
}