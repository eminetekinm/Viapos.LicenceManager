using Microsoft.EntityFrameworkCore;
using Viapos.LicenceManager.LicenceInformations.Tables;

namespace Viapos.LicenceManager.API.Data
{
    public class LicenseContext:DbContext
    {
        public LicenseContext(DbContextOptions<LicenseContext> options):base(options)
        {

        }

       public DbSet<License> Licenses { get; set; }
    }
}
