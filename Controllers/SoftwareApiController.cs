using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SoftwareVersion.Extensions;

namespace SoftwareVersion.Controllers
{
    [Route("api/software")]
    [ApiController]
    public class SoftwareApi : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult GetSoftware(string version)
        {
            var software = SoftwareManager.GetAllSoftware()
                .Where(x => x.Version.IsGreaterThan(version));
                
            return Ok(software);
        }
    }
}