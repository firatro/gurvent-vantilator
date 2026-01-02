using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkingCondutionRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductWorkingConditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductWorkingConditions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProductWorkingConditions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductWorkingConditions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Voltage",
                table: "Products",
                type: "nvarchar(max)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float(10)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductWorkingConditions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductWorkingConditions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProductWorkingConditions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProductWorkingConditions");

            migrationBuilder.AlterColumn<double>(
                name: "Voltage",
                table: "Products",
                type: "float(10)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
