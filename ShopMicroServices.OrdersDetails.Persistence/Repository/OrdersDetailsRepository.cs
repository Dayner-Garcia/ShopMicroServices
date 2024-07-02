
using ShopMicroServices.OrdersDetails.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopMicroServices.OrdersDetails.Persistence.Repository
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.OrdersDetails, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.OrdersDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.OrdersDetails GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.OrdersDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.OrdersDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.OrdersDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
