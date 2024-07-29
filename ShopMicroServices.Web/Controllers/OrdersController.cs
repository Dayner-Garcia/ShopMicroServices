using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: OrdersController

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public OrdersController()
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
                    var response = await httpClient.GetAsync("http://localhost:5287/api/Orders/Get Orders\n");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersGetListResult = JsonConvert.DeserializeObject<OrdersGetListResult>(apiResponse);

                    if (ordersGetListResult != null && ordersGetListResult.success)
                    {
                        return View(ordersGetListResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersGetListResult?.message ?? "Error desconocido";
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


        // GET: OrdersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5287/api/Orders/GetOrdersById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                    if (ordersGetResult != null && ordersGetResult.success)
                    {
                        return View(ordersGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
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


        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrdersBaseModel ordersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5287/api/Orders/Save Orders\n",
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
                        return View(ordersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersBaseModel);
                }
            }
        }


        // GET: OrdersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5287/api/Orders/GetOrdersById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                    if (ordersGetResult != null && ordersGetResult.success)
                    {
                        return View(ordersGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
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

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersBaseModel ordersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response =
                        await httpClient.PutAsync($"http://localhost:5287/api/Orders/Update Orders?id={id}",
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
                        return View(ordersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersBaseModel);
                }
            }
        }


        // GET: OrdersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5287/api/Orders/GetOrdersById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                    if (ordersGetResult != null && ordersGetResult.success)
                    {
                        return View(ordersGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
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


        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.DeleteAsync($"http://localhost:5287/api/Orders/Delete Order?id={id}");
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
