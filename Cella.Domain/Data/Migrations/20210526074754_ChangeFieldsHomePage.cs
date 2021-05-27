using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class ChangeFieldsHomePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsShowOnHomePage",
                table: "Product",
                newName: "isShowOnHomePage");

            migrationBuilder.RenameColumn(
                name: "DisableAddToCart",
                table: "Product",
                newName: "isFeatured");

            migrationBuilder.AddColumn<bool>(
                name: "canAddToCart",
                table: "Product",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "canAddToCart",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "isShowOnHomePage",
                table: "Product",
                newName: "IsShowOnHomePage");

            migrationBuilder.RenameColumn(
                name: "isFeatured",
                table: "Product",
                newName: "DisableAddToCart");
        }
    }
}
