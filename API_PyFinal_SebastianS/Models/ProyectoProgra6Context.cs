using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_PyFinal_SebastianS.Models;

public partial class ProyectoProgra6Context : DbContext
{
    public ProyectoProgra6Context()
    {
    }

    public ProyectoProgra6Context(DbContextOptions<ProyectoProgra6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblComentario> TblComentarios { get; set; }

    public virtual DbSet<TblMiembro> TblMiembros { get; set; }

    public virtual DbSet<TblMiembrosTarea> TblMiembrosTareas { get; set; }

    public virtual DbSet<TblProyecto> TblProyectos { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblTarea> TblTareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblComentario>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__TBL_Come__F1844958B2BF130C");

            entity.ToTable("TBL_Comentario");

            entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.TareaId).HasColumnName("TareaID");

            entity.HasOne(d => d.Miembro).WithMany(p => p.TblComentarios)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Comen__Miemb__18EBB532");

            entity.HasOne(d => d.Tarea).WithMany(p => p.TblComentarios)
                .HasForeignKey(d => d.TareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Comen__Tarea__17F790F9");
        });

        modelBuilder.Entity<TblMiembro>(entity =>
        {
            entity.HasKey(e => e.MiembroId).HasName("PK__TBL_Miem__CC213FB9336D0A05");

            entity.ToTable("TBL_Miembro");

            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.TblMiembros)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__RolID__114A936A");
        });

        modelBuilder.Entity<TblMiembrosTarea>(entity =>
        {
            entity.HasKey(e => e.MiembTareaId).HasName("PK__TBL_Miem__B86592EEE3D7EBFE");

            entity.ToTable("TBL_Miembros_Tarea");

            entity.Property(e => e.MiembTareaId)
                .ValueGeneratedNever()
                .HasColumnName("MiembTareaID");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");

            entity.HasOne(d => d.Miembro).WithMany(p => p.TblMiembrosTareas)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__Miemb__14270015");

            entity.HasOne(d => d.Tarea).WithMany(p => p.TblMiembrosTareas)
                .HasForeignKey(d => d.TareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Miemb__Tarea__151B244E");
        });

        modelBuilder.Entity<TblProyecto>(entity =>
        {
            entity.HasKey(e => e.ProyectoId).HasName("PK__TBL_Proy__CF241D45DE4270C6");

            entity.ToTable("TBL_Proyecto");

            entity.Property(e => e.ProyectoId).HasColumnName("ProyectoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__TBL_Rol__F92302D1CCDB9B08");

            entity.ToTable("TBL_Rol");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__TBL_Tare__5CD836711CDC5E14");

            entity.ToTable("TBL_Tareas");

            entity.Property(e => e.TareaId).HasColumnName("TareaID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.Proyecto).WithMany(p => p.TblTareas)
                .HasForeignKey(d => d.ProyectoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_Tarea__Proye__0E6E26BF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
