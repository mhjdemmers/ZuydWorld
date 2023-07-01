﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Login()
        {
            return View();
        }
    }
}
