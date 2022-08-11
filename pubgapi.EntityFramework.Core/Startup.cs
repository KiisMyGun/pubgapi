using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace pubgapi.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "pubgapi.Database.Migrations");
    }
}
