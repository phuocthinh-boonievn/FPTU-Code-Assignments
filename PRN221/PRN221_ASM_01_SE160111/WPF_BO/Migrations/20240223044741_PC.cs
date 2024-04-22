using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_BO.Migrations
{
    public partial class PC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    userID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("accounts_userid_primary", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    storeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.storeID);
                });

            migrationBuilder.CreateTable(
                name: "PC",
                columns: table => new
                {
                    productID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    imageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    review = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    userID = table.Column<short>(type: "smallint", nullable: false),
                    categoryID = table.Column<short>(type: "smallint", nullable: false),
                    storeID = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("electronics_productid_primary", x => x.productID);
                    table.ForeignKey(
                        name: "pc_categoryid_foreign",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID");
                    table.ForeignKey(
                        name: "pc_storeid_foreign",
                        column: x => x.storeID,
                        principalTable: "Store",
                        principalColumn: "storeID");
                    table.ForeignKey(
                        name: "pc_userid_foreign",
                        column: x => x.userID,
                        principalTable: "Accounts",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Accounts__CB9A1CDE4F738757",
                table: "Accounts",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Category__23CAF1F980EFA6F4",
                table: "Category",
                column: "categoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "pc_categoryid_index",
                table: "PC",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "pc_storeid_index",
                table: "PC",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "pc_userid_index",
                table: "PC",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "UQ__PC__2D10D14B3A00FD12",
                table: "PC",
                column: "productID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Store__1EA716322F03347F",
                table: "Store",
                column: "storeID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PC");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
