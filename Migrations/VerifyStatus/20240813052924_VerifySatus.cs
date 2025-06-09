using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Realestate.Migrations.VerifyStatus
{
    /// <inheritdoc />
    public partial class VerifySatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerifyStatuss",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Person_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Person_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sale_Person_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Value = table.Column<long>(type: "bigint", nullable: false),
                    Property_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyStatuss", x => x.SaleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerifyStatuss");
        }
    }
}
