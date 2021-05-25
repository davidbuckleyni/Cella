using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_StockItems_StockItemId",
                table: "FileAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_StockItemVm_StockPhotosId",
                table: "FileAttachments");

            migrationBuilder.DropTable(
                name: "StockItemVm");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_StockItemId",
                table: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_StockPhotosId",
                table: "FileAttachments");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "StockItemId",
                table: "FileAttachments");

            migrationBuilder.DropColumn(
                name: "StockPhotosForeignKey",
                table: "FileAttachments");

            migrationBuilder.DropColumn(
                name: "StockPhotosId",
                table: "FileAttachments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StockItems",
                newName: "StoreId");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "StockItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SalesOrderItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "SalesOrderItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "CustomFieldsDataTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CustomFieldsDataTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "CustomFields",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CustomFields",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_UserIdId",
                table: "StockItems",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_AspNetUsers_UserIdId",
                table: "StockItems",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_AspNetUsers_UserIdId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_UserIdId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "CustomFieldsDataTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomFieldsDataTypes");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "StockItems",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "StockItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SalesOrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockItemId",
                table: "FileAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockPhotosForeignKey",
                table: "FileAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockPhotosId",
                table: "FileAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockItemVm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminComment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AvailableEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GTIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowOnHomePage = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturePartNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufactures = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    StockCode = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseLocation = table.Column<int>(type: "int", nullable: false),
                    isBackOrder = table.Column<bool>(type: "bit", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    isPublished = table.Column<bool>(type: "bit", nullable: false),
                    isShowCallButton = table.Column<bool>(type: "bit", nullable: false),
                    isShowPrice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemVm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_StockItemId",
                table: "FileAttachments",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_StockPhotosId",
                table: "FileAttachments",
                column: "StockPhotosId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_StockItems_StockItemId",
                table: "FileAttachments",
                column: "StockItemId",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_StockItemVm_StockPhotosId",
                table: "FileAttachments",
                column: "StockPhotosId",
                principalTable: "StockItemVm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
