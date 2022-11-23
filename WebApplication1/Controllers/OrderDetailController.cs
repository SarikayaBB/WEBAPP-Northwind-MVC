using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly NorthwindContext _db;
        public OrderDetailController(NorthwindContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            List<OrderDetailsExtended> list = _db.OrderDetailsExtendeds.ToList<OrderDetailsExtended>();

            return View(list);
        }

        public IActionResult GetAllJson()
        {
            List<OrderDetailsExtended> list = _db.OrderDetailsExtendeds.ToList<OrderDetailsExtended>();
                

            return Json(new {data=list});
        }


    }
}
