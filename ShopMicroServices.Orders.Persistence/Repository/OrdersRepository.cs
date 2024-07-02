
using ShopMicroServices.Orders.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopMicroServices.Orders.Persistence.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Orders, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Orders GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Orders entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Orders entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Orders entity)
        {
            throw new NotImplementedException();
        }
    }
}
