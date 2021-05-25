using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_StockItems_StockItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_AspNetUsers_UserIdId",
                table: "StockItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_UserIdId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "StockItems");

            migrationBuilder.RenameTable(
                name: "StockItems",
                newName: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Categories",
                table: "Product",
                type: "int",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    DailingCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBusinessMobile = table.Column<bool>(type: "bit", nullable: false),
                    isPersonalMobile = table.Column<bool>(type: "bit", nullable: false),
                    canSms = table.Column<bool>(type: "bit", nullable: false),
                    canCall = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isOptOut = table.Column<bool>(type: "bit", nullable: false),
                    isGpdr = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminContactId = table.Column<int>(type: "int", nullable: true),
                    LastMofiedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAcitve = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Customer_AdminContactId",
                        column: x => x.AdminContactId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdminContactId",
                table: "Stores",
                column: "AdminContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_Product_StockItemId",
                table: "SalesOrderItems",
                column: "StockItemId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_Product_StockItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "StockItems");

            migrationBuilder.AlterColumn<string>(
                name: "Categories",
                table: "StockItems",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "StockItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_UserIdId",
                table: "StockItems",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_StockItems_StockItemId",
                table: "SalesOrderItems",
                column: "StockItemId",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_AspNetUsers_UserIdId",
                table: "StockItems",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
