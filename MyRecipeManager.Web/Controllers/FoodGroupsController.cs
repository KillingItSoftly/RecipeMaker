#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLibrary;
using MyDataModels;
using RecipeDataService;

namespace MyRecipeManager.Web.Controllers
{
    public class FoodGroupsController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IRecipeData _recipeData;

        public FoodGroupsController(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }

        // GET: FoodGroups
        public async Task<IActionResult> Index()
        {
            var foodGroups = await _recipeData.GetFoodGroups();
            return View(foodGroups);
        }

        // GET: FoodGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodGroup = await _recipeData.GetFoodGroup(id);
            if (foodGroup == null)
            {
                return NotFound();
            }

            return View(foodGroup);
        }

        // GET: FoodGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Group")] FoodGroup foodGroup)
        {
            if (ModelState.IsValid)
            {
                await _recipeData.Add(foodGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(foodGroup);
        }

        // GET: FoodGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodGroup = await _recipeData.FindFoodGroup((int)id);
            if (foodGroup == null)
            {
                return NotFound();
            }
            return View(foodGroup);
        }

        // POST: FoodGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Group")] FoodGroup foodGroup)
        {
            if (id != foodGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _recipeData.Update(foodGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodGroupExists(foodGroup.Id))
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
            return View(foodGroup);
        }

        // GET: FoodGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodGroup = await _recipeData.GetFoodGroup(id);
            if (foodGroup == null)
            {
                return NotFound();
            }

            return View(foodGroup);
        }

        // POST: FoodGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _recipeData.DeleteFoodGroup(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FoodGroupExists(int id)
        {
            var foodGroup = _recipeData.GetFoodGroup(id);
            return foodGroup != null;
        }
    }
}
