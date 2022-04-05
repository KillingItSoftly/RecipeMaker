using DataLibrary;
using Microsoft.EntityFrameworkCore;
using MyDataModels;

namespace RecipeDataService
{
    public class RecipeData : IRecipeData
    {
        private readonly DataDbContext _context;
        public RecipeData(DataDbContext context)
        {
            _context = context;
        }

        public async Task<List<Food>> GetFoods()
        {
            return await _context.Foods.OrderBy(x => x.FoodGroupId).Include(x => x.FoodGroup).AsNoTracking().ToListAsync();
        }

        public async Task<List<FoodGroup>> GetFoodGroups()
        {
            return await _context.FoodGroups.ToListAsync();
        }
        public async Task<List<Recipe>> GetRecipes()
        {
            return await _context.Recipes.OrderBy(x => x.Dish).ToListAsync();
        }

        public async Task<List<StockItem>> GetStockItems()
        {
            return await _context.StockItems.ToListAsync();
        }

        public async Task<List<RecipeItem>> GetRecipeItems()
        {
            return await _context.ReceipeItems.ToListAsync();
        }
        public async Task<Food> GetFood(int? id)
        {
            return await _context.Foods.Include(f => f.FoodGroup).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Add(Food food)
        {
            await _context.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Food food)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Food food)
        {
            var actualFood = await _context.Foods.FirstOrDefaultAsync(f => f.Id == food.Id);
            actualFood.Id = food.Id;
            actualFood.Name = food.Name;
            actualFood.FoodGroupId = food.FoodGroupId;
            await Task.Run(() => _context.Update(actualFood));
            await _context.SaveChangesAsync();

        }

        public async Task<Food> Find(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            return food;
        }

        public async Task<FoodGroup> GetFoodGroup(int? id)
        {
           return await _context.FoodGroups .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Add(FoodGroup foodGroup)
        {
            await _context.AddAsync(foodGroup);
            await _context.SaveChangesAsync();
        }

        public Task Delete(FoodGroup food)
        {
            throw new NotImplementedException();
        }

        public async Task Update(FoodGroup foodgroup)
        {
            var actualFoodGroup = await _context.FoodGroups.FirstOrDefaultAsync(m => m.Id == foodgroup.Id);
            actualFoodGroup.Id = foodgroup.Id;
            actualFoodGroup.Group = foodgroup.Group;
            await Task.Run(() => _context.Update(actualFoodGroup)); 
            await _context.SaveChangesAsync();
        }

        public async Task<FoodGroup> FindFoodGroup(int id)
        {
            var foodGroup = await _context.FoodGroups.FindAsync(id);
            return foodGroup;
        }

        public async Task DeleteFoodGroup(int id)
        {
            var foodGroup = await _context.FoodGroups.FindAsync(id);
            _context.FoodGroups.Remove(foodGroup);
            await _context.SaveChangesAsync();
        }
    }
}