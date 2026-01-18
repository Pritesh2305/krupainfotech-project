using eventbookingmgmt.api.Helpers;
using eventbookingmgmt.api.Middleware;
using eventbookingmgmt.entities.Common;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.services.Implementation;
using eventbookingmgmt.services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace eventbookingmgmt.api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class mststateController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ImststateService _imststatesservice;
        private readonly IUserClientCodeService _UserClientCodeService;
        public mststateController(ImststateService imststatesservice, IUserClientCodeService userClientCodeService, IOptions<AppSettings> appSettings)
        {
            _imststatesservice = imststatesservice;
            _appSettings = appSettings.Value;
            _UserClientCodeService = userClientCodeService;
        }
        
        [HttpPost]
        [ActionName("Insert")]
        public IActionResult Insert([FromBody] mststateRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imststatesservice.Insert(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update([FromBody] mststateRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imststatesservice.Update(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody] DelRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imststatesservice.Delete(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

        [HttpGet]
        [ActionName("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            //var handler = new JwtSecurityTokenHandler();
            //string authHeader = Request.Headers["Authorization"] + "";
            //authHeader = authHeader.Replace("Bearer ", "");
            //var jsonToken = handler.ReadToken(authHeader);
            //var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            //var id = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "rid").Value);
            //var kiclientcode = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "kiclientcode").Value);
            ////var name = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "unique_name").Value);
            //var lastname = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "lastname").Value);
            //var utyperid = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "utyperid").Value);

            var res = _imststatesservice.GetAllDetails();
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

        [HttpGet]
        [ActionName("Getlist")]
        public IActionResult Getlist()
        {
            //var handler = new JwtSecurityTokenHandler();
            //string authHeader = Request.Headers["Authorization"] + "";
            //authHeader = authHeader.Replace("Bearer ", "");
            //var jsonToken = handler.ReadToken(authHeader);
            //var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            //var id = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "rid").Value);
            //var kiclientcode = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "kiclientcode").Value);
            ////var name = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "unique_name").Value);
            //var lastname = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "lastname").Value);
            //var utyperid = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "utyperid").Value);

            var res = _imststatesservice.GetList();
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

        [HttpGet("{Id:int}")]
        [ActionName("GetById")]
        public IActionResult GetById(Int64 Id)
        {
            var res = _imststatesservice.GetById(Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            else
            {
                return NotFound(res);
            }
        }

    }
}
