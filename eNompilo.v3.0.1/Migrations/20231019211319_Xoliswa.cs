using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class Xoliswa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCollected",
                table: "FamilyPlanningAppointment",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePractitionerId",
                table: "FamilyPlanningAppointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Contraceptive",
                columns: table => new
                {
                    ContraceptiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraceptiveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraceptiveDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraceptiveDuration = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contraceptive", x => x.ContraceptiveId);
                });

            migrationBuilder.CreateTable(
                name: "ContraceptiveBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedContraceptive = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraceptiveBooking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedCondition",
                columns: table => new
                {
                    SelectedConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCondition", x => x.SelectedConditionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Contraceptive");

            migrationBuilder.DropTable(
                name: "ContraceptiveBooking");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "SelectDates");

            migrationBuilder.DropTable(
                name: "SelectedCondition");

            migrationBuilder.DropColumn(
                name: "IsCollected",
                table: "FamilyPlanningAppointment");

            migrationBuilder.DropColumn(
                name: "ResponsiblePractitionerId",
                table: "FamilyPlanningAppointment");
        }
    }
}
