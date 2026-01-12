using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eventbookingmgmt.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class myTestController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [ActionName("Test")]
        public IActionResult Test()
        {
            return Content("CONGRATULATIONS, API INSTALL & RUNNING SUCCESSFULLY.");
        }
    }
}
