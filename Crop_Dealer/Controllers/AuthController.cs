using Crop_Dealer.Model;
using Crop_Dealer.Repository.AdminUser;
using Crop_Dealer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationServices _authenticationService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IConfiguration configuration, ILogger<AuthController> logger,AuthenticationServices authenticationServices)
        {
            _configuration = configuration;
            _logger = logger;
            _authenticationService = authenticationServices;
        }

        [HttpPost("Farmer_Login")]
        public IActionResult FarmerLogin(LoginData loginData)
        {
            try
            {
                var existingUser = _authenticationService.FarmerLoginService(loginData.email, loginData.password);
                if (existingUser == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, existingUser.FarmerId.ToString()),
                new Claim(ClaimTypes.Role,"Farmer")
                };
                _logger.LogInformation("Generating Token");
                var token = GenerateJwtToken(claims);
                return Ok(new { token});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Content(ex.Message);
            }
        }
        [HttpPost("Dealer_Login")]
        public IActionResult DealerLogin(LoginData loginData)
        {
            try
            {
                var existingUser = _authenticationService.DealerLoginService(loginData.email, loginData.password);
                if (existingUser == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, existingUser.DealerId.ToString()),
                new Claim(ClaimTypes.Role,"Dealer")
                };
                _logger.LogInformation("Generating Token");
                var token = GenerateJwtToken(claims);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Content(ex.Message);
            }
        }
        [HttpPost("Admin_Login")]
        public IActionResult AdminLogin(LoginData loginData)
        {
            try
            {
                var existingUser = _authenticationService.AdminLoginService(loginData.email, loginData.password);
                if (existingUser == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, existingUser.AdminId.ToString()),
                new Claim(ClaimTypes.Role,"Admin")
                };
                _logger.LogInformation("Generating Token");
                var token = GenerateJwtToken(claims);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Content(ex.Message);
            }
        }
        private string GenerateJwtToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
