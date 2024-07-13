
using ShopMicroServices.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMicroServices.Customers.Domain.Entities
{
    [Table("Customers", Schema = "Sales")]
    public class Customers : AuditEntity<int>
    {
        [Column("CustId")]
        public override int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { set; get; }
        public string ContactTitle { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string City { set; get; }
        public string? Region { set; get; }
        public string? PostalCode { set; get; }
        public string Country { set; get; }
        public string Phone { set; get; }
        public string? Fax { set; get; }
    }
}