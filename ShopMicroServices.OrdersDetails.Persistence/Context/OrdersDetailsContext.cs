
using Microsoft.EntityFrameworkCore;

namespace ShopMicroServices.OrdersDetails.Persistence.Context
{
    public class OrdersDetailsContext : DbContext
    {
        #region"Constructor"
        public OrdersDetailsContext(DbContextOptions<OrdersDetailsContext> options) : base(options)
        {    
        }
        #endregion

        #region"Sales OrdersDetails Dbset"
        public DbSet<OrdersDetails.Domain.Entities.OrdersDetails> Orders { get; set; }
        #endregion
    }
}