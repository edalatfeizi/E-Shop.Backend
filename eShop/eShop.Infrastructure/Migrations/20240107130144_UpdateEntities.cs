using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "EShopSchema",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "EShopSchema",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "EShopSchema",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "EShopSchema",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "EShopSchema",
                table: "Categories");
        }
    }
}
