using DebugNpgsql.Entities;

using Microsoft.EntityFrameworkCore;

namespace DebugNpgsql;

public class MyDbContext : DbContext
{
    public DbSet<MyObject> MyObjects => Set<MyObject>();

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    { }
}
