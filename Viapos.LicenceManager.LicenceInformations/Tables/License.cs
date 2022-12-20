using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class License
    {
        public License()
        {
            SystemInfos = new List<SystemInfo>();
            Modules = new List<Module>();
        }

        [Key]
        public Guid Id { get; set; }
        public LicenseType LicenseType { get; set; }
        public OnlineLicenseControl OnlineLicense { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Excutions { get; set; }

        [MaxLength(50),Required]
        public string UserName { get; set; }

        [MaxLength(100), Required]
        public string Company { get; set; }
        public int LicenseCount { get; set; }

        public ICollection<SystemInfo> SystemInfos { get; set; }
        public ICollection<Module> Modules { get; set; }
    }
}
