using Furion;
using Furion.DatabaseAccessor;

using Microsoft.Extensions.DependencyInjection;

namespace pubgapi.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>($"{DbProvider.MySql}@8.0.22");
        }, "pubgapi.Database.Migrations");
    }
}