using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viapos.LicenceManager.LicenceInformations.Tools
{
    public static class Md5Hash
    {
        public static string HashMd5(string data)
        {
            using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] input = System.Text.Encoding.ASCII.GetBytes(data);
                byte[] hasBytes=md5.ComputeHash(input);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hasBytes.Length; i++)
                {
                    builder.Append(hasBytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}
