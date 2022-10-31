using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Viapos.LicenceManager.LicenceInformations.Tables;

namespace Viapos.LicenceManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //www.google.com/api/lisence
    [ApiController]
    public class LicenseController : ControllerBase
    {
        [HttpGet]
        public string GetLisence()
        {
            License license = new License
            {
                Id = Guid.NewGuid(),
                UserName = "Emine",
                Company="Viapos Yazılım",

            };
          return  JsonConvert.SerializeObject(license);

        }
    }
}
