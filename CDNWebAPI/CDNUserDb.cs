using Microsoft.EntityFrameworkCore;

class CDNUserDb : DbContext
{
    public CDNUserDb(DbContextOptions<CDNUserDb> options)
        : base(options) { }

    public DbSet<CDNUser> CDNUsers => Set<CDNUser>();
}