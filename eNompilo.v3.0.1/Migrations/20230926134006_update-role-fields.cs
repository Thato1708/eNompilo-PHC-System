using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class updaterolefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Citizenship",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Receptionist",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPerson",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergenyContactNr",
                table: "Receptionist",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTel",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineManager",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Province",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkEmail",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTel",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Citizenship",
                table: "Practitioner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Practitioner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPerson",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergenyContactNr",
                table: "Practitioner",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Practitioner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTel",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineManager",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Practitioner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Province",
                table: "Practitioner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkEmail",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTel",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Citizenship",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Admin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPerson",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergenyContactNr",
                table: "Admin",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTel",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineManager",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Province",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkEmail",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTel",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoseTracking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    VaccineAdministered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdministered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondDose = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vaccine = table.Column<int>(type: "int", nullable: false),
                    SiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoseTracking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DoseTracking_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationInventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diseases = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationInventory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoseTracking_PatientId",
                table: "DoseTracking",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoseTracking");

            migrationBuilder.DropTable(
                name: "VaccinationInventory");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "EmergencyPerson",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "EmergenyContactNr",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "HomeTel",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "LineManager",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "WorkEmail",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "WorkTel",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "EmergencyPerson",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "EmergenyContactNr",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "HomeTel",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "LineManager",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "WorkEmail",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "WorkTel",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "EmergencyPerson",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "EmergenyContactNr",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "HomeTel",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "LineManager",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "WorkEmail",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "WorkTel",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Admin");
        }
    }
}
