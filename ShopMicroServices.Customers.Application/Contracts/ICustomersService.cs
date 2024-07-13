
using ShopMicroServices.Customers.Application.Base;
using ShopMicroServices.Customers.Application.Dtos;

namespace ShopMicroServices.Customers.Application.Contracts
{
    public interface ICustomersService
    {
        ServiceResults GetCustomers();
        ServiceResults GetCustomerById(int id);
        ServiceResults UpdateCustomer(CustomerDtoUpdate customerDtoUpdate);
        ServiceResults SaveCustomer(CustomerDtoSave customerDtoSave);
        ServiceResults RemoveCustomer(CustomerDtoRemove customerDtoRemove);
    }
}
