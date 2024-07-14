

using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.OrdersDetails.Domain.Entities
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrdersDetails : AuditEntity<int>
    {
        [Column("OrderId")]
        public override int Id { get; set; }
        public int ProductId { set; get; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
