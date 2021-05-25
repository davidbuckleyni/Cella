using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppWarehouseUserPermmissions_AspNetUsers_UserIdId",
                table: "AppWarehouseUserPermmissions");

            migrationBuilder.DropIndex(
                name: "IX_AppWarehouseUserPermmissions_UserIdId",
                table: "AppWarehouseUserPermmissions");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "AppWarehouseUserPermmissions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AppWarehouseUserPermmissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppWarehouseUserPermmissions");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "AppWarehouseUserPermmissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppWarehouseUserPermmissions_UserIdId",
                table: "AppWarehouseUserPermmissions",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppWarehouseUserPermmissions_AspNetUsers_UserIdId",
                table: "AppWarehouseUserPermmissions",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
