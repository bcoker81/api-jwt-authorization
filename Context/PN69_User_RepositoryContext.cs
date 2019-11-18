using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoleBasedAuthentication.Domain;

namespace RoleBasedAuthentication.Context
{
    public partial class PN69_User_RepositoryContext : DbContext
    {
        public PN69_User_RepositoryContext()
        {
        }

        public PN69_User_RepositoryContext(DbContextOptions<PN69_User_RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<CoreUser> CoreUser { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<Le> Le { get; set; }
        public virtual DbSet<LoginManagement> LoginManagement { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistory { get; set; }
        public virtual DbSet<Supplemental> Supplemental { get; set; }

        public virtual DbSet<Configurations> Configurations { get; set; }

        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                 optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PN69_User_Repository;Trusted_Connection=True;");
        //             }
        //         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "auth");

                entity.Property(e => e.AccountActive).HasColumnName("Account_Active");

                entity.Property(e => e.AccountFailedCount).HasColumnName("Account_Failed_Count");

                entity.Property(e => e.AccountLocked).HasColumnName("Account_Locked");

                entity.Property(e => e.AccountLockoutDate).HasColumnName("Account_Lockout_Date");

                entity.Property(e => e.EmailVerified).HasColumnName("Email_Verified");

                entity.Property(e => e.FkCoreUserId).HasColumnName("FK_Core_User_Id");

                entity.Property(e => e.HashedPassword).HasMaxLength(1024);

                entity.Property(e => e.InactiveDate).HasColumnName("Inactive_Date");

                entity.HasOne(d => d.FkCoreUser)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.FkCoreUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Account_FK_Core_User_to_Core_User_Id");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.ToTable("Contacts", "user");

                entity.Property(e => e.FkCoreUserId).HasColumnName("FK_Core_User_Id");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCoreUser)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.FkCoreUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Contacts_FK_Core_User_to_Core_User_Id");
            });

            modelBuilder.Entity<CoreUser>(entity =>
            {
                entity.ToTable("Core_User", "user");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_Of_Birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.Last4Ssn)
                    .HasColumnName("Last_4_SSN")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.ToTable("Configurations", "cnf");
                entity.Property(e => e.Id)
                .HasColumnName("Id");

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(50);

                entity.Property(e => e.Value)
                .HasColumnName("Value")
                .HasMaxLength(250);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("Employer", "user");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkCoreUserId).HasColumnName("FK_Core_User_Id");

                entity.Property(e => e.SupervisorCoreId)
                    .HasColumnName("Supervisor_Core_Id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TitleCode)
                    .HasColumnName("Title_Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TitleDescription)
                    .HasColumnName("Title_Description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Troop).HasMaxLength(1);

                entity.HasOne(d => d.FkCoreUser)
                    .WithMany(p => p.Employer)
                    .HasForeignKey(d => d.FkCoreUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Employer_FK_Core_User_to_Core_User_Id");
            });

            modelBuilder.Entity<Le>(entity =>
            {
                entity.ToTable("LE", "user");

                entity.Property(e => e.BadgeNumber)
                    .HasColumnName("Badge_Number")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FkCoreUserId).HasColumnName("FK_Core_User_Id");

                entity.Property(e => e.OfficialDomicile)
                    .HasColumnName("Official_Domicile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rank)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCoreUser)
                    .WithMany(p => p.Le)
                    .HasForeignKey(d => d.FkCoreUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_LE_FK_Core_User_to_Core_User_Id");
            });

            modelBuilder.Entity<LoginManagement>(entity =>
            {
                entity.ToTable("Login_Management", "auth");

                entity.Property(e => e.LockoutTimePeriodHours)
                    .HasColumnName("Lockout_Time_Period_Hours")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumberOfAllowedFailedAttempts)
                    .HasColumnName("Number_Of_Allowed_Failed_Attempts")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.PasswordChangeFrequencyDays)
                    .HasColumnName("Password_Change_Frequency_Days")
                    .HasDefaultValueSql("((90))");

                entity.Property(e => e.PasswordRetentionCount)
                    .HasColumnName("Password_Retention_Count")
                    .HasDefaultValueSql("((10))");
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.ToTable("Password_History", "auth");

                entity.Property(e => e.FkCoreUserId).HasColumnName("Fk_Core_User_Id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplemental>(entity =>
            {
                entity.ToTable("Supplemental", "user");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkCoreUserId).HasColumnName("FK_Core_User_Id");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCoreUser)
                    .WithMany(p => p.Supplemental)
                    .HasForeignKey(d => d.FkCoreUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Supplemental_FK_Core_User_to_Core_User_Id");
            });
        }
    }
}
