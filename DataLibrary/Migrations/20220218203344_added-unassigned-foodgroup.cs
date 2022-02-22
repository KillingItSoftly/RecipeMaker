using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLibrary.Migrations
{
    public partial class addedunassignedfoodgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodGroups",
                columns: new[] { "Id", "Group" },
                values: new object[] { 5, "Unassigned" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodGroups",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
