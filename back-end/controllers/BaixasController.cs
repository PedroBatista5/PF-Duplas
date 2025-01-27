using Backend.Models;
using Backend.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaixasController : ControllerBase
    {
        private readonly BaixasService _baixasService;

        public BaixasController(BaixasService baixasService)
        {
            _baixasService = baixasService;
        }

        // Criar uma baixa
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Baixas baixa)
        {
            if (baixa == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _baixasService.CriarBaixaAsync(baixa);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Obter todas as baixas
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var baixas = await _baixasService.ObterTodasBaixasAsync();

            if (baixas == null || baixas.Count == 0)
            {
                return NotFound(new { Message = "Nenhuma baixa encontrada." });
            }

            return Ok(baixas);
        }

        // Obter uma baixa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var baixa = await _baixasService.ObterBaixaPorIdAsync(id);

            if (baixa == null)
            {
                return NotFound(new { Message = "Baixa não encontrada." });
            }

            return Ok(baixa);
        }

        // Atualizar uma baixa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Baixas baixa)
        {
            if (baixa == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _baixasService.AtualizarBaixaAsync(id, baixa);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Deletar uma baixa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _baixasService.DeletarBaixaAsync(id);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }
    }
}
