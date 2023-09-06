using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShope.Data.Migrations
{
    public partial class AddNewColumProductTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductTypes");
        }
    }
}
