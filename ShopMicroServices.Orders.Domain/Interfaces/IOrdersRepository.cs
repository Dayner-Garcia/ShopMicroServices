using ShopMicroService.Common.Data.Repository;

namespace ShopMicroServices.Orders.Domain.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Domain.Entities.Orders, int>
    {

    }
}
