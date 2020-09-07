using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentApp_DataAccessLayer.Models
{
    public partial class StudentDatabaseContext : DbContext
    {
        public StudentDatabaseContext()
        {
        }

        public StudentDatabaseContext(DbContextOptions<StudentDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentResults> StudentResults { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=APAC-002-L00700;Database=StudentDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<StudentResults>(entity =>
            {
                entity.HasKey(e => e.ResultId)
                    .HasName("PK__StudentR__9769020852951FD2");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52B990A5F4EA6");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
