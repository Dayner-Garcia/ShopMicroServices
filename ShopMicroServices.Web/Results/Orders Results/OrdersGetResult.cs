using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class OrdersGetResult : BaseResult
    {
        public OrdersBaseModel result { get; set; }
    }
}