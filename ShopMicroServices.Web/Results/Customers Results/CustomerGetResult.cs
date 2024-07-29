using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class CustomerGetResult : BaseResult
    {
        public CustomersBaseModel result { get; set; }
    }
}