using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLibrary.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodGroups_FoodGroupId",
                        column: x => x.FoodGroupId,
                        principalTable: "FoodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceipeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceipeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceipeItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceipeItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodGroups",
                columns: new[] { "Id", "Group" },
                values: new object[,]
                {
                    { 1, "Protein" },
                    { 2, "Produce" },
                    { 3, "Dry Goods" },
                    { 4, "Liquids" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Dish", "Instructions" },
                values: new object[,]
                {
                    { 1, "Chicken Alfredo", "Put some chicken into some fettucine alfredo" },
                    { 2, "Peanut Butter and Jelly", "Spread peanut butter on bread, spread jelly on other piece of bread, sslap on piece of bread against other piece of bread with peanut butter and jelly facing inward" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "FoodGroupId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Chicken" },
                    { 2, 2, "Spinach" },
                    { 3, 4, "Milk" },
                    { 4, 3, "Spaghetti" },
                    { 5, 3, "Peanut Butter" },
                    { 6, 3, "Raspberry Jelly" }
                });

            migrationBuilder.InsertData(
                table: "ReceipeItems",
                columns: new[] { "Id", "Amount", "FoodId", "RecipeId" },
                values: new object[,]
                {
                    { 1, "4 boneless skinless thighs", 1, 1 },
                    { 2, "8oz", 3, 1 },
                    { 3, "One handful", 5, 2 },
                    { 4, "One Tablespoon", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "StockItems",
                columns: new[] { "Id", "Amount", "Count", "FoodId" },
                values: new object[,]
                {
                    { 1, "4 boneless skinless thighs", 4, 1 },
                    { 2, "One Gallon", 1, 3 },
                    { 3, "16oz", 16, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodGroupId",
                table: "Foods",
                column: "FoodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeItems_FoodId",
                table: "ReceipeItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceipeItems_RecipeId",
                table: "ReceipeItems",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_FoodId",
                table: "StockItems",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceipeItems");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodGroups");
        }
    }
}
