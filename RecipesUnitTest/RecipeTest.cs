using DataLibrary;
using Microsoft.EntityFrameworkCore;
using RecipeDataService;
using System.Collections.Generic;
using System;
using Xunit;
using System.Threading.Tasks;
using MyDataModels;
using Shouldly;

namespace RecipesUnitTest
{
    public class RecipeTest
    {
        private IRecipeData _service;
        DbContextOptions<DataDbContext> _options;

        public RecipeTest()
        {
            SetUpOptions();
            BuildDefaults();
        }

        private void SetUpOptions()
        {
            _options = new DbContextOptionsBuilder<DataDbContext>().UseInMemoryDatabase(databaseName: "RecipeTestDb").Options;
        }

        private void BuildDefaults()
        {
            using(var context = new DataDbContext(_options))
            {
                var existingFood = Task.Run(() => context.Foods.ToListAsync()).Result;
                if (existingFood == null || existingFood.Count < 5)
                {
                    var foods = GetFoodsTestData();
                    context.Foods.AddRange(foods);
                    context.SaveChanges();
                }
            }
        }

        private List<Food> GetFoodsTestData()
        {
            return new List<Food>()
            {
                new Food() { Id = 1, Name = "Chicken", FoodGroupId = 1 },
                new Food() { Id = 2, Name = "Steak", FoodGroupId = 1 },
                new Food() { Id = 3, Name = "Pork", FoodGroupId = 1 },
                new Food() { Id = 4, Name = "Peanut butter", FoodGroupId = 3 },
                new Food() { Id = 5, Name = "Jelly", FoodGroupId = 3 },
                new Food() { Id = 6, Name = "Lettuce", FoodGroupId = 4 },
                new Food() { Id = 7, Name = "Potato", FoodGroupId = 4 }
            };
        }

        [Theory]
        [InlineData("Steak", 1, 1)]
        public async Task GetFoodsTest(string name, int foodGroup, int index)
        {
            using (var context = new DataDbContext(_options))
            {
                _service = new RecipeData (context);
                var food = await _service.GetFoods();

                food.Count.ShouldBe(7);
                food[index].Name.ShouldBe(name);
            }
        }
    }
}