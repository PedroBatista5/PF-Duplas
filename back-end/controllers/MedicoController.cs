using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // Criar um médico
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Medico medico)
        {
            if (medico == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _medicoService.CriarMedicoAsync(medico);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Obter todos os médicos
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _medicoService.ObterTodosMedicosAsync();

            if (medicos == null || medicos.Count == 0)
            {
                return NotFound(new { Message = "Nenhum médico encontrado." });
            }

            return Ok(medicos);
        }

        // Obter um médico por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medico = await _medicoService.ObterMedicoPorIdAsync(id);

            if (medico == null)
            {
                return NotFound(new { Message = "Médico não encontrado." });
            }

            return Ok(medico);
        }

        // Atualizar um médico
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medico medico)
        {
            if (medico == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _medicoService.AtualizarMedicoAsync(id, medico);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Deletar um médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _medicoService.DeletarMedicoAsync(id);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }
    }
}
