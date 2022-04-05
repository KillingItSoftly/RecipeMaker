using MyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDataService
{
    public interface IRecipeData
    {
        Task<List<Food>> GetFoods();

        Task<List<FoodGroup>> GetFoodGroups();

        Task<Food>GetFood(int? id);

        Task Add(Food food);

        Task Delete(int id);
        Task Delete(Food food);
        Task Update (Food food);
        Task<Food> Find(int id);
        
    }
}
