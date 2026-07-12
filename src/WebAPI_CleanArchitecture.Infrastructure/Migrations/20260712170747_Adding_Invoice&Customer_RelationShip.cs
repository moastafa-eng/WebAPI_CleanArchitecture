using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adding_InvoiceCustomer_RelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_Id",
                table: "Invoices");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId1",
                table: "Invoices",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId1",
                table: "Invoices",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_Id",
                table: "Invoices",
                column: "Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
