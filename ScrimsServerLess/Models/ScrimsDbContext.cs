using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScrimsServerLess.Models
{
    public partial class ScrimsDbContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Ciflags> Ciflags { get; set; }
        public virtual DbSet<Ciimage> Ciimage { get; set; }
        public virtual DbSet<CirefImage> CirefImage { get; set; }
        public virtual DbSet<CireleaseDoc> CireleaseDoc { get; set; }
        public virtual DbSet<Cistatus> Cistatus { get; set; }
        public virtual DbSet<ClearanceItem> ClearanceItem { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectAddress> ProjectAddress { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<ProjectUser> ProjectUser { get; set; }
        public virtual DbSet<ScrimsUser> ScrimsUser { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
    

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//            optionsBuilder.UseSqlServer(@"Server=scrims-test.cnxbhgiegzg3.us-west-1.rds.amazonaws.com,1234;Database=scrims-test;User Id=scrimsadmin;Password=Testpassword#2");
//        }
        public ScrimsDbContext(DbContextOptions<ScrimsDbContext> options)
                : base(options)

        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.AddressLine3).HasMaxLength(500);

                entity.Property(e => e.CareOf).HasMaxLength(500);

                entity.Property(e => e.City).HasColumnType("nchar(10)");

                entity.Property(e => e.Country).HasMaxLength(500);

                entity.Property(e => e.StateProvince).HasMaxLength(500);

                entity.Property(e => e.ZipPin).HasMaxLength(50);
            });

            modelBuilder.Entity<Ciflags>(entity =>
            {
                entity.HasKey(e => e.CiflagId)
                    .HasName("PK_CIFlags");

                entity.ToTable("CIFlags");

                entity.Property(e => e.CiflagId).HasColumnName("CIFlagID");

                entity.Property(e => e.Ciid).HasColumnName("CIID");

                entity.HasOne(d => d.Ci)
                    .WithMany(p => p.Ciflags)
                    .HasForeignKey(d => d.Ciid)
                    .HasConstraintName("FK_CIFlags_ClearanceItem");
            });

            modelBuilder.Entity<Ciimage>(entity =>
            {
                entity.ToTable("CIImage");

                entity.Property(e => e.CiimageId).HasColumnName("CIImageID");

                entity.Property(e => e.Ciid).HasColumnName("CIID");

                entity.Property(e => e.CiimageAddress)
                    .HasColumnName("CIImageAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.CiimageBlobId)
                    .HasColumnName("CIImageBlobID")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Ci)
                    .WithMany(p => p.Ciimage)
                    .HasForeignKey(d => d.Ciid)
                    .HasConstraintName("FK_CIImage_ClearanceItem");
            });

            modelBuilder.Entity<CirefImage>(entity =>
            {
                entity.ToTable("CIRefImage");

                entity.Property(e => e.CirefImageId).HasColumnName("CIRefImageID");

                entity.Property(e => e.Ciid).HasColumnName("CIID");

                entity.Property(e => e.CirefImageAddress)
                    .HasColumnName("CIRefImageAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.CirefImageBlobId)
                    .HasColumnName("CIRefImageBlobID")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Ci)
                    .WithMany(p => p.CirefImage)
                    .HasForeignKey(d => d.Ciid)
                    .HasConstraintName("FK_CIRefImage_ClearanceItem");
            });

            modelBuilder.Entity<CireleaseDoc>(entity =>
            {
                entity.ToTable("CIReleaseDoc");

                entity.Property(e => e.CireleaseDocId).HasColumnName("CIReleaseDocID");

                entity.Property(e => e.Ciid).HasColumnName("CIID");

                entity.Property(e => e.CireleaseDocAddress)
                    .HasColumnName("CIReleaseDocAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.CireleaseDocBlob)
                    .HasColumnName("CIReleaseDocBlob")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Ci)
                    .WithMany(p => p.CireleaseDoc)
                    .HasForeignKey(d => d.Ciid)
                    .HasConstraintName("FK_CIReleaseDoc_ClearanceItem");
            });

            modelBuilder.Entity<Cistatus>(entity =>
            {
                entity.ToTable("CIStatus");

                entity.Property(e => e.CistatusId).HasColumnName("CIStatusID");

                entity.Property(e => e.Cistatus1)
                    .HasColumnName("CIStatus")
                    .HasMaxLength(500);

                entity.Property(e => e.CistatusOrder).HasColumnName("CIStatusOrder");
            });

            modelBuilder.Entity<ClearanceItem>(entity =>
            {
                entity.HasKey(e => e.Ciid)
                    .HasName("PK_ClearanceItem");

                entity.Property(e => e.Ciid).HasColumnName("CIID");

                entity.Property(e => e.ArtistName).HasMaxLength(500);

                entity.Property(e => e.Ciname)
                    .HasColumnName("CIName")
                    .HasMaxLength(500);

                entity.Property(e => e.Cistatus).HasColumnName("CIStatus");

                entity.Property(e => e.CiuniqueId)
                    .HasColumnName("CIUniqueID")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.SceneNumber).HasMaxLength(50);

                entity.Property(e => e.ShootDate).HasColumnType("datetime");

                entity.Property(e => e.SubmittingDept).HasMaxLength(500);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Urlrefference).HasColumnName("URLRefference");

                entity.HasOne(d => d.CistatusNavigation)
                    .WithMany(p => p.ClearanceItem)
                    .HasForeignKey(d => d.Cistatus)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClearanceItem_CIStatus");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ClearanceItem)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ClearanceItem_ScrimsUser");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ClearanceItem)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ClearanceItem_Project");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectUniqueId)
                    .HasColumnName("ProjectUniqueID")
                    .HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.ReleaseTitle).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkingTitle)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WrapDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProjectAddress>(entity =>
            {
                entity.Property(e => e.ProjectAddressId)
                    .HasColumnName("ProjectAddressID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ProjectAddress)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ProjectAddress_Address");

                entity.HasOne(d => d.ProjectAddressNavigation)
                    .WithOne(p => p.ProjectAddress)
                    .HasForeignKey<ProjectAddress>(d => d.ProjectAddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProjectAddress_Project");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");

                entity.Property(e => e.ProjectStatus1)
                    .HasColumnName("ProjectStatus")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProjectUser>(entity =>
            {
                entity.Property(e => e.ProjectUserId).HasColumnName("ProjectUserID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectUser_Project");

                entity.HasOne(d => d.ProjectUserRoleNavigation)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.ProjectUserRole)
                    .HasConstraintName("FK_ProjectUser_UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProjectUser_ScrimsUser");
            });

            modelBuilder.Entity<ScrimsUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_ScrimsUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(500);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(500);

                entity.Property(e => e.LastName).HasMaxLength(500);

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("PhoneNO")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleName).HasMaxLength(500);
            });
        }
    }
}