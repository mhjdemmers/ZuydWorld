using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZuydWorld.Models;

namespace ZuydWorld.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Registration()
        {
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
