using Microsoft.AspNetCore.Mvc;

namespace prj_sales.Controllers
{
    public class Relatorio : Controller
    {
        public IActionResult Grafico()
        {
            return View();
        }
    }
}