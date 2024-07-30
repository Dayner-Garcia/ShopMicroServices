using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersServices _ordersService;

        public OrdersController(IOrdersServices ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: OrdersController
        public async Task<ActionResult> Index()
        {
            try
            {
                var ordersGetListResult = await _ordersService.GetOrdersAsync();
                if (ordersGetListResult != null && ordersGetListResult.success)
                {
                    return View(ordersGetListResult.result);
                }

                ViewBag.Message = ordersGetListResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // GET: OrdersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
                if (ordersGetResult != null && ordersGetResult.success)
                {
                    return View(ordersGetResult.result);
                }

                ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
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
            try
            {
                var result = await _ordersService.CreateOrderAsync(ordersBaseModel);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = result?.message ?? "Error desconocido";
                return View(ordersBaseModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View(ordersBaseModel);
            }
        }

        // GET: OrdersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
                if (ordersGetResult != null && ordersGetResult.success)
                {
                    return View(ordersGetResult.result);
                }

                ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersBaseModel ordersBaseModel)
        {
            try
            {
                var result = await _ordersService.UpdateOrderAsync(id, ordersBaseModel);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = result?.message ?? "Error desconocido";
                return View(ordersBaseModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View(ordersBaseModel);
            }
        }

        // GET: OrdersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
                if (ordersGetResult != null && ordersGetResult.success)
                {
                    return View(ordersGetResult.result);
                }

                ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error en la solicitud: {ex.Message}";
                return View();
            }
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _ordersService.DeleteOrderAsync(id);
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