using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class OrdersDetailsGetResult : BaseResult
    {
        public OrdersDetailsBaseModel result { get; set; }
    }
}