using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExcelV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Db1",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db10",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db11",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db12",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db2",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db3",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db4",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db5",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db6",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db7",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db8",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Db9",
                table: "ProductTestDataPoints",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Db1",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db10",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db11",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db12",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db2",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db3",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db4",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db5",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db6",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db7",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db8",
                table: "ProductTestDataPoints");

            migrationBuilder.DropColumn(
                name: "Db9",
                table: "ProductTestDataPoints");
        }
    }
}
