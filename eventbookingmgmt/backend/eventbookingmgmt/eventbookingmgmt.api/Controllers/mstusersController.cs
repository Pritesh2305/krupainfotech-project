using eventbookingmgmt.api.Helpers;
using eventbookingmgmt.api.Middleware;
using eventbookingmgmt.entities.RequestDto;
using eventbookingmgmt.services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eventbookingmgmt.api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class mstusersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly ImstusersService _imstusersservice;
        private readonly IUserClientCodeService _UserClientCodeService;
        public mstusersController(ImstusersService imstusersservice, IUserClientCodeService userClientCodeService, IOptions<AppSettings> appSettings)
        {
            _imstusersservice = imstusersservice;
            _appSettings = appSettings.Value;
            _UserClientCodeService = userClientCodeService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {

            //var userClientCodeService = serviceProvider.GetRequiredService<IUserClientCodeService>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _imstusersservice.Login(model);
            string t_clientcode = _UserClientCodeService.ClientCode + "";

            if (res.ISuccess)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                string nm1 = res.Data?.firstname + "".Trim();
                string rid1 = res.Data?.rid + "".Trim();
                string lnm1 = res.Data?.lastname + "".Trim();
                string utype1 = res.Data?.usertyperid + "".Trim();
                //string fn = clscommonFunction.EncryptString(clscommonFunction.GENSECERTKEY, res.Data.firstname + "");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                     {
                     new Claim(ClaimTypes.Name, (CommonFunction.EncryptString(CommonFunction.GENSECERTKEY, nm1))),
                     new Claim("kiclientcode", (CommonFunction.EncryptString(CommonFunction.GENSECERTKEY,(t_clientcode+"")))),
                     new Claim("rid",  (CommonFunction.EncryptString(CommonFunction.GENSECERTKEY, (rid1)))),
                     new Claim("lastname", (CommonFunction.EncryptString(CommonFunction.GENSECERTKEY,(lnm1)))),
                     new Claim("utyperid", (CommonFunction.EncryptString(CommonFunction.GENSECERTKEY,(utype1))))
                     }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new
                            SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                res.Data.clientcode = t_clientcode+"".Trim();
                res.Data.token = tokenHandler.WriteToken(token);

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
            var res = _imstusersservice.GetById(Id);
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
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"] + "";
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            var id = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "rid").Value);
            var kiclientcode = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "kiclientcode").Value);
            //var name = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "unique_name").Value);
            var lastname = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "lastname").Value);
            var utyperid = CommonFunction.DecryptString(CommonFunction.GENSECERTKEY, tokenS.Claims.First(claim => claim.Type == "utyperid").Value);
                       

            var res = _imstusersservice.GetAll();
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
