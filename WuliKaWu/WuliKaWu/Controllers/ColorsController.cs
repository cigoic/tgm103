using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
<<<<<<< HEAD
<<<<<<< HEAD
using WuliKaWu.Models.ApiModel;
=======
using WuliKaWu.Models;
>>>>>>> [新增]color controller以及color新增及編輯的model
=======
using WuliKaWu.Models.ApiModel;
>>>>>>> [修改]CartApi及WishListapi的Model

namespace WuliKaWu.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ShopContext _context;

        public ColorsController(ShopContext context)
        {
            _context = context;
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colors.ToListAsync());
        }

        // GET: Colors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }

            var color = await _context.Colors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: Colors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColorCreateModel color)
        {
            _context.Colors.Add(new Color { Type = color.Type });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
<<<<<<< HEAD
<<<<<<< HEAD
            //return View(color);
=======
            return View(color);
>>>>>>> [新增]color controller以及color新增及編輯的model
=======
            //return View(color);
>>>>>>> [修改]color controller及 它的 index樣式調整
        }

        // GET: Colors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }

            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ColorEditModel color)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Colors.FirstOrDefault(x => x.Id == id);
                    if (data != null)
                    {
                        data.Type = color.Type;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }

            var color = await _context.Colors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colors == null)
            {
                return Problem("Entity set 'ShopContext.Colors'  is null.");
            }
            var color = await _context.Colors.FindAsync(id);
            if (color != null)
            {
                _context.Colors.Remove(color);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorExists(int id)
        {
            return _context.Colors.Any(e => e.Id == id);
        }
    }
}