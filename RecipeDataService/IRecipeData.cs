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
    }
}
