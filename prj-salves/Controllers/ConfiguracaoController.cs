using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class Configuracao : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}