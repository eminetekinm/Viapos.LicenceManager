using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public ModuleTypeEnum ModuleTypeEnum { get; set; }
    }
}
