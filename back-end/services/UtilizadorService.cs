using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Backend.Services
{
    public class UtilizadorService
    {
        private readonly AppDbContext _context;

        public UtilizadorService(AppDbContext context)
        {
            _context = context;
        }

        // Método de registro de utilizador
        public async Task<(bool Success, string Message)> RegistrarUtilizadorAsync(Utilizador utilizador)
        {
            // Verificar se o número de saúde já está em uso
            if (await _context.Utilizadores.AnyAsync(u => u.NSaude == utilizador.NSaude))
            {
                return (false, "O número de saúde informado já está em uso.");
            }

            // Hashing da senha
            utilizador.Passe = BCrypt.Net.BCrypt.HashPassword(utilizador.Passe);

            try
            {
                // Adicionar o utilizador ao contexto
                await _context.Utilizadores.AddAsync(utilizador);
                await _context.SaveChangesAsync();  // Persistir no banco de dados
                return (true, "Utilizador registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao salvar no banco de dados: {ex.Message}");
            }
        }

        // Método para obter todos os utilizadores
        public async Task<List<Utilizador>> ObterTodosUtilizadoresAsync()
        {
            return await _context.Utilizadores.ToListAsync();
        }
    }
}
