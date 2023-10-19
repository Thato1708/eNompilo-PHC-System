using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class SMPAppoinment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "SMPAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredDate",
                table: "SMPAppointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredTime",
                table: "SMPAppointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SessionConfirmed",
                table: "SMPAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SMPAppointment_PractitionerId",
                table: "SMPAppointment",
                column: "PractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SMPAppointment_Practitioner_PractitionerId",
                table: "SMPAppointment",
                column: "PractitionerId",
                principalTable: "Practitioner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SMPAppointment_Practitioner_PractitionerId",
                table: "SMPAppointment");

            migrationBuilder.DropIndex(
                name: "IX_SMPAppointment_PractitionerId",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "PreferredDate",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "PreferredTime",
                table: "SMPAppointment");

            migrationBuilder.DropColumn(
                name: "SessionConfirmed",
                table: "SMPAppointment");
        }
    }
}
