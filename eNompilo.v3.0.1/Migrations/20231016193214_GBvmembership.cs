using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class GBvmembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familyOption = table.Column<bool>(type: "bit", nullable: false),
                    Violence = table.Column<bool>(type: "bit", nullable: false),
                    dependency = table.Column<bool>(type: "bit", nullable: false),
                    Fear = table.Column<bool>(type: "bit", nullable: false),
                    PhysAbuse = table.Column<bool>(type: "bit", nullable: false),
                    Abuse = table.Column<bool>(type: "bit", nullable: false),
                    Confide = table.Column<bool>(type: "bit", nullable: false),
                    EvidenceType = table.Column<bool>(type: "bit", nullable: false),
                    DetectorTest = table.Column<bool>(type: "bit", nullable: false),
                    ContactLawEnforcement = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportMembership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMembership", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropTable(
                name: "SupportMembership");
        }
    }
}
