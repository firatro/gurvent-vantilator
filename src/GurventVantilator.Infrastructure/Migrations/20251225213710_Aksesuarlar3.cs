using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Aksesuarlar3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleNumber",
                table: "ProductAccessories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleNumber",
                table: "ProductAccessories");
        }
    }
}
