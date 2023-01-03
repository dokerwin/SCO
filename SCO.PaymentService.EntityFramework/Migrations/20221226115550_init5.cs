using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCO.PaymentService.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "MethodOfPaymentId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDataTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MethodOfPaymentId",
                table: "Payments",
                column: "MethodOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MOPs_MethodOfPaymentId",
                table: "Payments",
                column: "MethodOfPaymentId",
                principalTable: "MOPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MOPs_MethodOfPaymentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MethodOfPaymentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MethodOfPaymentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentDataTime",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");
        }
    }
}
