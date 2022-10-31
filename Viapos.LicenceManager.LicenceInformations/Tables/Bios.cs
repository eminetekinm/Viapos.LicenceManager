using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class Bios
    {
        public string SMBIOSBIOSVersion { get; set; }
        public string Caption { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
