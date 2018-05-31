using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskBoard.Models
{
    public partial class TaxBackCompanyContext : DbContext
    {
        public TaxBackCompanyContext()
        {
        }

        public TaxBackCompanyContext(DbContextOptions<TaxBackCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskAssignment> TaskAssignment { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=WINDOWS-SGMD1NE\\SQLEXPRESS;Database=TaxBack Company;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.NextActionDate).HasColumnType("date");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskId");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.NextActionDate).HasColumnType("date");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskStatusId");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskTypeId");
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.UserId });
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.HasIndex(e => e.Status)
                    .HasName("Status_Unique")
                    .IsUnique();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasIndex(e => e.Type)
                    .HasName("Type_Unique")
                    .IsUnique();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("Email_Unique")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
