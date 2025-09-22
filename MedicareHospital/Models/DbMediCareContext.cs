using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MedicareHospital.Models;

public partial class DbMediCareContext : DbContext
{
    public DbMediCareContext()
    {
    }

    public DbMediCareContext(DbContextOptions<DbMediCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
        var connectionString = configuration.GetConnectionString("DBDefault");
        optionsBuilder.UseSqlServer(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments", "dbo");
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2637097EF");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.AppointmentDate);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__29572725");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__286302EC");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctors", "dbo");
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EDFC1869315");

            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.DoctorCode).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Specialization).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patients", "dbo");
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346BDD678C8");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PatientCode).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
