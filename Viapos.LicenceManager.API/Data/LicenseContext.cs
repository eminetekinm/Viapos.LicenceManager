using Microsoft.EntityFrameworkCore;
using Viapos.LicenceManager.LicenceInformations.Tables;

namespace Viapos.LicenceManager.API.Data
{
    public class LicenseContext:DbContext
    {
        public LicenseContext(DbContextOptions<LicenseContext> options):base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

       public DbSet<License> Licenses { get; set; }
       public DbSet<Module> Modules { get; set; }
       public DbSet<SystemInfo> SystemInfos { get; set; }
    }
}
