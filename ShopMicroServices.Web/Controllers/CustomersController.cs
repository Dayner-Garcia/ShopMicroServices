using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Controllers
{
    public class CustomersController : Controller
    {
        // GET: CustomersController

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public CustomersController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) =>
            {
                return true;
            };
        }

        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync("http://localhost:4970/api/Customer/GetCustomers\n");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var customerGetResult = JsonConvert.DeserializeObject<CustomerGetListResult>(apiResponse);

                    if (customerGetResult != null && customerGetResult.success)
                    {
                        return View(customerGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View();
                }
            }
        }


        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    // Usa el parámetro id en la URL de la solicitud
                    var response =
                        await httpClient.GetAsync($"http://localhost:4970/api/Customer/GetCustomerById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var customerGetResult = JsonConvert.DeserializeObject<CustomerGetResult>(apiResponse);

                    if (customerGetResult != null && customerGetResult.success)
                    {
                        return View(customerGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View();
                }
            }
        }


        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomersBaseModel customerBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(customerBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:4970/api/Customer/SaveCustomers\n",
                        contentString);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return View(customerBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(customerBaseModel);
                }
            }
        }


        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:4970/api/Customer/GetCustomerById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var customerGetResult = JsonConvert.DeserializeObject<CustomerGetResult>(apiResponse);

                    if (customerGetResult != null && customerGetResult.success)
                    {
                        return View(customerGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View();
                }
            }
        }

// POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomersBaseModel customerBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(customerBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response =
                        await httpClient.PutAsync($"http://localhost:4970/api/Customer/UpdateCustomer?id={id}",
                            contentString);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return View(customerBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(customerBaseModel);
                }
            }
        }


        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:4970/api/Customer/GetCustomerById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var customerGetResult = JsonConvert.DeserializeObject<CustomerGetResult>(apiResponse);

                    if (customerGetResult != null && customerGetResult.success)
                    {
                        return View(customerGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View();
                }
            }
        }


        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.DeleteAsync($"http://localhost:4970/api/Customer/DeleteCustomer?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return RedirectToAction(nameof(Delete), new { id });
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
        }
    }
}