using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class Sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMeds_SessionNotes_SessionNotesId",
                table: "PrescriptionMeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_SessionNotes_SessionNotesId",
                table: "Session");

            migrationBuilder.DropTable(
                name: "SessionNotes");

            migrationBuilder.DropIndex(
                name: "IX_Session_SessionNotesId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMeds_SessionNotesId",
                table: "PrescriptionMeds");

            migrationBuilder.DropColumn(
                name: "SessionNotesId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "SessionNotesId",
                table: "PrescriptionMeds");

            migrationBuilder.AddColumn<bool>(
                name: "ConditionIndication",
                table: "Session",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsADanger",
                table: "Session",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbused",
                table: "Session",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PotentialCondition",
                table: "Session",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PractitionerNotes",
                table: "Session",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prescription",
                table: "Session",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionIndication",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "IsADanger",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "IsAbused",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PotentialCondition",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PractitionerNotes",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Prescription",
                table: "Session");

            migrationBuilder.AddColumn<int>(
                name: "SessionNotesId",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionNotesId",
                table: "PrescriptionMeds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SessionNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    ConditionIndication = table.Column<bool>(type: "bit", nullable: false),
                    IsADanger = table.Column<bool>(type: "bit", nullable: false),
                    IsAbused = table.Column<bool>(type: "bit", nullable: false),
                    PotentialCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PractitionerNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionNotes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionNotesId",
                table: "Session",
                column: "SessionNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMeds_SessionNotesId",
                table: "PrescriptionMeds",
                column: "SessionNotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMeds_SessionNotes_SessionNotesId",
                table: "PrescriptionMeds",
                column: "SessionNotesId",
                principalTable: "SessionNotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_SessionNotes_SessionNotesId",
                table: "Session",
                column: "SessionNotesId",
                principalTable: "SessionNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
