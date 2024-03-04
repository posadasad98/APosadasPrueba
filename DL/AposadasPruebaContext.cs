using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class AposadasPruebaContext : DbContext
{
    public AposadasPruebaContext()
    {
    }

    public AposadasPruebaContext(DbContextOptions<AposadasPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=APosadasPrueba; Trusted_Connection=True; User ID=sa; Password=pass@word1; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__B450643AC2A6B8BA");

            entity.ToTable("Status");

            entity.Property(e => e.EstadoStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE909828AB102B");

            entity.ToTable("Tarea");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechadeVencimiento).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__Tarea__IdStatus__1B0907CE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF977BB3A183");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("FK__Usuario__IdTarea__1DE57479");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
