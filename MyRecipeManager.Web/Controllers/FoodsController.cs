#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDataModels;
using MyRecipeManager.Web.Data;
using RecipeDataService;

namespace MyRecipeManager.Web.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IRecipeData _recipeData; //Rick did this

        public FoodsController(IRecipeData recipeData)
        {
            
            _recipeData = recipeData;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var foods = await _recipeData.GetFoods();
            return View(foods);
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _recipeData.GetFood(id);   
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            var foodGroups = _recipeData.GetFoodGroups().Result;
            ViewData["FoodGroupId"] = new SelectList(foodGroups, "Id", "Group");
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FoodGroupId")] Food food)
        {
            var foodGroups = _recipeData.GetFoodGroups().Result;
            if (ModelState.IsValid)
            {
                await _recipeData.Add(food);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodGroupId"] = new SelectList(foodGroups, "Id", "Group", food.FoodGroupId);
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var foodGroups = _recipeData.GetFoodGroups().Result;
            if (id == null)
            {
                return NotFound();
            }

            var food = await _recipeData.Find((int)id);
            if (food == null)
            {
                return NotFound();
            }
            ViewData["FoodGroupId"] = new SelectList(foodGroups, "Id", "Group", food.FoodGroupId);
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FoodGroupId")] Food food)
        {
            var foodGroups = _recipeData.GetFoodGroups().Result;
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _recipeData.Update(food);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            ViewData["FoodGroupId"] = new SelectList(foodGroups, "Id", "Group", food.FoodGroupId);
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var food = await _recipeData.GetFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _recipeData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            var food = _recipeData.GetFood(id);
            return food != null;
        }
    }
}
