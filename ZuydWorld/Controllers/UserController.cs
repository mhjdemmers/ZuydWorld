using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZuydWorld.Data;
using ZuydWorld.Models;
using System.Xml.Linq;

namespace ZuydWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly ZuydWorldContext _context;

        public UserController(ZuydWorldContext context)
        {
            _context = context;
        }
        // GET: User
        public async Task<IActionResult> Index()
        {
            return _context.Userss != null ?
                        View(await _context.Userss.ToListAsync()) :
                        Problem("Entity set 'ZuydWorldContext.User'  is null.");
        }
        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userss == null)
            {
                return NotFound();
            }

            var user = await _context.Userss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userss == null)
            {
                return NotFound();
            }

            var user = await _context.Userss.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameName")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userss == null)
            {
                return NotFound();
            }

            var user = await _context.Userss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Registration()
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userss == null)
            {
                return Problem("Entity set 'ZuydWorldContext.Game'  is null.");
            }
            var user = await _context.Userss.FindAsync(id);
            if (user != null)
            {
                _context.Userss.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.Userss?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public IActionResult Login()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Login(string gebruikersnaamofemail, string wachtwoord, User user, bool myCheckbox)
        {
            foreach (var User in _context.Userss)
            {
                if (User.Email == gebruikersnaamofemail ^ user.Username == gebruikersnaamofemail && User.Password == wachtwoord)
                {
                    user.Email = gebruikersnaamofemail;
                    user.Password = wachtwoord;
                    user.Id = User.Id;
                    user.Username = User.Username;
                    user.Moderator = User.Moderator;
                    user.Banned = user.Banned;
                    user.Likes = user.Likes;
                    user.RegistrationDate = user.RegistrationDate;
                    LoggedInUser.user = user;
                    return RedirectToAction("Profile", "User");
                }
                
            }
            TempData["Error"] = "Error, gebruikersnaam of wachtwoord is fout";
            return View("Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            @ViewBag.Username = LoggedInUser.user.Username;
            @ViewBag.Password = LoggedInUser.user.Password;
            @ViewBag.Email = LoggedInUser.user.Email;
            return View();
        }

        [HttpPost]
        public IActionResult Profile(User user, string Password, string Username, string Email)
        {
            user.Username = Username;
            user.Password = Password;
            user.Email = Email;
            user.Id = LoggedInUser.user.Id;
            user.RegistrationDate = LoggedInUser.user.RegistrationDate;
            user.Likes = LoggedInUser.user.Likes;
            user.Banned = LoggedInUser.user.Banned;
            user.Moderator = LoggedInUser.user.Moderator;
            LoggedInUser.user = user;
            _context.Update(user);
            _context.SaveChanges();
            return View();
        }

        public IActionResult Friends()
        {
            return View();
        }
    }
}
