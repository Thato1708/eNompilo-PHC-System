using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class ModifyFimalyplanningRords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPRecord_FamilyPlanningAppointment_BookingTypeID",
                table: "FamilyPRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPRecord_Users_DoctorId",
                table: "FamilyPRecord");

            migrationBuilder.RenameColumn(
                name: "BookingTypeID",
                table: "FamilyPRecord",
                newName: "FamilyPlanningAppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyPRecord_BookingTypeID",
                table: "FamilyPRecord",
                newName: "IX_FamilyPRecord_FamilyPlanningAppointmentId");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "FamilyPRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "FamilyPRecord",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPRecord_FamilyPlanningAppointment_FamilyPlanningAppointmentId",
                table: "FamilyPRecord",
                column: "FamilyPlanningAppointmentId",
                principalTable: "FamilyPlanningAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPRecord_Users_DoctorId",
                table: "FamilyPRecord",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPRecord_FamilyPlanningAppointment_FamilyPlanningAppointmentId",
                table: "FamilyPRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPRecord_Users_DoctorId",
                table: "FamilyPRecord");

            migrationBuilder.RenameColumn(
                name: "FamilyPlanningAppointmentId",
                table: "FamilyPRecord",
                newName: "BookingTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyPRecord_FamilyPlanningAppointmentId",
                table: "FamilyPRecord",
                newName: "IX_FamilyPRecord_BookingTypeID");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "FamilyPRecord",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "FamilyPRecord",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPRecord_FamilyPlanningAppointment_BookingTypeID",
                table: "FamilyPRecord",
                column: "BookingTypeID",
                principalTable: "FamilyPlanningAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPRecord_Users_DoctorId",
                table: "FamilyPRecord",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
