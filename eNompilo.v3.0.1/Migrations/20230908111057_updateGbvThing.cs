using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class updateGbvThing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunicationType",
                table: "ReportGBV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CounsellingBooking",
                table: "ReportGBV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentityType",
                table: "ReportGBV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncidentType",
                table: "ReportGBV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ReportGBV",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "ReportGBV");

            migrationBuilder.DropColumn(
                name: "CounsellingBooking",
                table: "ReportGBV");

            migrationBuilder.DropColumn(
                name: "IdentityType",
                table: "ReportGBV");

            migrationBuilder.DropColumn(
                name: "IncidentType",
                table: "ReportGBV");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ReportGBV");
        }
    }
}
