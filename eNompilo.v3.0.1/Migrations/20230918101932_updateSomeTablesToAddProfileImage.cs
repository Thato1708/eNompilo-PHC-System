using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class updateSomeTablesToAddProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Users_UserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Practitioner_Users_UserId",
                table: "Practitioner");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionist_Users_UserId",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_UserId",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Practitioner_UserId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_Admin_UserId",
                table: "Admin");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Receptionist",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Practitioner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Practitioner",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_UsersId",
                table: "Receptionist",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Practitioner_UsersId",
                table: "Practitioner",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UsersId",
                table: "Admin",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Users_UsersId",
                table: "Admin",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Practitioner_Users_UsersId",
                table: "Practitioner",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionist_Users_UsersId",
                table: "Receptionist",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Users_UsersId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Practitioner_Users_UsersId",
                table: "Practitioner");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionist_Users_UsersId",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_UsersId",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Practitioner_UsersId",
                table: "Practitioner");

            migrationBuilder.DropIndex(
                name: "IX_Admin_UsersId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Practitioner");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Admin");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Receptionist",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Practitioner",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_UserId",
                table: "Receptionist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Practitioner_UserId",
                table: "Practitioner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Users_UserId",
                table: "Admin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Practitioner_Users_UserId",
                table: "Practitioner",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionist_Users_UserId",
                table: "Receptionist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
