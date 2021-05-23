using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInfo.DataAccess.Migrations
{
    public partial class meet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsOkay",
                table: "Meets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOkay",
                table: "Meets");
        }
    }
}
