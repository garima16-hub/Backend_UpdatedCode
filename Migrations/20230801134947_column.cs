using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3DModels.Migrations
{
    public partial class column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InventoryItems",
                newName: "InventoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "InventoryItems",
                newName: "Id");
        }
    }
}
