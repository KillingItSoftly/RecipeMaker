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
        //Foods
        Task<List<Food>> GetFoods();
        Task<Food>GetFood(int? id);
        Task Add(Food food);
        Task Delete(int id);
        Task Delete(Food food);
        Task Update (Food food);
        Task<Food> Find(int id);

        //Food Groups
        Task<List<FoodGroup>> GetFoodGroups();
        Task<FoodGroup> GetFoodGroup(int? id);
        Task Add(FoodGroup foodGroup);
        Task DeleteFoodGroup(int id);   
        Task Delete(FoodGroup food);
        Task Update(FoodGroup food);
        Task<FoodGroup> FindFoodGroup(int id);

        //Recipes
        Task<List<Recipe>> GetRecipes();
        Task<Recipe> GetRecipe(int? id);
        Task Add(Recipe recipe);
        Task DeleteRecipe(int id);
        Task Delete(Recipe recipe);
        Task Update(Recipe recipe);
        Task<Recipe> FindRecipe(int id);
    }
}
