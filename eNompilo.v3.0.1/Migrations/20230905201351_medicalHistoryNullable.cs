using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class medicalHistoryNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionNotes_Session_SessionId",
                table: "SessionNotes");

            migrationBuilder.DropIndex(
                name: "IX_SessionNotes_SessionId",
                table: "SessionNotes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "SessionNotes");

            migrationBuilder.DropColumn(
                name: "ChallengesSpecific",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropColumn(
                name: "SessionPreference",
                table: "FamilyPlanningAppointment");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "SessionNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChallengesSpecific",
                table: "FamilyPlanningAppointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SessionPreference",
                table: "FamilyPlanningAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SessionNotes_SessionId",
                table: "SessionNotes",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionNotes_Session_SessionId",
                table: "SessionNotes",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
