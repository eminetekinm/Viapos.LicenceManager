using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.API.Data.Tables
{
    public class SystemInfo
    {
        [Key]
        public Guid Id { get; set; }
        public SystemInfoEnum InfoType  { get; set; }
        public string Info { get; set; }
    }
}
