using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SoundLevel",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "Products",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoundLevel",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Products");
        }
    }
}
