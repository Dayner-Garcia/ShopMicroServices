using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class OrdersGetListResult : BaseResult
    {
        public List<OrdersBaseModel> result { get; set; }
    }
}