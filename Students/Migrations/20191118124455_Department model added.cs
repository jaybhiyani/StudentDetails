using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Migrations
{
    public partial class Departmentmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DId = table.Column<int>(nullable: false),
                    Dep = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DId);
                    table.ForeignKey(
                        name: "FK_Departments_Students_DId",
                        column: x => x.DId,
                        principalTable: "Students",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
