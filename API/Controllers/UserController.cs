using businessLogic.Interface;
using businessLogic.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks.Dataflow;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using System.Text;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserBL _userBL) : ControllerBase
    {
        private readonly IUserBL userBL = _userBL;
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetUser(string username, string password)
        {
            var result = userBL.GetByNamePassword(username, password);
            if (result == null)
            {
                return  BadRequest();
            }
            else
            {
                return new ObjectResult(GenrateToek(result));
            }
        }
        private  dynamic GenrateToek(UsersUI user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name ,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                //you can change as you need 
                new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };
            var token = new JwtSecurityToken
                (
                new JwtHeader
                (
                    new SigningCredentials(new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("MySecretKeyIsSecretsoDon'tTellAnyOnePlease")),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            var output = new
            {
                Access_Token =new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName
            };
            return output;
        }
    }
}
