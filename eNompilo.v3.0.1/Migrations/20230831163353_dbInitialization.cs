using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eNompilo.v3._0._1.Migrations
{
    public partial class dbInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Titles = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Titles = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Practitioner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PractitionerType = table.Column<int>(type: "int", nullable: false),
                    CounsellorType = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practitioner_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PreviousDiagnoses = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PreviousMedication = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GeneralAllergies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MedicationAllergies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Referrer = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergenyContactNr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Employed = table.Column<bool>(type: "bit", nullable: false),
                    WorkTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PractitionerDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PractitionerDiary_Practitioner_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Practitioner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false),
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    VaccinationAppointmentId = table.Column<int>(type: "int", nullable: true),
                    CounsellorAppointmentId = table.Column<int>(type: "int", nullable: true),
                    GeneralAppointmentId = table.Column<int>(type: "int", nullable: true),
                    SessionsId = table.Column<int>(type: "int", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFile_MedicalHistory_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFile_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientFile_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CounsellingAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionPreference = table.Column<int>(type: "int", nullable: false),
                    BookingReasons = table.Column<int>(type: "int", nullable: false),
                    ChallengesSpecific = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientFileId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounsellingAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounsellingAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CounsellingAppointment_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPlanningAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionPreference = table.Column<int>(type: "int", nullable: false),
                    BookingReasons = table.Column<int>(type: "int", nullable: false),
                    ChallengesSpecific = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientFileId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPlanningAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningAppointment_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientIssues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientFileId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralAppointment_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeenVaccinated = table.Column<bool>(type: "bit", nullable: false),
                    PreviousVaccine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPregnant = table.Column<bool>(type: "bit", nullable: false),
                    VaccinableDiseases = table.Column<int>(type: "int", nullable: false),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientFileId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationAppointment_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedsPrescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    SessionNotesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    Arrived = table.Column<bool>(type: "bit", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionNotesId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Practitioner_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Practitioner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionIndication = table.Column<bool>(type: "bit", nullable: false),
                    PotentialCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsADanger = table.Column<bool>(type: "bit", nullable: false),
                    IsAbused = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionNotes_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CounsellingAppointment_PatientFileId",
                table: "CounsellingAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_CounsellingAppointment_PatientId",
                table: "CounsellingAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningAppointment_PatientFileId",
                table: "FamilyPlanningAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningAppointment_PatientId",
                table: "FamilyPlanningAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAppointment_PatientFileId",
                table: "GeneralAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAppointment_PatientId",
                table: "GeneralAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserId",
                table: "Patient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_MedicalHistoryId",
                table: "PatientFile",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_PatientId",
                table: "PatientFile",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_PersonalDetailsId",
                table: "PatientFile",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_PatientId",
                table: "PersonalDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Practitioner_UserId",
                table: "Practitioner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerDiary_PractitionerId",
                table: "PractitionerDiary",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMeds_SessionNotesId",
                table: "PrescriptionMeds",
                column: "SessionNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_UserId",
                table: "Receptionist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Session_PatientId",
                table: "Session",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_PractitionerId",
                table: "Session",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SessionNotesId",
                table: "Session",
                column: "SessionNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionNotes_SessionId",
                table: "SessionNotes",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationAppointment_PatientFileId",
                table: "VaccinationAppointment",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationAppointment_PatientId",
                table: "VaccinationAppointment",
                column: "PatientId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Users_UserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Practitioner_Users_UserId",
                table: "Practitioner");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Patient_PatientId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Practitioner_PractitionerId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_SessionNotes_SessionNotesId",
                table: "Session");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CounsellingAppointment");

            migrationBuilder.DropTable(
                name: "FamilyPlanningAppointment");

            migrationBuilder.DropTable(
                name: "GeneralAppointment");

            migrationBuilder.DropTable(
                name: "PractitionerDiary");

            migrationBuilder.DropTable(
                name: "PrescriptionMeds");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VaccinationAppointment");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PatientFile");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Practitioner");

            migrationBuilder.DropTable(
                name: "SessionNotes");

            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
