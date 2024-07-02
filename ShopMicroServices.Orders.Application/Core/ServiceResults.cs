
namespace ShopMicroServices.Orders.Application.Core
{
    public class ServiceResults
    {
        public ServiceResults()
        {
            Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Result { get; set; }
    }
}