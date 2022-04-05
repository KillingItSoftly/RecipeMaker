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
             return await _context.Foods.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
            
        }
    }
}