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
                .ThenInclude(f => f.Category)
                .Where(glf => glf.Food.PantryId == user.PantryId )
                .OrderBy(glf => glf.Food.CategoryId)
                .ToListAsync();

            if (searchString != null)
            {
                foodItems = await _context.GroceryListFoods
                      .Where(gl => gl.Food.Name.Contains(searchString) && gl.Food.PantryId == user.PantryId || gl.Food.Category.Name.Contains(searchString) && gl.Food.PantryId == user.PantryId)
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
            var viewModel = new FoodItemFormViewModel();

            var categories = await _context.Categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToListAsync();

            viewModel.CategoryOptions = categories;

            return View(viewModel);
        }

        // POST: GroceryList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FoodItemFormViewModel foodItem)
        {
            try
            {
                var user = await GetUserAsync();
                var pantryId = user.PantryId;
                var groceryList = await _context.GroceryLists
                    .FirstOrDefaultAsync(gl => gl.PantryId == user.PantryId);
                var foodMatch = await _context.Foods
                    .FirstOrDefaultAsync(f => f.Name.Contains(foodItem.FoodItemName));
                if(foodMatch == null)
                {

                var food = new Food()
                {
                    PantryId = pantryId,
                    Name = foodItem.FoodItemName,
                    CategoryId = foodItem.CategoryId,
                    Quantity = 0,
                    Threshold = foodItem.Threshold,
                    IsThreshold = foodItem.IsThreshold
                };
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();

                var groceryListFoodItem = new GroceryListFood()
                {
                    FoodId = food.Id,
                    Quantity = foodItem.Quantity,
                    GroceryListId = groceryList.Id
                };
                _context.GroceryListFoods.Add(groceryListFoodItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                } else
                {

                    var categories = await _context.Categories.Select(c => new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    }).ToListAsync();

                    foodItem.CategoryOptions = categories;
                    foodItem.ShowDialog = true;
                    return View(foodItem);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: GroceryList/AddFromPantry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFromPantry(Food foodItem)
        {
            try
            {
                var user = await GetUserAsync();
                var pantryId = user.PantryId;
                var groceryList = await _context.GroceryLists
                    .FirstOrDefaultAsync(gl => gl.PantryId == user.PantryId);

                var groceryListFoodItem = new GroceryListFood()
                {
                    FoodId = foodItem.Id,
                    Quantity = 1,
                    GroceryListId = groceryList.Id
                };
                _context.GroceryListFoods.Add(groceryListFoodItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Pantry");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<ActionResult> SuggestedList()
        {
            var user = await GetUserAsync();
            var foodItems = await _context.Foods
                .Include(f => f.Category)
                .Where(f => f.PantryId == user.PantryId && f.Quantity <= f.Threshold)
                .ToListAsync();

            var groceryListFoodItems = await _context.GroceryListFoods
                .Include(glf => glf.GroceryList)
                .Where(glf => glf.GroceryList.PantryId == user.PantryId)
                .ToListAsync();

            var suggestedFoodItems = new List<Food>();
            
            foreach(var food in foodItems)
            {
                var exists = false;
                foreach(var groceryFoodItem in groceryListFoodItems)
                {
                    if(groceryFoodItem.FoodId == food.Id)
                    {
                        exists = true;
                    }
                }
                if(exists == false)
                {
                    suggestedFoodItems.Add(food);
                }
            };
              
            return View(suggestedFoodItems.Distinct());
        }


        // POST: GroceryList/AddFromSuggestedList
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFromSuggestedList(Food foodItem)
        {
            try
            {
                var user = await GetUserAsync();
                var pantryId = user.PantryId;
                var groceryList = await _context.GroceryLists
                    .FirstOrDefaultAsync(gl => gl.PantryId == user.PantryId);
                var quantityNeeded = foodItem.Threshold - foodItem.Quantity;
                var groceryListFoodItem = new GroceryListFood();


                groceryListFoodItem.FoodId = foodItem.Id;
                groceryListFoodItem.GroceryListId = groceryList.Id;
                if(quantityNeeded != 0)
                {
                    groceryListFoodItem.Quantity = quantityNeeded + 1;
                }else
                {
                    groceryListFoodItem.Quantity = foodItem.Threshold + 1;
                }
 
                _context.GroceryListFoods.Add(groceryListFoodItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(SuggestedList));
            }
            catch (Exception ex)
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


        // POST: GroceryList/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var groceryListItem = await _context.GroceryListFoods
                    .FirstOrDefaultAsync(glf => glf.Id == id);
                var foodItem = await _context.Foods
                    .FirstOrDefaultAsync(f => f.Id == groceryListItem.FoodId);

                _context.GroceryListFoods.Remove(groceryListItem);
                if(foodItem.Quantity == 0)
                {
                  _context.Foods.Remove(foodItem);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: GroceryList/DeleteSuggested/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSuggested(int id)
        {
            try
            {
               
                var foodItem = await _context.Foods
                    .FirstOrDefaultAsync(f => f.Id == id);

            
                if (foodItem.Quantity == 0)
                {
                    _context.Foods.Remove(foodItem);
                }
                else
                {
                    foodItem.Threshold = 0;
                    _context.Foods.Update(foodItem);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(SuggestedList));
            }
            catch
            {
                return View();
            }
        }


        // POST: GroceryList/Purchase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Purchase(int id)
        {
            try
            {
                var groceryItem = await _context.GroceryListFoods
                    .FirstOrDefaultAsync(glf => glf.Id == id);

                var food = await _context.Foods
                     .FirstOrDefaultAsync(f => f.Id == groceryItem.FoodId);

                food.Quantity = food.Quantity + groceryItem.Quantity;

                _context.Foods.Update(food);
                _context.GroceryListFoods.Remove(groceryItem);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: GroceryList/QuantityUp/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> QuantityUp(int id)
        {
            try
            {
                var groceryItem = await _context.GroceryListFoods
                               .FirstOrDefaultAsync(glf => glf.Id == id);

                groceryItem.Quantity = groceryItem.Quantity + 1;

                _context.GroceryListFoods.Update(groceryItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: GroceryList/QuantityDown/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> QuantityDown(int id)
        {
            try
            {
                var groceryItem = await _context.GroceryListFoods
                              .FirstOrDefaultAsync(glf => glf.Id == id);
                if (groceryItem.Quantity > 0)
                {
                    groceryItem.Quantity = groceryItem.Quantity - 1;
                }

                _context.GroceryListFoods.Update(groceryItem);
                await _context.SaveChangesAsync();

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