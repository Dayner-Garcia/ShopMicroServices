using Newtonsoft.Json;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly HttpClient _httpClient;

        public OrdersServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<OrdersGetListResult> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5287/api/Orders/Get Orders\n");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersGetListResult>(apiResponse);
        }

        public async Task<OrdersGetResult> GetOrderByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5287/api/Orders/GetOrdersById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateOrderAsync(OrdersBaseModel order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5287/api/Orders/Save Orders\n", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateOrderAsync(int id, OrdersBaseModel order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5287/api/Orders/Update Orders?id={id}",
                contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5287/api/Orders/Delete Order?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}