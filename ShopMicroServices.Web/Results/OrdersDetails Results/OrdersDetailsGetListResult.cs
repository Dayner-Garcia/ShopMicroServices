using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class OrdersDetailsGetListResult : BaseResult
    {
        public List<OrdersDetailsBaseModel> result { get; set; }
    }
}