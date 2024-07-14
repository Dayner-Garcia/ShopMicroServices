using Microsoft.EntityFrameworkCore;

namespace ShopMicroServices.Orders.Persistence.Context
{
    public class OrdersContext : DbContext
    {
        #region"Constructor"
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {   
        }
        #endregion

        #region"SalesOrders DbSt"
        public DbSet<Orders.Domain.Entities.Orders> SalesOrders { get; set; }
        #endregion
    }
}