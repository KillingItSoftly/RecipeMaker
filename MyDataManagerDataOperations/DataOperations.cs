using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDataManagerDataOperations
{
    public class DataOperations
    {
        public static IConfigurationRoot _configuration;
        public static DbContextOptionsBuilder<DataDbContext> _optionsBuilder;

        public static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyDataManagerData"));
        }
        public DataOperations()
        {
            BuildOptions();
        }

        public async Task<List<Food>> GetFoods()
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                return db.Foods.OrderBy(x => x.Name).ToList();
            }
        }

        public async Task<List<FoodGroup>> GetFoodGroups()
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                return db.FoodGroups.ToList();
            }
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                return db.Recipes.OrderBy(x => x.Dish).ToList();
            }
        }

        public async Task<List<StockItem>> GetStockItems()
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                return db.StockItems.ToList();
            }
        }

        public async Task<List<RecipeItem>> GetRecipeItems()
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                return db.ReceipeItems.ToList();
            }
        }

        public async Task DeleteFood(int deleteID)
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                var food = db.Foods.SingleOrDefault(x => x.Id == deleteID);
                if (food != null)
                {
                    db.Foods.Remove(food);
                    db.SaveChanges();
                }
            }
        }

        public async Task AddFood(Food food)
        {
            await using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                db.Foods.Add(food);
                db.SaveChanges();
            }
        }

        public void LoadData()
        {
            var appId = _configuration["edamam:app_id"].ToString();
            var appKey = _configuration["edamam:app_key"].ToString();
            var di = new DataImporter();
            var a = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < a.Length; i++)
            {
                var nextChar = a.Substring(i, 1);
                Task.Run(async () => await di.GetData(appKey, appId, nextChar));
            }
        }

        //using (var db = new DataDbContext(_optionsBuilder.Options))
        //{

        //    var theFood = db.Foods.Include(x => x.RecipeItems).ThenInclude(y => y.Recipe)
        //                     .Select(x => new
        //                     {
        //                         Id = x.Id,
        //                         Name = x.Name,
        //                         Recipes = x.RecipeItems.Select(y => y.Recipe)
        //                     } )
        //                     .SingleOrDefault(x => x.Id == selectedItem.Id);
        //    var recipes = new List<Recipe>();

        //    /*foreach(var ri in theFood.RecipeItems)
        //    {
        //        recipes.Add(ri.Recipe);
        //    }*/
        //    dgItems.DataBindings.Clear();
        //    dgItems.DataSource = theFood.Recipes;



        //var firstData = ReceipeItems.Where(x => x.FoodId == selectedItem.Id && x.RecipeId == Recipes.Id).ToList();

    }
}






