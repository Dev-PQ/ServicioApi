using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ServicioApi.BusinessObjects.Seguridad;
using ServicioApi.Facade.Seguridad;
using System.Data;
using ServicioApi.JWT.Services;

namespace ServicioApi.JWT.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly JwtService _jwtService;
        public UserLoginController(IConfiguration config, JwtService jwtService)
        {
            _config = config;
            _jwtService = jwtService;
        }

        [Route("login/{Usuario}/{Password}")]
        [HttpGet()]
        public async Task<String> Login(String Usuario, String Password)
        {
            try
            {
                // Validación simple
                ConexionWCF conexionWCF = new ConexionWCF(new HttpClient(), _config);
                String Estado = await conexionWCF.loginConexion(Usuario, Password);
                if (Estado!=null)
                {

                    var token = _jwtService.GenerateToken(Usuario);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        /*private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            JwtKeyGeneratorService jwtKeyGeneratorService = new JwtKeyGeneratorService();
            string claveSegura = jwtKeyGeneratorService.GenerateSecureKey();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveSegura));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
    }
}
