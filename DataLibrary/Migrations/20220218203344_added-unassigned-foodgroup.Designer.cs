﻿// <auto-generated />
using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLibrary.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20220218203344_added-unassigned-foodgroup")]
    partial class addedunassignedfoodgroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyDataModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Games"
                        });
                });

            modelBuilder.Entity("MyDataModels.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FoodGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FoodGroupId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodGroupId = 1,
                            Name = "Chicken"
                        },
                        new
                        {
                            Id = 2,
                            FoodGroupId = 2,
                            Name = "Spinach"
                        },
                        new
                        {
                            Id = 3,
                            FoodGroupId = 4,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 4,
                            FoodGroupId = 3,
                            Name = "Spaghetti"
                        },
                        new
                        {
                            Id = 5,
                            FoodGroupId = 3,
                            Name = "Peanut Butter"
                        },
                        new
                        {
                            Id = 6,
                            FoodGroupId = 3,
                            Name = "Raspberry Jelly"
                        });
                });

            modelBuilder.Entity("MyDataModels.FoodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FoodGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Group = "Protein"
                        },
                        new
                        {
                            Id = 2,
                            Group = "Produce"
                        },
                        new
                        {
                            Id = 3,
                            Group = "Dry Goods"
                        },
                        new
                        {
                            Id = 4,
                            Group = "Liquids"
                        },
                        new
                        {
                            Id = 5,
                            Group = "Unassigned"
                        });
                });

            modelBuilder.Entity("MyDataModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "The Sword of Shannara"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Top Gun"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Name = "World of Tanks"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "Inception"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Tenet"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "Wordle"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Name = "Programming in C#"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Name = "Pro GIT"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Name = "Batman Begins"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Name = "Man of Steel"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Name = "Monopoly"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Name = "Suburbia"
                        });
                });

            modelBuilder.Entity("MyDataModels.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dish")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dish = "Chicken Alfredo",
                            Instructions = "Put some chicken into some fettucine alfredo"
                        },
                        new
                        {
                            Id = 2,
                            Dish = "Peanut Butter and Jelly",
                            Instructions = "Spread peanut butter on bread, spread jelly on other piece of bread, sslap on piece of bread against other piece of bread with peanut butter and jelly facing inward"
                        });
                });

            modelBuilder.Entity("MyDataModels.RecipeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("RecipeId");

                    b.ToTable("ReceipeItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = "4 boneless skinless thighs",
                            FoodId = 1,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = "8oz",
                            FoodId = 3,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = "One handful",
                            FoodId = 5,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Amount = "One Tablespoon",
                            FoodId = 6,
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("MyDataModels.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("StockItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = "4 boneless skinless thighs",
                            Count = 4,
                            FoodId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = "One Gallon",
                            Count = 1,
                            FoodId = 3
                        },
                        new
                        {
                            Id = 3,
                            Amount = "16oz",
                            Count = 16,
                            FoodId = 4
                        });
                });

            modelBuilder.Entity("MyDataModels.Food", b =>
                {
                    b.HasOne("MyDataModels.FoodGroup", "FoodGroup")
                        .WithMany("Foods")
                        .HasForeignKey("FoodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodGroup");
                });

            modelBuilder.Entity("MyDataModels.Item", b =>
                {
                    b.HasOne("MyDataModels.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyDataModels.RecipeItem", b =>
                {
                    b.HasOne("MyDataModels.Food", "Food")
                        .WithMany("RecipeItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyDataModels.Recipe", "Recipe")
                        .WithMany("RecipeItems")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MyDataModels.StockItem", b =>
                {
                    b.HasOne("MyDataModels.Food", "Food")
                        .WithMany("StockItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("MyDataModels.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("MyDataModels.Food", b =>
                {
                    b.Navigation("RecipeItems");

                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("MyDataModels.FoodGroup", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("MyDataModels.Recipe", b =>
                {
                    b.Navigation("RecipeItems");
                });
#pragma warning restore 612, 618
        }
    }
}