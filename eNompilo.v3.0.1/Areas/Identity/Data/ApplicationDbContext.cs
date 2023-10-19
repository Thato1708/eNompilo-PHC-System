using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Vaccination;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.Family_Planning;
using eNompilo.v3._0._1.Models.GBV;
using System.Reflection.Emit;
using eNompilo.v3._0._1.Models.ViewModels;
using eNompilo.v3._0._1.Models.SMP;

namespace eNompilo.v3._0._1.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        if (builder == null)
            throw new ArgumentNullException("modelBuilder");

        // for the other conventions, we do a metadata model loop
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            entityType.SetTableName(entityType.DisplayName());

            // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            entityType.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        //builder.Entity<DoseTracking>().Property(c => c.CertificateNo).ValueGeneratedNever();
    }
    public DbSet<Patient> tblPatient { get; set; }
    public DbSet<Practitioner> tblPractitioner { get; set; }
    public DbSet<Admin> tblAdmin { get; set; }
    public DbSet<Receptionist> tblReceptionist { get; set; }
    public DbSet<MedicalHistory> tblMedicalHistory { get; set; }
    public DbSet<PatientFile> tblPatientFile { get; set; }
    public DbSet<PersonalDetails> tblPersonalDetails { get; set; }
    public DbSet<GeneralAppointment> tblGeneralAppointment { get; set; }
    public DbSet<CounsellingAppointment> tblCounsellingAppointment { get; set; }
    public DbSet<FamilyPlanningAppointment> tblFamilyPlanningAppointment { get; set; }
    public DbSet<VaccinationAppointment> tblVaccinationAppointment { get; set; }
    public DbSet<VaccinationInventory> tblVaccinationInventory { get; set; }
    public DbSet<DoseTracking> tblDoseTracking { get; set; }
    public DbSet<PractitionerDiary> tblPractitionerDiary { get; set; }
    public DbSet<PrescriptionMeds> tblPrescriptionMeds { get; set; }
    public DbSet<Session> tblSession { get; set; }
    public DbSet<SessionNotes> tblSessionNotes { get; set; }
    public DbSet<ReportGBV> tblReportGBV { get; set; }
    public DbSet<Questionnaire> tblQuestionnaire { get; set; }
    public DbSet<SupportMembership> tblSupportGroup { get; set; }
    public DbSet<PractitionerRecommendations> tblRecommendations { get; set; }
    public DbSet<SMPAppointment> tblMedicalProcedureAppointment { get; set; }

}
