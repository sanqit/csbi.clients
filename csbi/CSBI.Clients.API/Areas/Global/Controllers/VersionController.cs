namespace CSBI.Clients.API.Areas.Global.Controllers
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller to check assembly version
    /// </summary>
    [Produces("application/json")]
    [Route("version")]
    public class VersionController : Controller
    {
        /// <summary>
        /// Method to get assembly version
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public IActionResult Version()
        {
            return Ok(new
            {
                Name = Assembly.GetEntryAssembly().GetName().Name,
                Version = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                ApiVersion = VersionSettings.V1
            });
        }
    }
}