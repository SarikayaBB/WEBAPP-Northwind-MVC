using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        NorthwindContext eldeOlan;

        public HomeController(NorthwindContext goklerdenGelen)
        {
            eldeOlan = goklerdenGelen;
        }



        //bu metotların her birine ACTION deniyor.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

      

     
    }
}