using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GurventVantilator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirFlowMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirFlowMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voltage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiseLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSheetPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model3DPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "Order", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 10, 5, 10, 45, 31, 791, DateTimeKind.Utc).AddTicks(5090), "Yüksek basınç ve verimlilik gerektiren endüstriyel uygulamalar için radyal fanlar.", "/uploads/categories/radyal-fanlar.webp", true, "Radyal Fanlar", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AirFlowMax", "AirFlowMin", "Code", "CreatedAt", "DataSheetPath", "Description", "Diameter", "Frequency", "ImagePath", "IsActive", "Model3DPath", "Name", "NoiseLevel", "Order", "Power", "PressureMax", "PressureMin", "ProductCategoryId", "Speed", "UpdatedAt", "Voltage" },
                values: new object[,]
                {
                    { 1, "550 m³/h", "200 m³/h", "12F", new DateTime(2025, 10, 5, 10, 45, 31, 791, DateTimeKind.Utc).AddTicks(8660), "/uploads/datasheets/rsd12f.pdf", "Ø100mm fan, yüksek verimli kompakt tasarım. Orta debili sistemler için uygundur.", "Ø100mm", "50Hz", "/uploads/products/rsd12f.webp", true, "/uploads/models/rsd12f.glb", "RSD 12F", "65 dB(A)", 1, "0.25 kW", "600 Pa", "50 Pa", 1, "2800 RPM", null, "220V / 380V" },
                    { 2, "400 m³/h", "150 m³/h", "9F", new DateTime(2025, 10, 5, 10, 45, 31, 791, DateTimeKind.Utc).AddTicks(8750), "/uploads/datasheets/rsd9f.pdf", "Ø80mm fan, küçük hacimli sistemler için ideal.", "Ø80mm", "50Hz", "/uploads/products/rsd9f.webp", true, "/uploads/models/rsd9f.glb", "RSD 9F", "62 dB(A)", 2, "0.18 kW", "500 Pa", "40 Pa", 1, "2800 RPM", null, "220V" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
