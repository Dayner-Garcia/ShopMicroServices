
namespace ShopMicroServices.Customers.Persistence.Exceptions
{
    public class CustomersExeptions : Exception
    {
        public CustomersExeptions(string message) : base(message)
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
