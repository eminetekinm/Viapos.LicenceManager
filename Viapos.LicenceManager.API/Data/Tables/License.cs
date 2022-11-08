using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.API.Data.Tables
{
    public class License
    {
        public License()
        {
            SystemInfos = new List<SystemInfo>();
            Modules = new List<Module>();
        }
        public Guid Id { get; set; }
        public LicenseType LicenseType { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public int LicenseCount { get; set; }

        public List<SystemInfo> SystemInfos { get; set; }
        public List<Module> Modules { get; set; }
    }
}
