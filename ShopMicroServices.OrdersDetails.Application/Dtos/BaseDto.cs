namespace ShopMicroServices.OrdersDetails.Application.Dtos
{
    public abstract class BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { set; get; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
        public bool NewDetail { get; set; }
    }
}