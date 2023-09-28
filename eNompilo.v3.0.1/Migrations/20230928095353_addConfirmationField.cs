using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class addConfirmationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SessionConfirmed",
                table: "VaccinationAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SessionConfirmed",
                table: "GeneralAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SessionConfirmed",
                table: "FamilyPlanningAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SessionConfirmed",
                table: "CounsellingAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionConfirmed",
                table: "VaccinationAppointment");

            migrationBuilder.DropColumn(
                name: "SessionConfirmed",
                table: "GeneralAppointment");

            migrationBuilder.DropColumn(
                name: "SessionConfirmed",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropColumn(
                name: "SessionConfirmed",
                table: "CounsellingAppointment");
        }
    }
}
