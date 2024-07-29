using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopMicroServices.Web.Controllers
{
    public class OrdersDetailsController : Controller
    {
        // GET: OrdersDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdersDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
