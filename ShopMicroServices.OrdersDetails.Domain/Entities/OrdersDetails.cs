

using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.OrdersDetails.Domain.Entities
{
    public class OrdersDetails : AuditEntity<int>
    {
        [Column("OrderId")]
        public override int Id { get; set; }
    }
}
