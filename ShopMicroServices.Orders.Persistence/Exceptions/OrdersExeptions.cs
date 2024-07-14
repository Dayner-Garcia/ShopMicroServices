
namespace ShopMicroServices.Orders.Persistence.Exceptions
{
    public class OrdersExeptions : Exception
    {
        public OrdersExeptions(string message) : base(message)
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