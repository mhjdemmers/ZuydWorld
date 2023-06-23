using Microsoft.AspNetCore.Mvc;

namespace ZuydWorld.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Default()
        {
            return View();
        }
    }
}
