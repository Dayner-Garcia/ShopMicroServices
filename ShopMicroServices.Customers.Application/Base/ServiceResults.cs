
namespace ShopMicroServices.Customers.Application.Base
{
    public class ServiceResults
    {
        public ServiceResults()
        {
            this.Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Result { get; set; }
    }
}