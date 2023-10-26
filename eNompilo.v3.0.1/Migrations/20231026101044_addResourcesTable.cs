using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class addResourcesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Practitioner_PractitionerId",
                table: "Session");

            migrationBuilder.AlterColumn<int>(
                name: "PractitionerId",
                table: "Session",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PrescriptionMeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "PrescriptionMeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddResources", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMeds_PatientId",
                table: "PrescriptionMeds",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMeds_PractitionerId",
                table: "PrescriptionMeds",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMeds_Patient_PatientId",
                table: "PrescriptionMeds",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMeds_Practitioner_PractitionerId",
                table: "PrescriptionMeds",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Practitioner_PractitionerId",
                table: "Session",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMeds_Patient_PatientId",
                table: "PrescriptionMeds");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMeds_Practitioner_PractitionerId",
                table: "PrescriptionMeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Practitioner_PractitionerId",
                table: "Session");

            migrationBuilder.DropTable(
                name: "AddResources");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMeds_PatientId",
                table: "PrescriptionMeds");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMeds_PractitionerId",
                table: "PrescriptionMeds");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PrescriptionMeds");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "PrescriptionMeds");

            migrationBuilder.AlterColumn<int>(
                name: "PractitionerId",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Practitioner_PractitionerId",
                table: "Session",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
