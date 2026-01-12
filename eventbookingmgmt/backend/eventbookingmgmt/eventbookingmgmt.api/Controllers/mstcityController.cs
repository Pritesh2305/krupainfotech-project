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
using System.IdentityModel.Tokens.Jwt;

namespace eventbookingmgmt.api.Controllers
{

    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class mstcityController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ImstcityService _imstcitysservice;
        private readonly IUserClientCodeService _UserClientCodeService;
        public mstcityController(ImstcityService imstcitysservice, IUserClientCodeService userClientCodeService, IOptions<AppSettings> appSettings)
        {
            _imstcitysservice = imstcitysservice;
            _appSettings = appSettings.Value;
            _UserClientCodeService = userClientCodeService;

        }

        [HttpPost]
        [ActionName("Insert")]
        public IActionResult Insert([FromBody] mstcityRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imstcitysservice.Insert(viewModel);
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
        public IActionResult Update([FromBody] mstcityRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imstcitysservice.Update(viewModel);
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
            var res = _imstcitysservice.Delete(viewModel);
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
        [ActionName("GetlistDetails")]
        public IActionResult GetlistDetails()
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


            var res = _imstcitysservice.GetlistDetails();
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


            var res = _imstcitysservice.GetAllDetails();
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


            var res = _imstcitysservice.Getlist();
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
        [ActionName("GetAll")]
        public IActionResult GetAll()
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


            var res = _imstcitysservice.GetAll();
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
            var res = _imstcitysservice.GetById(Id);
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
