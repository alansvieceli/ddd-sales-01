using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}