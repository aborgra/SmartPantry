using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartPantry.Data;
using SmartPantry.Models;

namespace SmartPantry.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Recipes
        public async Task<ActionResult> Index(string q, [FromServices] IConfiguration configuration)
        {
            var query = HttpUtility.HtmlEncode(q);

            var apiId = configuration["RecipeAPIIdentifier"];
            var apiKey = configuration["RecipeAPIKey"];

            var uri = $"https://api.edamam.com/search?q={query}&to=50&app_id={apiId}&app_key={apiKey}";
            var client = new HttpClient();

            // Set request header to accept JSON
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var RecipeData = await JsonSerializer.DeserializeAsync<Response>(json);

                if (RecipeData.Hits == null)
                {
                    return RedirectToAction(nameof(ErrorLoading));
                }
                else
                {
                    return View(RecipeData);

                }
               
            }
            else
            {
                return RedirectToAction(nameof(ErrorLoading));
            }
        }

        public IActionResult ErrorLoading()
        {
            return View();
        }

        // POST: Recipes/AddFavorite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFavorite(Recipe recipe)
        {
            try
            {
                var user = await GetUserAsync();
                var newFavoriteRecipe = new FavoriteRecipe()
                {
                    Label = recipe.Label,
                    Image = recipe.Image,
                    Url = recipe.Url,
                    Calories = recipe.Calories,
                    Ingredients = recipe.Ingredients.ToString(),
                    Nutrients = recipe.TotalNutrients.ToString()
                };

               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipes/Delete/5
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

        private async Task<ApplicationUser> GetUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}