using Microsoft.AspNetCore.Mvc;

namespace DulceSabor.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
