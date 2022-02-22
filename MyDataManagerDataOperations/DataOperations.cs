using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Food> GetFoods()
        {
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {
                
                return db.Foods.OrderBy(x=> x.Name).ToList();
                

            }
        }
        public List<FoodGroup> GetFoodGroups()
        {
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {

                return db.FoodGroups.ToList();


            }
        }
        public List<Recipe> GetRecipes()
        {
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {

                return db.Recipes.OrderBy(x => x.Dish).ToList();


            }
        }
        public List<StockItem> GetStockItems()
        {
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {

                return db.StockItems.ToList();


            }
        }
        public List<RecipeItem> GetRecipeItems()
        {
            using (var db = new DataDbContext(_optionsBuilder.Options))
            {

                return db.ReceipeItems.ToList();


            }
        }



    }
}






