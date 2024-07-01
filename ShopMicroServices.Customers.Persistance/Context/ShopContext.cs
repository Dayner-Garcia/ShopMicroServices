
using Microsoft.EntityFrameworkCore;

namespace ShopMicroServices.Customers.Persistence.Context
{
    public class ShopContext : DbContext
    {
        #region"Constructor"
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        #endregion

        #region"SalesCustomers DbSt"
        public DbSet<Domain.Entities.Customers> Customers { get; set; }
        #endregion
    }
}