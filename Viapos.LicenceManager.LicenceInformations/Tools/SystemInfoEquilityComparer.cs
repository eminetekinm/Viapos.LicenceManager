using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viapos.LicenceManager.LicenceInformations.Tables;

namespace Viapos.LicenceManager.LicenceInformations.Tools
{
    public class SystemInfoEquilityComparer : IEqualityComparer<SystemInfo>
    {
        public bool Equals(SystemInfo x, SystemInfo y)
        {
            if (string.Equals(x.Info,y.Info) && x.InfoType==y.InfoType)
            {
                return true;
            }
            return false;
        }
       
        public int GetHashCode(SystemInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
