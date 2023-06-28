using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZuydWorld.Data;
using ZuydWorld.Models;

namespace ZuydWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly ZuydWorldContext _context;

        public UserController(ZuydWorldContext context)
        {
            _context = context;
        }
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
