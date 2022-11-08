using Microsoft.EntityFrameworkCore;
using Viapos.LicenceManager.API.Data.Tables;

namespace Viapos.LicenceManager.API.Data
{
    public class LicenseContext:DbContext
    {
        public LicenseContext(DbContextOptions<LicenseContext> options):base(options)
        {

        }

       public DbSet<License> Licenses { get; set; }
       public DbSet<Module> Modules { get; set; }
       public DbSet<SystemInfo> SystemInfos { get; set; }
    }
}
