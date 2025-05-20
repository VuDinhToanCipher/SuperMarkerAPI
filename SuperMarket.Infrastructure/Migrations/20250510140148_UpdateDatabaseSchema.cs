using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarkerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplier_Product_Products_ProductId",
                table: "supplier_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_supplier_Product_Suppliers_SupplierId",
                table: "supplier_Product");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "PositionPermissions",
                columns: table => new
                {
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPermissions", x => new { x.PermissionID, x.PositionID });
                    table.ForeignKey(
                        name: "FK_PositionPermissions_Permission_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionPermissions_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPermissions_PositionID",
                table: "PositionPermissions",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_Product_Products_ProductId",
                table: "supplier_Product",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "IDProduct",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_Product_Suppliers_SupplierId",
                table: "supplier_Product",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplier_Product_Products_ProductId",
                table: "supplier_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_supplier_Product_Suppliers_SupplierId",
                table: "supplier_Product");

            migrationBuilder.DropTable(
                name: "PositionPermissions");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_Product_Products_ProductId",
                table: "supplier_Product",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "IDProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_Product_Suppliers_SupplierId",
                table: "supplier_Product",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
