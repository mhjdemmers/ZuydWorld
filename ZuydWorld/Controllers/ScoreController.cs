using Microsoft.AspNetCore.Mvc;

namespace ZuydWorld.Controllers
{
    public class ScoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Leaderboard()
        {
            return View();
        }
    }
}
