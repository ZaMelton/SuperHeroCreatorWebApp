using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Data;
using SuperHeroProject.Models;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperHeroes
        public ActionResult Index()
        {
            var heroes = _context.SuperHeroes;
            return View(heroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHero = _context.SuperHeroes.FirstOrDefault(a => a.Id == id);
            return View(superHero);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            superHero.Name = "Super Fluff";
            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.SuperHeroes.Add(superHero);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(superHero);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superHero = _context.SuperHeroes.FirstOrDefault(a => a.Id == id);
            return View(superHero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHeroFromForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SuperHero superHeroFromDb = _context.SuperHeroes.FirstOrDefault(a => a.Id == id);
                    superHeroFromDb.Name = superHeroFromForm.Name;
                    superHeroFromDb.AlterEgo = superHeroFromForm.AlterEgo;
                    superHeroFromDb.PrimarySuperHeroAbility = superHeroFromForm.PrimarySuperHeroAbility;
                    superHeroFromDb.SecondarySuperHeroAbility = superHeroFromForm.SecondarySuperHeroAbility;
                    superHeroFromDb.CatchPhrase = superHeroFromForm.CatchPhrase;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(superHeroFromForm);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}