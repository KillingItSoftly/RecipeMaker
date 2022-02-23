using MyDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyDataManagerDataOperations
{
    internal class DataImporter
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task GetData(string key, string id, string searchText)
        {
            var url = @$"https://api.edamam.com/auto-complete?app_id={id}&app_key={key}&q={searchText}&limit=10000";
            var response = await client.GetAsync(url);
            string json = await response?.Content?.ReadAsStringAsync() ?? string.Empty;

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            try
            {

               var data = JsonConvert.DeserializeObject<List<string>>(json);

                using (var db = new DataLibrary.DataDbContext(DataOperations._optionsBuilder.Options))
                {
                   var currentFoods = db.Foods.Select(x => x.Name).ToList();
                    List<Food> ourFood = new List<Food>();
                    var foodGroup = db.FoodGroups.SingleOrDefault(x => x.Group == "Unassigned");
                    if (foodGroup != null)
                    {
                        foreach (var item in data)
                        {
                            var exists = currentFoods.Contains(item);

                            if (exists)
                            {
                                continue;
                            }

                            Food food = new Food();
                            food.Name = item;
                            food.FoodGroupId = foodGroup.Id;
                            ourFood.Add(food);


                        }
                    }
                    db.Foods.AddRange(ourFood);
                    db.SaveChanges();
                   
                }
            }
            catch (Exception ex)
            {
                throw; //log this
            }

        }
    }
}
