using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models
{

    public partial class ContributionManagementContext : DbContext
    {
        public ContributionManagementContext()
        {
        }

        public ContributionManagementContext(DbContextOptions<ContributionManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContributionHistory> ContributionHistories { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public virtual DbSet<GroupDetail> GroupDetails { get; set; }

        public virtual DbSet<MemberDetail> MemberDetails { get; set; }

        public virtual DbSet<MonthlyContribution> MonthlyContributions { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        public virtual DbSet<Program> Programs { get; set; }

        public virtual DbSet<Qualification> Qualifications { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<TransactionCategory> TransactionCategories { get; set; }

        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=BSOFT-28-D-1A;Database=Contribution_Management;User Id=sa;Password=sa;MultipleActiveResultSets=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContributionHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId).HasName("PK_ContributionHistory_HistoryId");

                entity.ToTable("ContributionHistory", tb => tb.HasTrigger("trg_UpdateContributionHistory"));

                entity.Property(e => e.Amount).HasColumnType("money");
                entity.Property(e => e.RevisedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contribution).WithMany(p => p.ContributionHistories)
                    .HasForeignKey(d => d.ContributionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contribut__Contr__49C3F6B7");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId).HasName("PK_Countries_CountryID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");
                entity.Property(e => e.Country1)
                    .HasMaxLength(56)
                    .IsUnicode(false)
                    .HasColumnName("Country");
                entity.Property(e => e.Iso2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ISO2");
                entity.Property(e => e.Iso3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ISO3");
            });

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_ExpenseCategory_CategoryID");

                entity.ToTable("ExpenseCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<GroupDetail>(entity =>
            {
                entity.HasKey(e => e.GroupId).HasName("PK_GroupDetails_GroupId");

                entity.Property(e => e.CreatedOn)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.GroupName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Slogan).IsUnicode(false);
                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberDetail>(entity =>
            {
                entity.HasKey(e => e.MemberId).HasName("PK_MemberDetails_MemberId");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(95)
                    .IsUnicode(false);
                entity.Property(e => e.AdressLine1)
                    .HasMaxLength(95)
                    .IsUnicode(false);
                entity.Property(e => e.City)
                    .HasMaxLength(35)
                    .IsUnicode(false);
                entity.Property(e => e.ContributionId).HasColumnName("ContributionID");
                entity.Property(e => e.CountryId).HasColumnName("CountryID");
                entity.Property(e => e.Email)
                    .HasMaxLength(62)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.GroupId).HasColumnName("GroupID");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.IsDelete).HasDefaultValue(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.OccupationId).HasColumnName("OccupationID");
                entity.Property(e => e.ProfileImg).IsUnicode(false);
                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
                entity.Property(e => e.QulificationId).HasColumnName("QulificationID");
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
                entity.Property(e => e.StateId).HasColumnName("StateID");
                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Contribution).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.ContributionId)
                    .HasConstraintName("FK_MemberDetails_MemberDetails");

                entity.HasOne(d => d.Country).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_MemberDetails_Countries");

                entity.HasOne(d => d.Group).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__MemberDet__Group__72C60C4A");

                entity.HasOne(d => d.Occupation).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK_MemberDetails_Occupation");

                entity.HasOne(d => d.Program).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_MemberDetails_Programs");

                entity.HasOne(d => d.Role).WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberDetails_Roles");
            });

            modelBuilder.Entity<MonthlyContribution>(entity =>
            {
                entity.HasKey(e => e.ContributionId).HasName("PK_MonthlyContribution_ContributionId");

                entity.ToTable("MonthlyContribution");

                entity.Property(e => e.Amount).HasColumnType("money");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.HasKey(e => e.OccupationId).HasName("PK_Occupation_OccupationId");

                entity.ToTable("Occupation");

                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Occupation1)
                    .IsUnicode(false)
                    .HasColumnName("Occupation");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.ProgramId).HasName("PK_Programs_ProgramId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ProgramName)
                    .HasMaxLength(120)
                    .IsUnicode(false);
                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.HasOne(d => d.Qualification).WithMany(p => p.Programs)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK__Programs__Qualif__693CA210");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasKey(e => e.QualificationId).HasName("PK_Qualification_QualificationID");

                entity.ToTable("Qualification");

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Qualification1)
                    .IsUnicode(false)
                    .HasColumnName("Qualification");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK_Roles_RoleId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Role1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId).HasName("PK_States_StateID");

                entity.Property(e => e.StateId).HasColumnName("StateID");
                entity.Property(e => e.CountryId).HasColumnName("CountryID");
                entity.Property(e => e.State1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("State");
                entity.Property(e => e.StateCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country).WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_States_Countries");
            });

            modelBuilder.Entity<TransactionCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_TransactionCategory_CategoryId");

                entity.ToTable("TransactionCategory");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TypeId).HasName("PK_TransactionType_TypeId");

                entity.ToTable("TransactionType");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}