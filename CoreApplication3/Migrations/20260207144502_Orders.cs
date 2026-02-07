using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderTarget",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTarget", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "orderDetailTarget",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetailTarget", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_orderDetailTarget_carTarget_CarId",
                        column: x => x.CarId,
                        principalTable: "carTarget",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetailTarget_orderTarget_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orderTarget",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetailTarget_CarId",
                table: "orderDetailTarget",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetailTarget_OrderId",
                table: "orderDetailTarget",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetailTarget");

            migrationBuilder.DropTable(
                name: "orderTarget");
        }
    }
}
