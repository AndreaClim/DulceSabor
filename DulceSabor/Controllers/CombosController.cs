using Microsoft.AspNetCore.Mvc;

namespace DulceSabor.Controllers
{
    public class CombosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
