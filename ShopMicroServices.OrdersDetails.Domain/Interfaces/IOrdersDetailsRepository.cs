

using ShopMicroService.Common.Data.Repository;

namespace ShopMicroServices.OrdersDetails.Domain.Interfaces
{
    public interface IOrdersDetailsRepository : IBaseRepository<Domain.Entities.OrdersDetails, int>
    {
    }
}
