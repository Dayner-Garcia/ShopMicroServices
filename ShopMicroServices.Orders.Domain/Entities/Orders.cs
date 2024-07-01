

using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.Orders.Domain.Entities
{
    public class Orders : AuditEntity<int>
    {
        [Column("OrderId")]
        public override int Id { get; set; }
    }
}
