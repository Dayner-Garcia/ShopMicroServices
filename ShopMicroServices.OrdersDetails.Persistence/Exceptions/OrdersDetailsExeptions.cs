
namespace ShopMicroServices.OrdersDetails.Persistence.Exceptions
{
    public class OrdersDetailsExeptions : Exception
    {
        public OrdersDetailsExeptions(string message) : base(message)
        {
            
        }
        private void LogError(string message)
        {
        }

        private void SendError(string message)
        {
        }
    }
}