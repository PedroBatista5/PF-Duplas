using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // Criar um paciente
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _pacienteService.CriarPacienteAsync(paciente);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Obter todos os pacientes
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteService.ObterTodosPacientesAsync();

            if (pacientes == null || pacientes.Count == 0)
            {
                return NotFound(new { Message = "Nenhum paciente encontrado." });
            }

            return Ok(pacientes);
        }

        // Obter um paciente por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteService.ObterPacientePorIdAsync(id);

            if (paciente == null)
            {
                return NotFound(new { Message = "Paciente não encontrado." });
            }

            return Ok(paciente);
        }

        // Atualizar um paciente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _pacienteService.AtualizarPacienteAsync(id, paciente);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Deletar um paciente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _pacienteService.DeletarPacienteAsync(id);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }
    }
}
