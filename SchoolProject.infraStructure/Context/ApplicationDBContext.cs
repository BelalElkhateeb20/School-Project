using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Configurations;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.Views;
using SchoolProject.infraStructure.Configurations;
using SchoolProject.infraStructure.DataSeedingConfigurations;



namespace SchoolProject.infraStructure.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Database Seeding
            modelBuilder.ApplyConfiguration(new DepartmentSeedingConfig());
            modelBuilder.ApplyConfiguration(new StudentSeedingConfig());
            modelBuilder.ApplyConfiguration(new InstractorSeedingConfig());
            modelBuilder.ApplyConfiguration(new SubjectSeedingConfig());
            #endregion

            #region Relationships
            modelBuilder.Entity<StudentSubjects>()
                .HasKey(x => new { x.SubID, x.StudID });

            modelBuilder.Entity<Ins_Subject>()
                .HasKey(x => new { x.SubId, x.InsId });

            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(x => new { x.SubID, x.DepartmentID });

            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Department>()
                .HasOne(x => x.Instructor)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubjects> studentSubjects { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
