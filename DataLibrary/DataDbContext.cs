using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyDataModels;

namespace DataLibrary
{
    public class DataDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        //TODO: Add your data models here
        //Example: Categories:
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DbSet<Food> Foods { get; set; } 
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<FoodGroup> FoodGroups { get; set; }    
        public DbSet<RecipeItem> ReceipeItems { get; set; }
        public DbSet <StockItem> StockItems { get; set; }


        public DataDbContext() : base()
        { 
            //intentionally blank
        }

        public DataDbContext(DbContextOptions options)
            : base(options)
        { 
            //intentionally empty
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO 1: If you want to change the database name, find the appsettings.json file
            //      then modify the connection string for MyDataManagerData to set a different
            //      Database name
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("MyDataManagerData");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use the fluent api here to define data structures and relationships
            //
            //... [optional] ...

            //example: seed some data:
            modelBuilder.Entity<Category>(x =>
            {
                x.HasData(new Category() { Id = 1, Name = "Books" },
                            new Category() { Id = 2, Name = "Movies" },
                            new Category() { Id = 3, Name = "Games" }
                );
            });

            modelBuilder.Entity<Item>(x =>
            {
                x.HasData(new Item() { Id = 1, CategoryId = 1, Name = "The Lord of the Rings" },
                            new Item() { Id = 2, CategoryId = 1, Name = "The Sword of Shannara" },
                            new Item() { Id = 3, CategoryId = 2, Name = "Top Gun" },
                            new Item() { Id = 4, CategoryId = 3, Name = "World of Tanks" },
                            new Item() { Id = 5, CategoryId = 2, Name = "Inception" },
                            new Item() { Id = 6, CategoryId = 2, Name = "Tenet" },
                            new Item() { Id = 7, CategoryId = 3, Name = "Wordle" },
                            new Item() { Id = 8, CategoryId = 1, Name = "Programming in C#" },
                            new Item() { Id = 9, CategoryId = 1, Name = "Pro GIT" },
                            new Item() { Id = 10, CategoryId = 2, Name = "Batman Begins" },
                            new Item() { Id = 11, CategoryId = 2, Name = "Man of Steel" },
                            new Item() { Id = 12, CategoryId = 3, Name = "Monopoly" },
                            new Item() { Id = 13, CategoryId = 3, Name = "Suburbia" }
                            );
            });
            modelBuilder.Entity<FoodGroup>(x =>
            {
                x.HasData(new FoodGroup() { Id = 1, Group = "Protein" },
                          new FoodGroup() { Id = 2, Group = "Produce" },
                          new FoodGroup() { Id = 3, Group = "Dry Goods" },
                          new FoodGroup() { Id = 4, Group = "Liquids" }
                          );
            });
            modelBuilder.Entity<Food>(x =>
            {
                x.HasData(new Food() { Id = 1, Name = "Chicken", FoodGroupId = 1 },
                          new Food() { Id = 2, Name = "Spinach", FoodGroupId = 2 },
                          new Food() { Id = 3, Name = "Milk", FoodGroupId = 4 },
                          new Food() { Id = 4, Name = "Spaghetti", FoodGroupId = 3 },
                          new Food() { Id = 5, Name = "Peanut Butter", FoodGroupId = 3},
                          new Food() { Id = 6, Name = "Raspberry Jelly", FoodGroupId = 3}                                                               


                );
            });
            modelBuilder.Entity<Recipe>(x =>
            {
                x.HasData(new Recipe() { Id = 1, Dish = "Chicken Alfredo", Instructions = "Put some chicken into some fettucine alfredo" },
                          new Recipe() { Id = 2, Dish = "Peanut Butter and Jelly", Instructions = "Spread peanut butter on bread, spread jelly on other piece of bread, sslap on piece of bread against other piece of bread with peanut butter and jelly facing inward" }

                );
            });
            modelBuilder.Entity<RecipeItem>(x =>
            {
                x.HasData(new RecipeItem() { Id = 1, RecipeId = 1, FoodId = 1, Amount = "4 boneless skinless thighs" },
                          new RecipeItem() { Id = 2, RecipeId = 1, FoodId = 3, Amount = "8oz" },
                          new RecipeItem() { Id = 3, RecipeId = 2, FoodId = 5, Amount = "One handful"},
                          new RecipeItem() { Id = 4, RecipeId = 2, FoodId = 6, Amount = "One Tablespoon"}    
                    );
            }
            );
            modelBuilder.Entity<StockItem> (x =>
            {
                x.HasData(new StockItem() { Id = 1, Amount = "4 boneless skinless thighs", Count = 4, FoodId = 1, },
                          new StockItem() { Id = 2, Amount = "One Gallon", Count = 1, FoodId = 3 },
                          new StockItem() { Id = 3, Amount = "16oz", Count = 16, FoodId = 4 }
                    );
            });
            

        }
    }
}