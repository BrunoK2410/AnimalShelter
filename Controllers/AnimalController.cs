using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Data;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.PowerBI.Api;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animal
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            ViewBag.animals = _context.Animals.Where(Animal=>Animal.Type==1).ToList().ToPagedList(pageNumber,16);
            return View(ViewBag.animals);
            
        }

        public IActionResult Cats(int? page)
        {
            var pageNumber = page ?? 1;
            ViewBag.animals = _context.Animals.Where(Animal => Animal.Type == 0).ToList().ToPagedList(pageNumber, 16);
            return View(ViewBag.animals);
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Breed,Sex,Birthday,Microchip,Image,Description")] Animal animal)
        {
            if (ModelState.IsValid)
                if (_context.Animals.Any(Animal => Animal.Microchip == animal.Microchip))
                {
                    ModelState.AddModelError("", "That Microchip already exists");
                }
            else
            {
 

                _context.Add(animal);
                await _context.SaveChangesAsync();
                if (animal.Type == 1)
                {
                   return RedirectToAction(nameof(Index));
                }
                else
                {
                   return RedirectToAction(nameof(Cats));
                }
            }
            
            return View(animal);
        }



 

        [Authorize(Roles ="Admin")]
        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Breed,Sex,Birthday,Microchip,Image,Description")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (animal.Type == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Cats));
                }
            }
            
            return View(animal);
        }

        // GET: Animal/Delete/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            if (animal.Type == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Cats));
            }
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
