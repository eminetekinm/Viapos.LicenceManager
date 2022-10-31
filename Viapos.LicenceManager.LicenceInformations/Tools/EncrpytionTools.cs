using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Viapos.LicenceManager.LicenceInformations.Tools
{
    public static class EncrpytionTools
    {
        private const string masterKey = "adsf";
        public static string Encyrpt(string data)
        {
            byte[] encyrptData = Encoding.UTF8.GetBytes(data);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(masterKey));
                using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(encyrptData,0,encyrptData.Length);
                    return Convert.ToBase64String(result,0,result.Length);
                }
            }
        }
        public static string Decyrpt(string data)
        {
            try
            {
                byte[] decyrptData = Convert.FromBase64String(data);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(masterKey));
                    using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
                    {
                        Key = keys,
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    })
                    {
                        ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor();
                        byte[] result = transform.TransformFinalBlock(decyrptData, 0, decyrptData.Length);
                        return Encoding.UTF8.GetString(result);
                    }
                }
            }
            catch (Exception)
            {

               return null;
            }
            
        }
    }
}
