using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMicroServices.Web.Models;
using ShopMicroServices.Web.Results;

namespace ShopMicroServices.Web.Controllers
{
    public class OrdersDetailsController : Controller
    {
        // GET: OrdersDetailsController

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public OrdersDetailsController()
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
                    var response = await httpClient.GetAsync("http://localhost:5037/api/OrderDetails/Get Orders Details\n");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersDetailsGetListResult = JsonConvert.DeserializeObject<OrdersDetailsGetListResult>(apiResponse);

                    if (ordersDetailsGetListResult != null && ordersDetailsGetListResult.success)
                    {
                        return View(ordersDetailsGetListResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersDetailsGetListResult?.message ?? "Error desconocido";
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


        // GET: OrdersDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5037/api/OrderDetails/Get DetailsById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersDetailsGetResult = JsonConvert.DeserializeObject<OrdersDetailsGetResult>(apiResponse);

                    if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                    {
                        return View(ordersDetailsGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
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


        // GET: OrdersDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrdersDetailsBaseModel ordersDetailsBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersDetailsBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5037/api/OrderDetails/Save Details\n",
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
                        return View(ordersDetailsBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersDetailsBaseModel);
                }
            }
        }


        // GET: OrdersDetailsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5037/api/OrderDetails/Get DetailsById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersDetailsGetResult = JsonConvert.DeserializeObject<OrdersDetailsGetResult>(apiResponse);

                    if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                    {
                        return View(ordersDetailsGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
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

        // POST: OrdersDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersDetailsBaseModel ordersDetailsBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersDetailsBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response =
                        await httpClient.PutAsync($"http://localhost:5037/api/OrderDetails/Update Details?id={id}",
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
                        return View(ordersDetailsBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersDetailsBaseModel);
                }
            }
        }


        // GET: OrdersDetailsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.GetAsync($"http://localhost:5037/api/OrderDetails/Get DetailsById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var ordersDetailsGetResult = JsonConvert.DeserializeObject<OrdersDetailsGetResult>(apiResponse);

                    if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                    {
                        return View(ordersDetailsGetResult.result);
                    }
                    else
                    {
                        ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
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


        // POST: OrdersDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response =
                        await httpClient.DeleteAsync($"http://localhost:5037/api/OrderDetails/Delete Detail?id={id}");
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
