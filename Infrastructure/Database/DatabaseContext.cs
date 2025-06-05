using CC_API.Domain.Entities.Copy;
using CC_API.Domain.Entities.Printers;
using CC_API.Domain.Entities.Statements;
using Microsoft.EntityFrameworkCore;

namespace CC_API.Infrastructure.Database;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Copy> Copies => Set<Copy>();
    public DbSet<PrinterType> PrintersType => Set<PrinterType>();
    public DbSet<Printer> Printers => Set<Printer>();
    public DbSet<Statement> Statements => Set<Statement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Copy>(entity =>
        {
            entity.ToTable("tbl_copy");
        });

        modelBuilder.Entity<PrinterType>(entity =>
        {
            entity.ToTable("tbl_printerType");
        });

        modelBuilder.Entity<Printer>(entity =>
        {
            entity.ToTable("tbl_printer");
        });

        modelBuilder.Entity<Statement>(entity =>
        {
            entity.ToTable("tbl_statement");
        });
    }
}