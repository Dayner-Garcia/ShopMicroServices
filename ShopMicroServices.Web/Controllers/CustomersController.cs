using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.Web.IServices;
using ShopMicroServices.Web.Models;

namespace ShopMicroServices.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersServices _customerService;

        public CustomersController(ICustomersServices customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            var customerGetListResult = await _customerService.GetCustomersAsync();
            if (customerGetListResult != null && customerGetListResult.success)
            {
                return View(customerGetListResult.result);
            }

            ViewBag.Message = customerGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var customerGetResult = await _customerService.GetCustomerByIdAsync(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }

            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomersBaseModel customer)
        {
            var result = await _customerService.CreateCustomerAsync(customer);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(customer);
        }


        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customerGetResult = await _customerService.GetCustomerByIdAsync(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }

            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomersBaseModel customer)
        {
            var result = await _customerService.UpdateCustomerAsync(id, customer);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(customer);
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var customerGetResult = await _customerService.GetCustomerByIdAsync(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }

            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}