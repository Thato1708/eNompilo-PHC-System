using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoseTracking_Patient_PatientId",
                table: "DoseTracking");

            migrationBuilder.DropIndex(
                name: "IX_DoseTracking_PatientId",
                table: "DoseTracking");

            migrationBuilder.DropColumn(
                name: "VaccineAdministered",
                table: "DoseTracking");

            migrationBuilder.AddColumn<int>(
                name: "DoseTrackingID",
                table: "VaccinationInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoseTrackingID",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "DoseTracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VaccineInventoryId",
                table: "DoseTracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInventory_DoseTrackingID",
                table: "VaccinationInventory",
                column: "DoseTrackingID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoseTrackingID",
                table: "Patient",
                column: "DoseTrackingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_DoseTracking_DoseTrackingID",
                table: "Patient",
                column: "DoseTrackingID",
                principalTable: "DoseTracking",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationInventory_DoseTracking_DoseTrackingID",
                table: "VaccinationInventory",
                column: "DoseTrackingID",
                principalTable: "DoseTracking",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_DoseTracking_DoseTrackingID",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationInventory_DoseTracking_DoseTrackingID",
                table: "VaccinationInventory");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationInventory_DoseTrackingID",
                table: "VaccinationInventory");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoseTrackingID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoseTrackingID",
                table: "VaccinationInventory");

            migrationBuilder.DropColumn(
                name: "DoseTrackingID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "VaccineInventoryId",
                table: "DoseTracking");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "DoseTracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccineAdministered",
                table: "DoseTracking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DoseTracking_PatientId",
                table: "DoseTracking",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoseTracking_Patient_PatientId",
                table: "DoseTracking",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
