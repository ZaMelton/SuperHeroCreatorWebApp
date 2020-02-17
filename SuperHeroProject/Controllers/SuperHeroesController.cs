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

        public ActionResult Randomize()
        {
            Random random = new Random();
            List<string> adjectives = new List<string> { "Super", "Ultimate", "Crazy", "Evil", "Fluffy" };
            List<string> titles = new List<string> { "Man", "Foot", "Woman", "Panda", "Cat" };
            List<string> alterEgos = new List<string> { "Bill Guy", "Kyle 'Drywall Smasher' Evans", "John Johnson", "Kevin Kevorkian", "Darren Sharper" };
            List<string> primaries = new List<string> { "Eating", "X-Ray vision", "Super strength", "Dancing", "Growing nails", "Laser Eyes" };
            List<string> secondaries = new List<string> { "Speaking fish", "Riding a bike with one hand", "Crying", "Sleeping", "Super speed" };
            SuperHero hero = new SuperHero
            {
                Name = adjectives[random.Next(0, adjectives.Count)] + " " + titles[random.Next(0, titles.Count)],
                AlterEgo = alterEgos[random.Next(0, alterEgos.Count)],
                PrimarySuperHeroAbility = primaries[random.Next(0, primaries.Count)],
                SecondarySuperHeroAbility = secondaries[random.Next(0, secondaries.Count)]
            };
            return View("Create", hero);
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
            var superHeroToDelete = _context.SuperHeroes.FirstOrDefault(s => s.Id == id);
            return View(superHeroToDelete);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var superHeroToDelete = _context.SuperHeroes.FirstOrDefault(s => s.Id == id);
                _context.SuperHeroes.Remove(superHeroToDelete);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}