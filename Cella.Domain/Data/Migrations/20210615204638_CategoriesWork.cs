using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class CategoriesWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyWord",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageSize",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TennantId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalProductsCategory",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "canCustomerSelectPageSize",
                table: "Categories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isIncludeSideMenu",
                table: "Categories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isShowHomePage",
                table: "Categories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSubItem",
                table: "Categories",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MetaKeyWord",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PageSize",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TennantId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TotalProductsCategory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "canCustomerSelectPageSize",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "isIncludeSideMenu",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "isShowHomePage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "isSubItem",
                table: "Categories");
        }
    }
}
