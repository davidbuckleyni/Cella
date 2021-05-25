using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cella.Domain.Data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "SystemSetup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "SystemSetup",
                type: "uniqueidentifier",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "SystemSetup",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SystemSetup");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "SystemSetup");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "SystemSetup",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
