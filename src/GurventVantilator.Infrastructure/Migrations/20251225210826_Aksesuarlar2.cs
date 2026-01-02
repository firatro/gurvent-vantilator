using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Aksesuarlar2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelFeature_ProductModels_ProductModelId",
                table: "ProductModelFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModelFeature",
                table: "ProductModelFeature");

            migrationBuilder.RenameTable(
                name: "ProductModelFeature",
                newName: "ProductModelFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModelFeature_ProductModelId",
                table: "ProductModelFeatures",
                newName: "IX_ProductModelFeatures_ProductModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModelFeatures",
                table: "ProductModelFeatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelFeatures_ProductModels_ProductModelId",
                table: "ProductModelFeatures",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelFeatures_ProductModels_ProductModelId",
                table: "ProductModelFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModelFeatures",
                table: "ProductModelFeatures");

            migrationBuilder.RenameTable(
                name: "ProductModelFeatures",
                newName: "ProductModelFeature");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModelFeatures_ProductModelId",
                table: "ProductModelFeature",
                newName: "IX_ProductModelFeature_ProductModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModelFeature",
                table: "ProductModelFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelFeature_ProductModels_ProductModelId",
                table: "ProductModelFeature",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
