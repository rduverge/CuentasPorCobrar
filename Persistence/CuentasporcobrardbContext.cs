using Microsoft.EntityFrameworkCore;

namespace CuentasPorCobrar.Shared;

public partial class CuentasporcobrardbContext : DbContext
{
    public virtual DbSet<Document> Documents { get; set; } = null!; 
    public virtual DbSet<Customer> Customers { get; set; } = null!; 
    public virtual DbSet<Transaction> Transactions { get; set; } = null!;  
    public virtual DbSet<AccountingEntry> AccountingEntries { get; set; } = null!;  

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

        modelBuilder.Entity<Transaction>()
            .HasOne(c => c.Customer)
            .WithMany(t => t.Transactions);

        modelBuilder.Entity<Transaction>()
            .HasOne(d => d.Document)
            .WithMany(t => t.Transactions);



        modelBuilder.Entity<AccountingEntry>()
            .HasOne(c => c.Customer)
            .WithMany(a => a.AccountingEntries); 
       
        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
