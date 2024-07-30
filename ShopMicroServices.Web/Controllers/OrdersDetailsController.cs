using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Controllers
{
    public class OrdersDetailsController : Controller
    {
        private readonly IOrdersDetailsServices _ordersDetailsService;

        public OrdersDetailsController(IOrdersDetailsServices ordersDetailsService)
        {
            _ordersDetailsService = ordersDetailsService;
        }

        // GET: OrdersDetailsController
        public async Task<ActionResult> Index()
        {
            try
            {
                var ordersDetailsGetListResult = await _ordersDetailsService.GetOrdersDetailsAsync();
                if (ordersDetailsGetListResult != null && ordersDetailsGetListResult.success)
                {
                    return View(ordersDetailsGetListResult.result);
                }

                ViewBag.Message = ordersDetailsGetListResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // GET: OrdersDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var ordersDetailsGetResult = await _ordersDetailsService.GetOrderDetailByIdAsync(id);
                if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                {
                    return View(ordersDetailsGetResult.result);
                }

                ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
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
            try
            {
                var result = await _ordersDetailsService.CreateOrderDetailAsync(ordersDetailsBaseModel);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = result?.message ?? "Error desconocido";
                return View(ordersDetailsBaseModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View(ordersDetailsBaseModel);
            }
        }

        // GET: OrdersDetailsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var ordersDetailsGetResult = await _ordersDetailsService.GetOrderDetailByIdAsync(id);
                if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                {
                    return View(ordersDetailsGetResult.result);
                }

                ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // POST: OrdersDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersDetailsBaseModel ordersDetailsBaseModel)
        {
            try
            {
                var result = await _ordersDetailsService.UpdateOrderDetailAsync(id, ordersDetailsBaseModel);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = result?.message ?? "Error desconocido";
                return View(ordersDetailsBaseModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View(ordersDetailsBaseModel);
            }
        }

        // GET: OrdersDetailsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var ordersDetailsGetResult = await _ordersDetailsService.GetOrderDetailByIdAsync(id);
                if (ordersDetailsGetResult != null && ordersDetailsGetResult.success)
                {
                    return View(ordersDetailsGetResult.result);
                }

                ViewBag.Message = ordersDetailsGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // POST: OrdersDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _ordersDetailsService.DeleteOrderDetailAsync(id);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = result?.message ?? "Error desconocido";
                return RedirectToAction(nameof(Delete), new { id });
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}