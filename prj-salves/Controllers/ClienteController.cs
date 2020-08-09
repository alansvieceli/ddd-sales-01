using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}