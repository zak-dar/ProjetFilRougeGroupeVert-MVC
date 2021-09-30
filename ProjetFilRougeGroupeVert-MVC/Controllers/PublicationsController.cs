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
    public class PublicationsController : Controller
    {
        private readonly MyContext _context;

        public PublicationsController(MyContext context)
        {
            _context = context;
        }

        // GET: Publications
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Publication.Include(p => p.Auteur).Include(p => p.Canal);
            return View(await myContext.ToListAsync());
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .Include(p => p.Auteur)
                .Include(p => p.Canal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            ViewData["AuteurId"] = new SelectList(_context.Set<Utilisateur>(), "Id", "PersonneType");
            ViewData["CanalId"] = new SelectList(_context.Set<Canal>(), "Id", "Id");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Titre,Contenu,Validite,AuteurId,CanalId")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuteurId"] = new SelectList(_context.Set<Utilisateur>(), "Id", "PersonneType", publication.AuteurId);
            ViewData["CanalId"] = new SelectList(_context.Set<Canal>(), "Id", "Id", publication.CanalId);
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            ViewData["AuteurId"] = new SelectList(_context.Set<Utilisateur>(), "Id", "PersonneType", publication.AuteurId);
            ViewData["CanalId"] = new SelectList(_context.Set<Canal>(), "Id", "Id", publication.CanalId);
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Titre,Contenu,Validite,AuteurId,CanalId")] Publication publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.Id))
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
            ViewData["AuteurId"] = new SelectList(_context.Set<Utilisateur>(), "Id", "PersonneType", publication.AuteurId);
            ViewData["CanalId"] = new SelectList(_context.Set<Canal>(), "Id", "Id", publication.CanalId);
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .Include(p => p.Auteur)
                .Include(p => p.Canal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publication.FindAsync(id);
            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publication.Any(e => e.Id == id);
        }
    }
}
