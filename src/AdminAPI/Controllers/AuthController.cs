using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminAPI.Models;
using AdminAPI.Models.Inputs;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdminAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly JwtSettings _jwtSettings;

        public AuthController(DataContext dataContext, IOptions<JwtSettings> jwtSettings)
        {
            _dataContext = dataContext;
            _jwtSettings = jwtSettings?.Value;
        }

        [HttpPost("login")]
        public async Task<ApiResult> Login(LoginModel model)
        {
            var user = await _dataContext.Admins.SingleOrDefaultAsync(x => x.Email == model.Email && 
                                                                          EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == model.Password);

            if (user == null)
                return new ApiResult("invalid-credential", "Geçersiz giriş bilgisi.");
            
            #region JWT Token Generate

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("AccountId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            #endregion

            return new ApiResult("success", null, new { token = jwtToken, expires = token.ValidTo.ToString(CultureInfo.InvariantCulture) });
        }
    }
}