using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class SystemInfo
    {

        [Key]
        public Guid Id { get; set; }
        [ForeignKey("License")]
        public Guid LicenseId { get; set; }
        public SystemInfoEnum InfoType  { get; set; }

        [MaxLength(32),Required]
        public string Info { get; set; }
    }
}
