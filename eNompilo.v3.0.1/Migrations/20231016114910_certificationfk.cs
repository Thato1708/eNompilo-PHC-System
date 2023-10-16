using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class certificationfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_DoseTracking_DoseTrackingId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Users_UserId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_DoseTrackingId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_UserId",
                table: "Certification");

            migrationBuilder.DropColumn(
                name: "DoseTrackingId",
                table: "Certification");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Certification");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Certification",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DosesId",
                table: "Certification",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_DosesId",
                table: "Certification",
                column: "DosesId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_PatientId",
                table: "Certification",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_DoseTracking_DosesId",
                table: "Certification",
                column: "DosesId",
                principalTable: "DoseTracking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Patient_PatientId",
                table: "Certification",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_DoseTracking_DosesId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Patient_PatientId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_DosesId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_PatientId",
                table: "Certification");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Certification",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DosesId",
                table: "Certification",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoseTrackingId",
                table: "Certification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Certification",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certification_DoseTrackingId",
                table: "Certification",
                column: "DoseTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_UserId",
                table: "Certification",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_DoseTracking_DoseTrackingId",
                table: "Certification",
                column: "DoseTrackingId",
                principalTable: "DoseTracking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Users_UserId",
                table: "Certification",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
