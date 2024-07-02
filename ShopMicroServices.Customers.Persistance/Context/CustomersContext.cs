
using Microsoft.EntityFrameworkCore;

namespace ShopMicroServices.Customers.Persistence.Context
{
    public class CustomersContext : DbContext
    {
        #region"Constructor"
        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }
        #endregion

        #region"SalesCustomers DbSt"
        public DbSet<Customers.Domain.Entities.Customers> Customers { get; set; }
        #endregion
    }
}