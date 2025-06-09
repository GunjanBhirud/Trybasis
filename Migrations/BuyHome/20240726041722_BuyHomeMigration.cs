using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Realestate.Migrations.BuyHome
{
    /// <inheritdoc />
    public partial class BuyHomeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyHomes",
                columns: table => new
                {
                    Buyer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    Sale_Person_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Person_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Person_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Value = table.Column<long>(type: "bigint", nullable: false),
                    Property_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buyer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buyer_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buyer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment_Mode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyHomes", x => x.Buyer_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyHomes");
        }
    }
}
