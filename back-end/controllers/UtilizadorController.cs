using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly UtilizadorService _utilizadorService;

        public UtilizadorController(UtilizadorService utilizadorService)
        {
            _utilizadorService = utilizadorService;
        }

        // Endpoint de Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            // Verificar se o usuário existe pelo NSaude
            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.NSaude == loginModel.NSaude); // NSaude no lugar do email

            if (utilizador == null || !BCrypt.Net.BCrypt.Verify(loginModel.Password, utilizador.Passe)) // Verificar a senha
            {
                return Unauthorized(new { Message = "Credenciais inválidas." });
            }

            // Gerar token JWT
            var token = GenerateJwtToken(utilizador); // Função para gerar token JWT

            return Ok(new { Token = token });
        }

        // Função para gerar o token JWT (exemplo simplificado)
        private string GenerateJwtToken(Utilizador utilizador)
        {
            // Lógica para gerar o token JWT (pode usar o JWT Bearer com alguma biblioteca como System.IdentityModel.Tokens.Jwt)
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key"); // Substitua por uma chave secreta real
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, utilizador.NSaude.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginModel
    {
        public int NSaude { get; set; } // Número de Saúde
        public string Password { get; set; } // Senha
    }
}
