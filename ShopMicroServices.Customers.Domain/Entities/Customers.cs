

using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.Customers.Domain.Entities
{
    public class Customers : AuditEntity<int>
    {
        [Column("CustId")]
        public override int Id { get; set; }
    }
}
