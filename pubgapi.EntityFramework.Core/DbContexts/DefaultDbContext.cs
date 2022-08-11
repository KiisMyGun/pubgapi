using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace pubgapi.EntityFramework.Core;

[AppDbContext("pubgapi", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
