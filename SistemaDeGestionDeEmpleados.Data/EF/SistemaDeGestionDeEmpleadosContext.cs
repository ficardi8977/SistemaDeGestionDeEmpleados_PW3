using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGestionDeEmpleados.Data.EF;

public partial class SistemaDeGestionDeEmpleadosContext : DbContext
{
    public SistemaDeGestionDeEmpleadosContext()
    {
    }

    public SistemaDeGestionDeEmpleadosContext(DbContextOptions<SistemaDeGestionDeEmpleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SistemaDeGestionDeEmpleados;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E727A44E0");

            entity.ToTable("Empleado");

            entity.Property(e => e.NombreCompleto).HasMaxLength(100);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Sucursal");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__BFB6CD9994365C86");

            entity.ToTable("Sucursal");

            entity.Property(e => e.Direccion).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
