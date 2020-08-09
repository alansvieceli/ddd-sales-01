using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}