using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
