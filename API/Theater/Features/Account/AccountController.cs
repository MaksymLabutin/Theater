using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Theater.WebApi.Auth;
using Theater.WebApi.Features.Account.Dtos;
using Theater.WebApi.Models;

namespace Theater.WebApi.Features.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    { 
        //todo move to the DB
        private readonly List<Person> _people = new List<Person>
        {
            new Person {Login="admin@admin.com", Password="admin", Role = "admin" },
            new Person { Login="test@test.com", Password="test", Role = "user" }
        };
         
        //todo move to the handler
        [HttpPost]
        public IActionResult LoginAsync([FromBody] PersonDto dto)
        {
            var identity = GetIdentity(dto.UserName, dto.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
             
            var response = new
            {
                token = encodedJwt,
                username = identity.Name,
                //todo userManager
                isAdmin = _people.First(_ => _.Login == identity.Name).Role.ToLower() == "admin"
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = _people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }


    }
}