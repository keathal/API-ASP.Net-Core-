using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace ASPcore2.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Index()
        {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                var creditValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernamenpasswordEnc = Encoding.UTF8.GetString(Convert.FromBase64String(creditValue));
                var usernamenpassword = usernamenpasswordEnc.Split(":");
                if (usernamenpassword[0] == "admin" && usernamenpassword[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, "username") };
                    Random random = new Random();
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hbkhjbgkjbhdsbh" + new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890123456789", 3)
              .Select(s => s[random.Next(s.Length)]).ToArray())));
                    var signCredit = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                        issuer: "testhost.com",
                        audience: "testhost.com",
                        expires: DateTime.Now.AddMinutes(30),
                        claims: claimsdata,
                        signingCredentials: signCredit);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString);
                }
            }
            return BadRequest("wrong request");
        }
    }
}