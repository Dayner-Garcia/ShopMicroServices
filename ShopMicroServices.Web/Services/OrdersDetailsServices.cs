using Newtonsoft.Json;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Services
{
    public class OrdersDetailsServices : IOrdersDetailsServices
    {
        private readonly HttpClient _httpClient;

        public OrdersDetailsServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<OrdersDetailsGetListResult> GetOrdersDetailsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5037/api/OrderDetails/Get Orders Details\n");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersDetailsGetListResult>(apiResponse);
        }

        public async Task<OrdersDetailsGetResult> GetOrderDetailByIdAsync(int id)
        {
            var response =
                await _httpClient.GetAsync($"http://localhost:5037/api/OrderDetails/Get DetailsById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersDetailsGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateOrderDetailAsync(OrdersDetailsBaseModel orderDetail)
        {
            var jsonContent = JsonConvert.SerializeObject(orderDetail);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5037/api/OrderDetails/Save Details\n",
                contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateOrderDetailAsync(int id, OrdersDetailsBaseModel orderDetail)
        {
            var jsonContent = JsonConvert.SerializeObject(orderDetail);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response =
                await _httpClient.PutAsync($"http://localhost:5037/api/OrderDetails/Update Details?id={id}",
                    contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteOrderDetailAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"http://localhost:5037/api/OrderDetails/Delete Detail?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}