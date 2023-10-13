using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class updateGeneralAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralAppointment_PatientFile_PatientFileId",
                table: "GeneralAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Practitioner_Users_UsersId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_Practitioner_UsersId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_GeneralAppointment_PatientFileId",
                table: "GeneralAppointment");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "PatientFileId",
                table: "GeneralAppointment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Practitioner",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "GeneralAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Practitioner_UserId",
                table: "Practitioner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAppointment_PractitionerId",
                table: "GeneralAppointment",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralAppointment_Practitioner_PractitionerId",
                table: "GeneralAppointment",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Practitioner_Users_UserId",
                table: "Practitioner",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralAppointment_Practitioner_PractitionerId",
                table: "GeneralAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Practitioner_Users_UserId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_Practitioner_UserId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_GeneralAppointment_PractitionerId",
                table: "GeneralAppointment");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "GeneralAppointment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Practitioner",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientFileId",
                table: "GeneralAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Practitioner_UsersId",
                table: "Practitioner",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAppointment_PatientFileId",
                table: "GeneralAppointment",
                column: "PatientFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralAppointment_PatientFile_PatientFileId",
                table: "GeneralAppointment",
                column: "PatientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Practitioner_Users_UsersId",
                table: "Practitioner",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
