using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class ModFamilyPlanningSubbSytemk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyPRecords");

            migrationBuilder.CreateTable(
                name: "FamilyPRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDiscontinued = table.Column<bool>(type: "bit", nullable: false),
                    DosageAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosageDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPRecord_FamilyPlanningAppointment_BookingTypeID",
                        column: x => x.BookingTypeID,
                        principalTable: "FamilyPlanningAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyPRecord_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPRecord_BookingTypeID",
                table: "FamilyPRecord",
                column: "BookingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPRecord_DoctorId",
                table: "FamilyPRecord",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyPRecord");

            migrationBuilder.CreateTable(
                name: "FamilyPRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTypeID = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosageAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosageDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDiscontinued = table.Column<bool>(type: "bit", nullable: false),
                    MedicalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPRecords_FamilyPlanningAppointment_BookingTypeID",
                        column: x => x.BookingTypeID,
                        principalTable: "FamilyPlanningAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyPRecords_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPRecords_BookingTypeID",
                table: "FamilyPRecords",
                column: "BookingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPRecords_DoctorId",
                table: "FamilyPRecords",
                column: "DoctorId");
        }
    }
}
