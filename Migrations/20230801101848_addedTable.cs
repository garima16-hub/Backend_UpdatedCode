using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3DModels.Migrations
{
    public partial class addedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryItemId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_InventoryItemId",
                table: "Models",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_InventoryItems_InventoryItemId",
                table: "Models",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_InventoryItems_InventoryItemId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_Models_InventoryItemId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "Models");
        }
    }
}
