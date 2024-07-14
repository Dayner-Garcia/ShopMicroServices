using Microsoft.Extensions.Logging;
using ShopMicroServices.Customers.Application.Base;
using ShopMicroServices.Customers.Application.Contracts;
using ShopMicroServices.Customers.Application.Dtos;
using ShopMicroServices.Customers.Application.Extentions;
using ShopMicroServices.Customers.Domain.Interfaces;

namespace ShopMicroServices.Customers.Application.Services
{
    public class CustomerServices : ICustomersService
    {
        private readonly ICustomersRepository customerRepository;
        private readonly ILogger<CustomerServices> logger;

        public CustomerServices(ICustomersRepository customerRepository, ILogger<CustomerServices> logger)
        {
            this.customerRepository = customerRepository;
            this.logger = logger;
        }

        public ServiceResults GetCustomerById(int id)
        {
            var result = new ServiceResults();
            try
            {
                var customer = customerRepository.GetEntityBy(id);
                if (customer is null)
                {
                    result.Success = false;
                    result.Message = "Customer not found.";
                }
                else
                {
                    result.Result = customer;
                    result.Message = "Customer retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Errror retrieving customer.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults GetCustomers()
        {
            var result = new ServiceResults();
            try
            {
                var customers = customerRepository.GetAll();
                result.Result = customers;
                result.Message = "Customers retrieved successfully.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving customers.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults RemoveCustomer(CustomerDtoRemove customerDtoRemove)
        {
            var result = new ServiceResults();
            try
            {
                var customer = customerRepository.GetEntityBy(customerDtoRemove.CustId);

                customerRepository.Remove(customer);
                result.Message = "Customer removed successfully.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error removing customer.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults SaveCustomer(CustomerDtoSave customerDtoSave)
        {
            var result = new ServiceResults();
            try
            {
                result = customerDtoSave.IsValidCustomer();
                if (!result.Success)
                    return result;
                
                var customer = new Domain.Entities.Customers
                {
                    Id = customerDtoSave.CustId,
                    CompanyName = customerDtoSave.CompanyName,
                    ContactName = customerDtoSave.ContactName,
                    ContactTitle = customerDtoSave.ContactTitle,
                    Address = customerDtoSave.Address,
                    Email = customerDtoSave.Email,
                    City = customerDtoSave.City,
                    Region = customerDtoSave.Region,
                    PostalCode = customerDtoSave.PostalCode,
                    Country = customerDtoSave.Country,
                    Phone = customerDtoSave.Phone,
                    Fax = customerDtoSave.Fax
                };

                customerRepository.Save(customer);
                result.Result = customer;
                result.Message = "Customer saved successfully.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error saving customer.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResults UpdateCustomer(CustomerDtoUpdate customerDtoUpdate)
        {
            var result = new ServiceResults();
            try
            {
                result = customerDtoUpdate.IsValidCustomer();
                if (!result.Success)
                    return result;
             
                var customer = customerRepository.GetEntityBy(customerDtoUpdate.CustId);

                customer.CompanyName = customerDtoUpdate.CompanyName;
                customer.ContactName = customerDtoUpdate.ContactName;
                customer.ContactTitle = customerDtoUpdate.ContactTitle;
                customer.Address = customerDtoUpdate.Address;
                customer.Email = customerDtoUpdate.Email;
                customer.City = customerDtoUpdate.City;
                customer.Region = customerDtoUpdate.Region;
                customer.PostalCode = customerDtoUpdate.PostalCode;
                customer.Country = customerDtoUpdate.Country;
                customer.Phone = customerDtoUpdate.Phone;
                customer.Fax = customerDtoUpdate.Fax;

                customerRepository.Update(customer);
                result.Result = customer;
                result.Message = "Customer updated successfully.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating customer.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}