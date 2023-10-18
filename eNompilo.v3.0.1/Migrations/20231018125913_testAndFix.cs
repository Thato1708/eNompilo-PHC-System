using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class testAndFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SMPAppointment_PatientFile_PatientFileId",
                table: "SMPAppointment");

            migrationBuilder.DropIndex(
                name: "IX_SMPAppointment_PatientFileId",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "PatientFileId",
                table: "SMPAppointment");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "SMPAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Session",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "PatientFileId",
                table: "SMPAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SMPAppointment_PatientFileId",
                table: "SMPAppointment",
                column: "PatientFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SMPAppointment_PatientFile_PatientFileId",
                table: "SMPAppointment",
                column: "PatientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
