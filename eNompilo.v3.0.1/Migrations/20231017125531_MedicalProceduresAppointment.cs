using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class MedicalProceduresAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMPAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaesthesiaReaction = table.Column<bool>(type: "bit", nullable: false),
                    NatureOfReaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreathingtubeSurgery = table.Column<bool>(type: "bit", nullable: false),
                    Movement = table.Column<bool>(type: "bit", nullable: false),
                    HeartAttack = table.Column<bool>(type: "bit", nullable: false),
                    HeartAttackDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiabetesQuestion = table.Column<bool>(type: "bit", nullable: false),
                    InsulinQuestion = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientFileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMPAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMPAppointment_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMPAppointment_PatientFileId",
                table: "SMPAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_SMPAppointment_PatientId",
                table: "SMPAppointment",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMPAppointment");
        }
    }
}
