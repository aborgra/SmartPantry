using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPantry.Data;
using SmartPantry.Models;

namespace SmartPantry.Controllers
{
    public class GroceryListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroceryListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: GroceryList
        public async Task<ActionResult> Index(string searchString)
        {
            var user = await GetUserAsync();
            var foodItems = await _context.GroceryListFoods
                .Include(glf => glf.Food)
                .Where(glf => glf.Food.PantryId == user.PantryId)
                .ToListAsync();

            if (searchString != null)
            {
                foodItems = await _context.GroceryListFoods
                      .Where(gl => gl.Food.Name.Contains(searchString) && gl.Food.PantryId == user.PantryId || gl.Food.Category.Name.Contains(searchString) && gl.Food.PantryId == user.PantryId)
                      .Include(gl => gl.Food.Category)
                       .ToListAsync();
                return View(foodItems);
            }

            return View(foodItems);
        }
    

        // GET: GroceryList/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: GroceryList/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: GroceryList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroceryList/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: GroceryList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroceryList/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: GroceryList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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

        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}