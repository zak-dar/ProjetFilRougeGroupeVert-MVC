using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetString("userId", "1");

            //on récupere l'utilisateur connecté et on récupere son role
            Utilisateur user = _context.Utilisateur.Where(u => u.Id.ToString() == HttpContext.Session.GetString("userId")).First();
            ViewData["RoleConnected"] = user.Role.ToString();
            ViewData["userId"] = HttpContext.Session.GetString("userId");

            var myContext = _context.Publication.Where(p => p.Validite == true).Include(p => p.Auteur).Include(p => p.Canal);
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

            ViewData["userId"] = HttpContext.Session.GetString("userId");
            return View(publication);
        }










        // GET: Publications/Create
        public IActionResult Create()
        {
            var canaux = _context.Canal.ToList();

            ViewData["Canaux"] = new SelectList(_context.Canal, "Id", "Nom");
            return View();
        }



        // POST: Publications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Titre,Contenu,CanalId")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                publication.Auteur = _context.Utilisateur.Where(u => u.Id.ToString() == HttpContext.Session.GetString("userId")).First();
                if (publication.Auteur.Role.ToString() == "ADMIN" )
                {
                    publication.Validite = true;
                }
                else
                {
                    publication.Validite = false;
                }
                _context.Add(publication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Canaux"] = new SelectList(_context.Canal,"Id", "Nom");
            return RedirectToAction("Index");
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
            ViewData["Canaux"] = new SelectList(_context.Canal, "Id", "Nom");
            return View(publication);
        }



        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Titre,Contenu,AuteurId,CanalId")] Publication publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    publication.Auteur = _context.Utilisateur.Where(u => u.Id.ToString() == HttpContext.Session.GetString("userId")).First();
                    if (publication.Auteur.Role.ToString() == "ADMIN")
                    {
                        publication.Validite = true;
                    }
                    else
                    {
                        publication.Validite = false;
                    }
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
            return RedirectToAction("Index");
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
