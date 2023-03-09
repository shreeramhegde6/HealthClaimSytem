using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HealthClaimApp.Models
{
    public partial class HealthclaimAppContext : DbContext
    {
        public HealthclaimAppContext()
        {
        }

        public HealthclaimAppContext(DbContextOptions<HealthclaimAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblClaim> TblClaims { get; set; }
        public virtual DbSet<TblClaimType> TblClaimTypes { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }
        public virtual DbSet<TblMember> TblMembers { get; set; }
        public virtual DbSet<TblPhysician> TblPhysicians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HealthclaimApp;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("tblClaim");



                entity.Property(e => e.ClaimAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ClaimDate).HasColumnType("datetime");

                entity.Property(e => e.ClaimRemark).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimType)
                    .WithMany(p => p.TblClaims)
                    .HasForeignKey(d => d.ClaimTypeId)
                    .HasConstraintName("FK_tblClaim_tblClaimType");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblClaims)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblClaim_tblMember1");
            });

            modelBuilder.Entity<TblClaimType>(entity =>
            {
                entity.HasKey(e => e.ClaimTypeId);

                entity.ToTable("tblClaimType");

                entity.Property(e => e.ClaimTypeValue).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("tblLogin");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserRole).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_tblLoginn");

                entity.ToTable("tblMember");



                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.TblMembers)
                    .HasForeignKey(d => d.PhysicianId)
                    .HasConstraintName("FK_tblMember_tblPhysician");
            });

            modelBuilder.Entity<TblPhysician>(entity =>
            {
                entity.HasKey(e => e.PhysicianId);

                entity.ToTable("tblPhysician");

                entity.Property(e => e.PhysicianName).HasMaxLength(50);

                entity.Property(e => e.PhysicianState).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
