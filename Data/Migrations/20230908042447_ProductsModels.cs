using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShope.Data.Migrations
{
    public partial class ProductsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductTypes");

            migrationBuilder.CreateTable(
                name: "SpacialTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacialTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pruducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    SpacialTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruducts_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pruducts_SpacialTags_SpacialTagId",
                        column: x => x.SpacialTagId,
                        principalTable: "SpacialTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pruducts_ProductTypeId",
                table: "Pruducts",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pruducts_SpacialTagId",
                table: "Pruducts",
                column: "SpacialTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pruducts");

            migrationBuilder.DropTable(
                name: "SpacialTags");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
