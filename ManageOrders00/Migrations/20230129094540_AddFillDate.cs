using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageOrders00.Migrations
{
    /// <inheritdoc />
    public partial class AddFillDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Position_ProductId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderReleaseDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_ProductId",
                table: "Position",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Position_ProductId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderReleaseDate",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Position_ProductId",
                table: "Position",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId",
                unique: true);
        }
    }
}
