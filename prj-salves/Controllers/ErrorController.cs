using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class ErrorController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}