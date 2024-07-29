namespace ShopMicroServices.Web.Models
{
    public class OrdersDetailsBaseModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public short qty { get; set; }
        public decimal discount { get; set; }
    }
}