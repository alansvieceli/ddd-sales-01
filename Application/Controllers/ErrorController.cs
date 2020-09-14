using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class ErrorController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}