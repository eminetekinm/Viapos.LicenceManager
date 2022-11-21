using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Enum;

namespace Viapos.LicenceManager.LicenceInformations.Tables
{
    public class APIResponseResult
    {
        public ReturnType ReturnType { get; set; }
        public object value { get; set; }
    }
}
