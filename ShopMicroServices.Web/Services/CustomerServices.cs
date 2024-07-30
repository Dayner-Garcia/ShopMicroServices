using Newtonsoft.Json;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Services
{
    public class CustomerServices : ICustomersServices
    {
        private readonly HttpClient _httpClient;

        public CustomerServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomerGetListResult> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:4970/api/Customer/GetCustomers\n");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerGetListResult>(apiResponse);
        }


        public async Task<CustomerGetResult> GetCustomerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:4970/api/Customer/GetCustomerById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateCustomerAsync(CustomersBaseModel customer)
        {
            var jsonContent = JsonConvert.SerializeObject(customer);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response =
                await _httpClient.PostAsync("http://localhost:4970/api/Customer/SaveCustomers\n", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateCustomerAsync(int id, CustomersBaseModel customer)
        {
            var jsonContent = JsonConvert.SerializeObject(customer);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:4970/api/Customer/UpdateCustomer?id={id}",
                contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:4970/api/Customer/DeleteCustomer?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}