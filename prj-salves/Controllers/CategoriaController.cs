using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}