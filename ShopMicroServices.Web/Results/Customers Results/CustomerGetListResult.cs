using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Results
{
    public class CustomerGetListResult : BaseResult
    {
        public List<CustomersBaseModel> result { get; set; }
    }
}