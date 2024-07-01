

using ShopMicroService.Common.Data.Repository;

namespace ShopMicroServices.Customers.Domain.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Domain.Entities.Customers,int>
    {
        List<Customers.Domain.Entities.Customers> GetCustomersByNameCompany(string CompanyName);
    }
}
