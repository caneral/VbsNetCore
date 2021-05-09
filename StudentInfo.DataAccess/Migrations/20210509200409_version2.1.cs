using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInfo.DataAccess.Migrations
{
    public partial class version21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AppUsers",
                newName: "TCNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TCNumber",
                table: "AppUsers",
                newName: "UserName");
        }
    }
}
