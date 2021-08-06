using Microsoft.EntityFrameworkCore.Migrations;

namespace ASAP.API.Migrations
{
    public partial class updatepersonmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "People",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "People");
        }
    }
}
