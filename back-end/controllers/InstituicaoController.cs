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
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoService _instituicaoService;

        public InstituicaoController(InstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        // Criar uma instituição
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Instituicao instituicao)
        {
            if (instituicao == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _instituicaoService.CriarInstituicaoAsync(instituicao);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Obter todas as instituições
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var instituicoes = await _instituicaoService.ObterTodasInstituicoesAsync();

            if (instituicoes == null || instituicoes.Count == 0)
            {
                return NotFound(new { Message = "Nenhuma instituição encontrada." });
            }

            return Ok(instituicoes);
        }

        // Obter uma instituição por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instituicao = await _instituicaoService.ObterInstituicaoPorIdAsync(id);

            if (instituicao == null)
            {
                return NotFound(new { Message = "Instituição não encontrada." });
            }

            return Ok(instituicao);
        }

        // Atualizar uma instituição
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Instituicao instituicao)
        {
            if (instituicao == null)
            {
                return BadRequest(new { Message = "Dados inválidos." });
            }

            var (success, message) = await _instituicaoService.AtualizarInstituicaoAsync(id, instituicao);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }

        // Deletar uma instituição
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (success, message) = await _instituicaoService.DeletarInstituicaoAsync(id);

            if (success)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(new { Message = message });
        }
    }
}
