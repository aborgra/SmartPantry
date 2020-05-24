using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartPantry.Data;
using SmartPantry.Models;
using SmartPantry.Models.ViewModels;

namespace SmartPantry.Controllers
{
    public class PantryController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PantryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pantry
        public async Task<ActionResult> Index(string searchString)
        {
            var user = await GetUserAsync();
            var foodItems = await _context.Foods
                .Include(f => f.Pantry)
                .Include(c => c.Category)
                .Include (u => u.QuantityUnit)
                .Where(f => f.PantryId == user.PantryId && f.Quantity > 0)
                .OrderBy(f => f.CategoryId)
                .ToListAsync();


            if (searchString != null)
            {
                foodItems = await _context.Foods
                      .Where(f => f.Name.Contains(searchString) && f.PantryId == user.PantryId || f.Category.Name.Contains(searchString) && f.PantryId == user.PantryId)
                      .Include(f => f.Category)
                      .Include(u => u.QuantityUnit)
                      .OrderBy(f => f.CategoryId)
                      .ToListAsync();
                return View(foodItems);
            }

            return View(foodItems);
        }

        // GET: Pantry/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var viewModel = new FoodItemFormViewModel();
            var food = await _context.Foods.Include(f => f.Category).Include(u => u.QuantityUnit)
                .FirstOrDefaultAsync(f => f.Id == id);
            var user = await GetUserAsync();
            viewModel.FoodId = food.Id;
            viewModel.Category = food.Category;
            viewModel.QuantityUnit = food.QuantityUnit;
            viewModel.FoodItemName = food.Name;
            viewModel.PantryId = food.PantryId.Value;
            viewModel.Quantity = food.Quantity;
            viewModel.Threshold = food.Threshold;
            return View(viewModel);
        }

        // GET: Pantry/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new FoodItemFormViewModel();

            var categories = await _context.Categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToListAsync();

            var quantityUnits = await _context.QuantityUnits.Select(qu => new SelectListItem()
            {
                Text = qu.Name,
                Value = qu.Id.ToString()
            }).ToListAsync();

            viewModel.CategoryOptions = categories;
            viewModel.QuantityUnitOptions = quantityUnits;

            return View(viewModel);
        }

        // POST: Pantry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FoodItemFormViewModel foodItem)
        {
            try
            {
                var user = await GetUserAsync();
                var pantryId = user.PantryId;

                var food = new Food()
                {
                    PantryId = pantryId,
                    Name = foodItem.FoodItemName,
                    CategoryId = foodItem.CategoryId,
                    Quantity = foodItem.Quantity,
                    QuantityUnitId = foodItem.QuantityUnitId,
                    Threshold = foodItem.Threshold,
                    IsThreshold = foodItem.IsThreshold
                };
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Pantry/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var food = await _context.Foods.Include(f => f.Category).Include(qu => qu.QuantityUnit)
                .FirstOrDefaultAsync(f => f.Id == id);

            var categories = await _context.Categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToListAsync();

            var quantityUnits = await _context.QuantityUnits.Select(qu => new SelectListItem()
            {
                Text = qu.Name,
                Value = qu.Id.ToString()
            }).ToListAsync();

            var viewModel = new FoodItemFormViewModel()
            {
                FoodItemName = food.Name,
                Quantity = food.Quantity,
                CategoryOptions = categories,
                QuantityUnitOptions = quantityUnits,
                Threshold = food.Threshold,
                FoodId = food.Id,
                PantryId = food.PantryId.Value,
                CategoryId = food.CategoryId
            };

            return View(viewModel);
        }

        // POST: Pantry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, FoodItemFormViewModel foodItem)
        {
            try
            {
                var food = await _context.Foods.Include(f => f.Category).Include(qu => qu.QuantityUnit)
                               .FirstOrDefaultAsync(f => f.Id == id);

                food.Name = foodItem.FoodItemName;
                food.Quantity = foodItem.Quantity;
                food.QuantityUnitId = foodItem.QuantityUnitId;
                food.Threshold = foodItem.Threshold;
                food.CategoryId = foodItem.CategoryId;

                _context.Foods.Update(food);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pantry/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var food = await _context.Foods.Include(f => f.Category).Include(qu => qu.QuantityUnit).FirstOrDefaultAsync(f => f.Id == id);

            return View(food);
        }

        // POST: Pantry/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Food food)
        {
            try
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: Pantry/QuantityUp/5
        [HttpPost]
        public async Task<ActionResult> QuantityUp(int id)
        {
            try
            {
                var food = await _context.Foods.Include(f => f.Category).Include(qu => qu.QuantityUnit)
                               .FirstOrDefaultAsync(f => f.Id == id);
                
                food.Quantity = food.Quantity + 1;

                _context.Foods.Update(food);
                await _context.SaveChangesAsync();

                return Ok(food);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Pantry/QuantityDown/5
        [HttpPost]
        public async Task<ActionResult> QuantityDown(int id)
        {
            try
            {
                var food = await _context.Foods.Include(f => f.Category).Include(qu => qu.QuantityUnit).FirstOrDefaultAsync(f => f.Id == id);
                food.Quantity = food.Quantity - 1;
                _context.Foods.Update(food);
                await _context.SaveChangesAsync();

                return Ok(food);
            }
            catch
            {
                return View();
            }
        }

        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}