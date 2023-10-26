using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class renamedFieldsAndAddedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AddResources");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "AddResources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AddResources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "AddResources");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AddResources");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AddResources",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
