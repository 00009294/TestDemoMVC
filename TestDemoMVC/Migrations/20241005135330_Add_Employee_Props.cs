using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Add_Employee_Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Column1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInfo9 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
