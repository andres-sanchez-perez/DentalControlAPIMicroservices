using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microservicio.ActualizarProducto.Models
{
    public partial class DentalControlContext : DbContext
    {
        public DentalControlContext()
        {
        }

        public DentalControlContext(DbContextOptions<DentalControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Antecedente> Antecedentes { get; set; } = null!;
        public virtual DbSet<Calendario> Calendarios { get; set; } = null!;
        public virtual DbSet<Cirujium> Cirujia { get; set; } = null!;
        public virtual DbSet<Citum> Cita { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Historial> Historials { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Tratamiento> Tratamientos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI-DE-PIPE;Database=DentalControl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antecedente>(entity =>
            {
                entity.HasKey(e => e.AntecedentesId)
                    .HasName("PK_antecedentes_AntecedentesId");

                entity.ToTable("antecedentes");

                entity.HasIndex(e => e.PacienteId, "AntecedentesPacienteId_idx");

                entity.HasIndex(e => e.AntecedentesId, "antecedentes$AntecedentesId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Alergias).HasMaxLength(100);

                entity.Property(e => e.Enfermedades).HasMaxLength(100);

                entity.Property(e => e.Habitos).HasMaxLength(100);

                entity.Property(e => e.Motivo).HasMaxLength(100);

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Antecedentes)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("antecedentes$AntecedentesPacienteId");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.IdCalendario)
                    .HasName("PK_calendario_id_calendario");

                entity.ToTable("calendario");

                entity.HasIndex(e => e.IdCita, "FK_CitaCalendario_idx");

                entity.HasIndex(e => e.IdCalendario, "calendario$CalendarioID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCalendario).HasColumnName("id_calendario");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.IdCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("calendario$FK_CitaCalendario");

                entity.HasMany(d => d.IdDoctors)
                    .WithMany(p => p.IdCalendarios)
                    .UsingEntity<Dictionary<string, object>>(
                        "Calendariodoctor",
                        l => l.HasOne<Doctor>().WithMany().HasForeignKey("IdDoctor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("calendariodoctor$FK_id_doctor"),
                        r => r.HasOne<Calendario>().WithMany().HasForeignKey("IdCalendario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("calendariodoctor$FK_id_calendario"),
                        j =>
                        {
                            j.HasKey("IdCalendario", "IdDoctor").HasName("PK_calendariodoctor_id_calendario");

                            j.ToTable("calendariodoctor");

                            j.HasIndex(new[] { "IdDoctor" }, "FK_DoctorID_idx");

                            j.IndexerProperty<int>("IdCalendario").HasColumnName("id_calendario");

                            j.IndexerProperty<int>("IdDoctor").HasColumnName("id_doctor");
                        });
            });

            modelBuilder.Entity<Cirujium>(entity =>
            {
                entity.HasKey(e => e.CirujiaId)
                    .HasName("PK_cirujia_CirujiaId");

                entity.ToTable("cirujia");

                entity.HasIndex(e => e.AntecedenteId, "CirujiaAntecedenteID_idx");

                entity.HasIndex(e => e.PacienteId, "CirujiaPacienteID_idx");

                entity.Property(e => e.DoctorAcargo)
                    .HasMaxLength(100)
                    .HasColumnName("DoctorACargo");

                entity.Property(e => e.FechaCirujia).HasColumnType("date");

                entity.Property(e => e.NombreCirujia).HasMaxLength(100);

                entity.HasOne(d => d.Antecedente)
                    .WithMany(p => p.Cirujia)
                    .HasForeignKey(d => d.AntecedenteId)
                    .HasConstraintName("cirujia$CirujiaAntecedenteID");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Cirujia)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cirujia$CirujiaPacienteID");
            });

            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK_cita_id_cita");

                entity.ToTable("cita");

                entity.HasIndex(e => e.IdDoctor, "FK_CitaDoctorID_idx");

                entity.HasIndex(e => e.IdPaciente, "FK_Paciente_idx");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.Estado).HasMaxLength(45);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita$FK_CitaDoctorID");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita$FK_PacienteID");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK_doctor_id_doctor");

                entity.ToTable("doctor");

                entity.HasIndex(e => e.CorreoElectronico, "doctor$CorreoElectronico_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdDoctor, "doctor$DoctorID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NumCelular, "doctor$NumCelular_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Cedula).HasMaxLength(10);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(50);

                entity.Property(e => e.Especialidad).HasMaxLength(45);

                entity.Property(e => e.FechaNac).HasColumnType("date");

                entity.Property(e => e.Genero).HasMaxLength(45);

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.NumCelular).HasMaxLength(10);

                entity.Property(e => e.NumFijo).HasMaxLength(10);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento");

                entity.HasIndex(e => e.IdDoctor, "FK_Evento_id_doctor_idx");

                entity.HasIndex(e => e.IdCita, "FK_cita_evento_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .HasColumnName("descripcion");

                entity.Property(e => e.End)
                    .HasPrecision(0)
                    .HasColumnName("end");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.Start)
                    .HasPrecision(0)
                    .HasColumnName("start");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("evento$FK_cita_evento");
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.HasKey(e => e.IdHistorial)
                    .HasName("PK_historial_id_historial");

                entity.ToTable("historial");

                entity.HasIndex(e => e.IdPaciente, "FK_HistorialPacienteID_idx");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historial$FK_HistorialPacienteID");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK_inventario_id_inventario");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdInventario, "inventario$InventarioID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdInventario).HasColumnName("id_inventario");

                entity.Property(e => e.Medida).HasMaxLength(45);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(50);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK_paciente_id_paciente");

                entity.ToTable("paciente");

                entity.HasIndex(e => e.Cedula, "paciente$Cedula_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NumCelular, "paciente$NumCelular_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Cedula).HasMaxLength(10);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(50);

                entity.Property(e => e.DirDomicilio).HasMaxLength(100);

                entity.Property(e => e.FechaNac).HasPrecision(0);

                entity.Property(e => e.Genero).HasMaxLength(11);

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.NumCelular).HasMaxLength(10);

                entity.Property(e => e.NumFijo).HasMaxLength(7);
            });

            modelBuilder.Entity<Tratamiento>(entity =>
            {
                entity.HasKey(e => e.IdTratamiento)
                    .HasName("PK_tratamiento_id_tratamiento");

                entity.ToTable("tratamiento");

                entity.HasIndex(e => e.IdHistorial, "FK_HistorialID_idx");

                entity.HasIndex(e => e.IdTratamiento, "tratamiento$TratamientoID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.FormaPago).HasMaxLength(45);

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Tipo).HasMaxLength(45);

                entity.HasOne(d => d.IdHistorialNavigation)
                    .WithMany(p => p.Tratamientos)
                    .HasForeignKey(d => d.IdHistorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tratamiento$FK_HistorialID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.IdDoctor, "FK_User_id_doctor_idx");

                entity.HasIndex(e => e.CorreoElectronico, "user$correoElectronico_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "user$username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Rol).HasMaxLength(20);

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("user$FK_User_id_doctor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
