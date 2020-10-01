using Microsoft.AspNetCore.Mvc;

namespace DDD.Sales.Application.Controllers
{
    public class ErrorController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}