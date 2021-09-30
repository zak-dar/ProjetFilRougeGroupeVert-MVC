using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFilRouge.Models;
using ProjetFilRougeGroupeVert_MVC.Context;

namespace ProjetFilRougeGroupeVert_MVC.Controllers
{
    public class CanalsController : Controller
    {
        private readonly MyContext _context;

        public CanalsController(MyContext context)
        {
            _context = context;
        }

        // GET: Canals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Canal.ToListAsync());
        }

        // GET: Canals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canal = await _context.Canal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canal == null)
            {
                return NotFound();
            }

            return View(canal);
        }

        // GET: Canals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Theme,EstActif")] Canal canal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canal);
        }

        // GET: Canals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canal = await _context.Canal.FindAsync(id);
            if (canal == null)
            {
                return NotFound();
            }
            return View(canal);
        }

        // POST: Canals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Theme,EstActif")] Canal canal)
        {
            if (id != canal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanalExists(canal.Id))
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
            return View(canal);
        }

        // GET: Canals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canal = await _context.Canal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canal == null)
            {
                return NotFound();
            }

            return View(canal);
        }

        // POST: Canals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canal = await _context.Canal.FindAsync(id);
            _context.Canal.Remove(canal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanalExists(int id)
        {
            return _context.Canal.Any(e => e.Id == id);
        }
    }
}
