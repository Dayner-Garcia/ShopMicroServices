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

        #region"SalesOrdersDetails Dbset"
        public DbSet<OrdersDetails.Domain.Entities.OrdersDetails> SalesOrdersDetails { get; set; }
        #endregion
    }
}