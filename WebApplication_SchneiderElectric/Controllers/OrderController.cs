using Microsoft.AspNetCore.Mvc;
using WebApplication_SchneiderElectric.Models;

namespace WebApplication_SchneiderElectric.Controllers
{
    public class OrderController : Controller
    {
        OrderDataAccessLayer orderDataAccessLayer = null;

        public OrderController()
        {
            orderDataAccessLayer = new OrderDataAccessLayer();
        }

        public ActionResult Index()
        {
            IEnumerable<SalesOrderViewModel> orders = orderDataAccessLayer.GetAllOrder();
            return View(orders);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            SalesOrderCreateModel model = new SalesOrderCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Order/Create
        public ActionResult Create(SalesOrderCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.OrderStatus == null)
                    {
                        ModelState.AddModelError("", "Please fill in all the fields.");
                        return View("Create", model);
                    }

                    orderDataAccessLayer.AddOrder(model.ProductID, model.OrderQuantity, model.OrderStatus, model.Timestamp);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Model is not valid. See the field-level error messages for more details.");
                    return View("Create", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View("Create", model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrder(string SalesOrderID)
        {
            orderDataAccessLayer.DeleteOrder(SalesOrderID);
            return RedirectToAction("Index");
        }
    }
}
