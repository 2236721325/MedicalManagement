using Base.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using UserManagement.Service.Dtos;
using UserManagement.Service.IServices;
using UserManagement.WebAPI.Settings;

namespace UserManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly JWTSettings jwtSettings;

        public UserController(IUserService userService, IOptions<JWTSettings> jwtSettings)
        {
            _UserService = userService;
            this.jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        public async Task<ApiResult> RegisteAsync(UserRegisteDto dto)
        {
           return await _UserService.RegisteAsync(dto);
        }

        [HttpPost]
        public async Task<ApiResult<string>> LoginAsync(UserLoginDto dto)
        {
            var result = await _UserService.LoginAsync(dto);
            if (!result.Status)
            {
                return ApiResult.OhNo<string>(result.Message);
            }
            // 1 定义需要的Cliam信息
            List<Claim> claims = new List<Claim>()//不要放太多东西 数据的传输也是耗时的
            {
                new Claim(ClaimTypes.NameIdentifier, result.Result.Id.ToString())
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer: jwtSettings.Issuer, audience: jwtSettings.Audience, claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return ApiResult.Ok<string>(jwt);
        }
    }

}