using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Viapos.LicenceManager.API.Data;

using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.LicenceInformations.Tables;
using Viapos.LicenceManager.LicenceInformations.Tools;

namespace Viapos.LicenceManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //www.google.com/api/lisence
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private LicenseContext _context;
        public LicenseController(LicenseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string GetLisence(Guid id)
        {
            APIResponseResult result = new APIResponseResult();

            if (_context.Licenses.Any(c => c.Id == id))
            {
                result.ReturnType = ReturnType.Confirm;
                result.value = JsonConvert.SerializeObject(
               _context.Licenses.FirstOrDefault(c => c.Id == id));
                return EncrpytionTools.Encyrpt(JsonConvert.SerializeObject(result));

            }
            else
            {
                result.ReturnType = ReturnType.Error;
                result.value = "LİSANS BULUNAMADI";
                return EncrpytionTools.Encyrpt(JsonConvert.SerializeObject(result));
            }

        }
        [HttpPost]
        public string LicenseAdd(string userLicense)
        {
            License license = JsonConvert.DeserializeObject<License>(EncrpytionTools.Decyrpt(userLicense));
            APIResponseResult result = new APIResponseResult();
            if (_context.Licenses.Any(c => c.Id == license.Id))
            {
                result.ReturnType = ReturnType.Error;
                result.value = "Gönderdiğiniz lisans veritabanında kayıtlıdır";
                return EncrpytionTools.Encyrpt(JsonConvert.SerializeObject(result));
            }
            else
            {
                _context.Licenses.Add(license);
                _context.SaveChanges();
                result.ReturnType = ReturnType.Confirm;
                result.value = "Lisans veritabanına kaydedildi";
                return EncrpytionTools.Encyrpt(JsonConvert.SerializeObject(result));
            }
        }
        [HttpPost]
        public string DemoLicense(string userLicense)
        {
            License license = CheckLicense(userLicense);
            APIResponseResult result = new APIResponseResult();
            if (license == null)
            {
                license = JsonConvert.DeserializeObject<License>(EncrpytionTools.Decyrpt(userLicense));
                _context.Licenses.Add(license);
                _context.SaveChanges();
                result.ReturnType = ReturnType.Confirm;
                result.value = $"Demo Lisansınız Başarı İle Oluşturuldu.{license.CreatedTime.AddDays(30).ToShortDateString()} Tarihine Kadar Kullanabilirsiniz";
            }
            else
            {
                if (license.CreatedTime.AddDays(30) < DateTime.Now)
                {
                    result.ReturnType = ReturnType.Error;
                    result.value = $"Demo Lisansınız Süresi {license.CreatedTime.AddDays(30).ToShortDateString()} Tarihinde Dolmuş";

                }
                else
                {
                    result.ReturnType = ReturnType.Confirm;
                    result.value = $"Demo Lisansınızı {license.CreatedTime.AddDays(30).ToShortDateString()} Tarihine Kadar Kullanabilirsiniz";

                }
            }
            return EncrpytionTools.Encyrpt(JsonConvert.SerializeObject(result));

        }
        private License CheckLicense(string userLicense)
        {
            License license = JsonConvert.DeserializeObject<License>(EncrpytionTools.Decyrpt(userLicense));
            List<SystemInfo> systemInfos = license.SystemInfos.ToList();
            License matchingLicense = _context.Licenses.Include(c => c.SystemInfos)
                .FirstOrDefault(c => c.SystemInfos.Intersect(systemInfos, new SystemInfoEquilityComparer()).Count() > 3);
            return matchingLicense;
        }
    }
}
