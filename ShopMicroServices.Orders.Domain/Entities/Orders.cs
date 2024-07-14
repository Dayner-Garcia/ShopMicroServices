using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.Orders.Domain.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Orders : AuditEntity<int>
    {
        [Column("OrderId")]
        public override int Id { get; set; }
        public int? CustId { get; set; }
        public int EmpId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShipperId { set; get; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
