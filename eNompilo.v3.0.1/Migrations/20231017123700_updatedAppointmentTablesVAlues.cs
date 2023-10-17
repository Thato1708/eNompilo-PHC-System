using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class updatedAppointmentTablesVAlues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CounsellingAppointment_PatientFile_PatientFileId",
                table: "CounsellingAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPlanningAppointment_PatientFile_PatientFileId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationAppointment_PatientFile_PatientFileId",
                table: "VaccinationAppointment");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationAppointment_PatientFileId",
                table: "VaccinationAppointment");

            migrationBuilder.DropIndex(
                name: "IX_FamilyPlanningAppointment_PatientFileId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropIndex(
                name: "IX_CounsellingAppointment_PatientFileId",
                table: "CounsellingAppointment");

            migrationBuilder.DropColumn(
                name: "PatientFileId",
                table: "VaccinationAppointment");

            migrationBuilder.DropColumn(
                name: "PatientFileId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropColumn(
                name: "PatientFileId",
                table: "CounsellingAppointment");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "VaccinationAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "FamilyPlanningAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "CounsellingAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationAppointment_PractitionerId",
                table: "VaccinationAppointment",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningAppointment_PractitionerId",
                table: "FamilyPlanningAppointment",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_CounsellingAppointment_PractitionerId",
                table: "CounsellingAppointment",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CounsellingAppointment_Practitioner_PractitionerId",
                table: "CounsellingAppointment",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPlanningAppointment_Practitioner_PractitionerId",
                table: "FamilyPlanningAppointment",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationAppointment_Practitioner_PractitionerId",
                table: "VaccinationAppointment",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CounsellingAppointment_Practitioner_PractitionerId",
                table: "CounsellingAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPlanningAppointment_Practitioner_PractitionerId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationAppointment_Practitioner_PractitionerId",
                table: "VaccinationAppointment");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationAppointment_PractitionerId",
                table: "VaccinationAppointment");

            migrationBuilder.DropIndex(
                name: "IX_FamilyPlanningAppointment_PractitionerId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropIndex(
                name: "IX_CounsellingAppointment_PractitionerId",
                table: "CounsellingAppointment");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "VaccinationAppointment");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "CounsellingAppointment");

            migrationBuilder.AddColumn<int>(
                name: "PatientFileId",
                table: "VaccinationAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientFileId",
                table: "FamilyPlanningAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientFileId",
                table: "CounsellingAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationAppointment_PatientFileId",
                table: "VaccinationAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningAppointment_PatientFileId",
                table: "FamilyPlanningAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_CounsellingAppointment_PatientFileId",
                table: "CounsellingAppointment",
                column: "PatientFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CounsellingAppointment_PatientFile_PatientFileId",
                table: "CounsellingAppointment",
                column: "PatientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPlanningAppointment_PatientFile_PatientFileId",
                table: "FamilyPlanningAppointment",
                column: "PatientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationAppointment_PatientFile_PatientFileId",
                table: "VaccinationAppointment",
                column: "PatientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
