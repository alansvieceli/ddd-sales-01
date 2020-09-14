using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class Configuracao : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}