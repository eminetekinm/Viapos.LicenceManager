using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class LicenseInfo
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public int LicenseCount { get; set; }
    }
}
