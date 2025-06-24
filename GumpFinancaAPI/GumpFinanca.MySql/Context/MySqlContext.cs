using GumpFinanca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GumpFinanca.MySql.Context;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Transaction> Transactions { get; set; }
}