using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                schema: "EShopSchema",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "EShopSchema",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "EShopSchema",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "EShopSchema",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "EShopSchema",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                schema: "EShopSchema",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "EShopSchema",
                table: "OrderItems");
        }
    }
}
