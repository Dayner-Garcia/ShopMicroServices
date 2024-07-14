using ShopMicroServices.Customers.Application.Base;
using ShopMicroServices.Customers.Application.Dtos;

namespace ShopMicroServices.Customers.Application.Extentions
{
    public static class ValidCustomers
    {
        public static ServiceResults IsValidCustomer(this BaseDto customer)
        {
            ServiceResults results = new ServiceResults();

            if (customer is null)
            {
                results.Success = false;
                results.Message = $"El objeto {nameof(customer)} es requerido.";
                return results;
            }

            if (!customer.NuevoCustomer && customer.CustId == 0)
            {
                results.Success = false;
                results.Message = "Customer no existente.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.CompanyName))
            {
                results.Success = false;
                results.Message = "El nombre de la compañia es requerido.";
                return results;
            }
            else if (customer.CompanyName.Length > 40)
            {
                results.Success = false;
                results.Message = "El nombre de la compañia no puede ser mayor a 40 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.ContactName))
            {
                results.Success = false;
                results.Message = "El nombre de contacto es invalido.";
                return results;
            }
            else if (customer.ContactName.Length > 30)
            {
                results.Success = false;
                results.Message = "El nombre de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.ContactTitle))
            {
                results.Success = false;
                results.Message = "El titulo de contacto es invalido.";
                return results;
            }
            else if (customer.ContactTitle.Length > 30)
            {
                results.Success = false;
                results.Message = "El titulo de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.Address))
            {
                results.Success = false;
                results.Message = "La direccion es invalida.";
                return results;
            }
            else if (customer.Address.Length > 60)
            {
                results.Success = false;
                results.Message = "La direccion no puede ser mayor a 60 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.Email))
            {
                results.Success = false;
                results.Message = "El email es invalido.";
                return results;
            }
            else if (customer.Email.Length > 50)
            {
                results.Success = false;
                results.Message = "El email no puede ser mayor a 50 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.City))
            {
                results.Success = false;
                results.Message = "La ciudad es invalida.";
                return results;
            }
            else if (customer.City.Length > 15)
            {
                results.Success = false;
                results.Message = "La ciudad no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (customer.Region.Length > 15)
            {
                results.Success = false;
                results.Message = "La region no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (customer.PostalCode.Length > 10)
            {
                results.Success = false;
                results.Message = "El codigo postal no puede ser mayor a 10 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.Country))
            {
                results.Success = false;
                results.Message = "El pais es invalido.";
                return results;
            }
            else if (customer.Country.Length > 15)
            {
                results.Success = false;
                results.Message = "El pais no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(customer.Phone))
            {
                results.Success = false;
                results.Message = "El telefono es invalido.";
                return results;
            }
            else if (customer.Phone.Length > 24)
            {
                results.Success = false;
                results.Message = "El telefono no puede ser mayor a 24 caracteres.";
                return results;
            }

            if (customer.Fax.Length > 24)
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