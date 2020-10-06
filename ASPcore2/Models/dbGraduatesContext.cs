using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPcore2.Models
{
    public partial class dbGraduatesContext : DbContext
    {
        public dbGraduatesContext()
        {
        }

        public dbGraduatesContext(DbContextOptions<dbGraduatesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityCountry> CityCountry { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentContact> StudentContact { get; set; }
        public virtual DbSet<StudentContactType> StudentContactType { get; set; }
        public virtual DbSet<StudentGroup> StudentGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.HasOne(d => d.CityCountry)
        //            .WithMany(p => p.City)
        //            .HasForeignKey(d => d.CityCountryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_City_CityCountry");
        //    });

        //    modelBuilder.Entity<CityCountry>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Currency>(entity =>
        //    {
        //        entity.Property(e => e.CurrencyName)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.CurrencySimbol)
        //            .IsRequired()
        //            .HasMaxLength(1);

        //        entity.Property(e => e.CurrencyValue).HasColumnType("money");
        //    });

        //    modelBuilder.Entity<Journal>(entity =>
        //    {
        //        entity.Property(e => e.Company)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.CurrencyId).HasDefaultjournalql("((1))");

        //        entity.Property(e => e.DateBegin).HasColumnType("date");

        //        entity.Property(e => e.DateEnd).HasColumnType("date");

        //        entity.Property(e => e.Position)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Salary).HasColumnType("money");

        //        entity.Property(e => e.Site).HasMaxLength(50);

        //        entity.HasOne(d => d.City)
        //            .WithMany(p => p.Journal)
        //            .HasForeignKey(d => d.CityId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_StudentJournal_City");

        //        entity.HasOne(d => d.Currency)
        //            .WithMany(p => p.Journal)
        //            .HasForeignKey(d => d.CurrencyId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_StudentJournal_Currency");

        //        entity.HasOne(d => d.Student)
        //            .WithMany(p => p.Journal)
        //            .HasForeignKey(d => d.StudentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_StudentJournal_Student");
        //    });

        //    modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.Property(e => e.BirthDate).HasColumnType("date");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Patronymic)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Surname)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.HasOne(d => d.StudentGroup)
        //            .WithMany(p => p.Student)
        //            .HasForeignKey(d => d.StudentGroupId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Student_StudentGroup");
        //    });

        //    modelBuilder.Entity<StudentContact>(entity =>
        //    {
        //        entity.Property(e => e.Value)
        //            .IsRequired()
        //            .HasMaxLength(150);

        //        entity.HasOne(d => d.Student)
        //            .WithMany(p => p.StudentContact)
        //            .HasForeignKey(d => d.StudentId)
        //            .HasConstraintName("FK_StudentContact_StudentContactType");
        //    });

        //    modelBuilder.Entity<StudentContactType>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Prefix)
        //            .IsRequired()
        //            .HasMaxLength(150)
        //            .HasDefaultjournalql("('')");
        //    });

        //    modelBuilder.Entity<StudentGroup>(entity =>
        //    {
        //        entity.Property(e => e.Answer)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(10);
        //    });
        //}
    }
}
