
using ShopMicroServices.Customers.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopMicroServices.Customers.Persistence.Repository
{
    // Implementar el objeto de datos de la architectura anterior.
    public class CustomersRepository : ICustomersRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Customers, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Customers> GetCustomersByNameCompany(string CompanyName)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Customers GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
