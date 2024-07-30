using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.IServices
{
    public interface ICustomersServices
    {
        Task<CustomerGetListResult> GetCustomersAsync();
        Task<CustomerGetResult> GetCustomerByIdAsync(int id);
        Task<BaseResult> CreateCustomerAsync(CustomersBaseModel customer);
        Task<BaseResult> UpdateCustomerAsync(int id, CustomersBaseModel customer);
        Task<BaseResult> DeleteCustomerAsync(int id);
    }
}