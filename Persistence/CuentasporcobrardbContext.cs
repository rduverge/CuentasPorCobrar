using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CuentasPorCobrar.Shared;

public partial class CuentasporcobrardbContext : DbContext
{
    public virtual DbSet<Document> Documents { get; set;}
    public CuentasporcobrardbContext()
    {
    }

    public CuentasporcobrardbContext(DbContextOptions<CuentasporcobrardbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cuentasporcobrardb;Username=postgres;Password=Euren002");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
