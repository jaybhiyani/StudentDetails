using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Migrations
{
    public partial class DepartmentremovedfromStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Students",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");
        }
    }
}
