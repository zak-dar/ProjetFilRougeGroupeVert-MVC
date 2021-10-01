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
    public class UtilisateursController : Controller
    {
        private readonly MyContext _context;

        public UtilisateursController(MyContext context)
        {
            _context = context;
        }

        // GET: Utilisateurs
        public IActionResult Index()
        {
            return View( _context.Utilisateur.Where(u => u.Id.ToString() == HttpContext.Session.GetString("userId")).First());
        }











        // GET: Utilisateurs/Create
        public IActionResult Create()
        {
            ViewData["RoleConnected"] = "ADMIN";
            ViewData["Role"] = new SelectList(Enum.GetValues(typeof(Role)),"UTILISATEUR");
            return View();
        }

        // POST: Utilisateurs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Valide,Id,PersonneType,Nom,Prenom,Email,MotDePasse,DateNaissance,Role")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }







        // GET: Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["Role"] = new SelectList(Enum.GetValues(typeof(Role)));
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Valide,Id,PersonneType,Nom,Prenom,Email,MotDePasse,DateNaissance,Role")] Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.Id))
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
            return View(utilisateur);
        }










        // POST: Utilisateurs/Delete/5
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateur.Any(e => e.Id == id);
        }
    }
}
