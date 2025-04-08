using Microsoft.AspNetCore.Mvc;

namespace DulceSabor.Controllers
{
    public class FacturaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
