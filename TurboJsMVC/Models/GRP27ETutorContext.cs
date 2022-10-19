using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TurboJsMVC.Models
{
    public partial class GRP27ETutorContext : DbContext
    {
        public GRP27ETutorContext()
        {
        }

        public GRP27ETutorContext(DbContextOptions<GRP27ETutorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assessment> Assessments { get; set; } = null!;
        public virtual DbSet<Attendence> Attendences { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<LoginHistory> LoginHistories { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<RemovedUser> RemovedUsers { get; set; } = null!;
        public virtual DbSet<StudentEnrollment> StudentEnrollments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sict-sql.mandela.ac.za;Initial Catalog=GRP27-ETutor;User ID=GRP27;Password=grp27-soit2022");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.Property(e => e.QuestionFiveA).HasMaxLength(150);

                entity.Property(e => e.QuestionFiveO).HasMaxLength(150);

                entity.Property(e => e.QuestionFiveQ).HasMaxLength(150);

                entity.Property(e => e.QuestionFourA).HasMaxLength(150);

                entity.Property(e => e.QuestionFourO).HasMaxLength(150);

                entity.Property(e => e.QuestionFourQ).HasMaxLength(150);

                entity.Property(e => e.QuestionOneA).HasMaxLength(150);

                entity.Property(e => e.QuestionOneO).HasMaxLength(150);

                entity.Property(e => e.QuestionOneQ).HasMaxLength(150);

                entity.Property(e => e.QuestionThreeA).HasMaxLength(150);

                entity.Property(e => e.QuestionThreeO).HasMaxLength(150);

                entity.Property(e => e.QuestionThreeQ).HasMaxLength(150);

                entity.Property(e => e.QuestionTwoA).HasMaxLength(150);

                entity.Property(e => e.QuestionTwoO).HasMaxLength(150);

                entity.Property(e => e.QuestionTwoQ).HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<Attendence>(entity =>
            {
                entity.ToTable("Attendence");

                entity.Property(e => e.Date).HasMaxLength(150);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Day).HasMaxLength(50);

                entity.Property(e => e.TimeEnd).HasMaxLength(50);

                entity.Property(e => e.TimeStart).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Duration).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.ToTable("LoginHistory");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Ip).HasMaxLength(50);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.Mark1).HasColumnName("Mark");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Message1).HasColumnName("Message");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<RemovedUser>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<StudentEnrollment>(entity =>
            {
                entity.ToTable("Student_Enrollment");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
