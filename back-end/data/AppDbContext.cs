using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Baixas> Baixas { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Baixas
            modelBuilder.Entity<Baixas>(entity =>
            {
                entity.HasKey(b => b.IdBaixas);
                entity.Property(b => b.IdBaixas).ValueGeneratedOnAdd();

                entity.Property(b => b.DataInic);
                entity.Property(b => b.DataFim);
                entity.Property(b => b.Motivo).HasMaxLength(300);
                entity.Property(b => b.Status).HasMaxLength(100);
                entity.Property(b => b.Recomendacoes).HasMaxLength(500);

                entity.HasOne(b => b.Paciente)
                      .WithMany(p => p.Baixas)
                      .HasForeignKey(b => b.IdPaciente)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Medico)
                      .WithMany(m => m.Baixas)
                      .HasForeignKey(b => b.IdMedico)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Instituicao)
                      .WithMany(i => i.Baixas)
                      .HasForeignKey(b => b.IdInstituicao)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade Instituicao
            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(i => i.IdInstituicao);
                entity.Property(i => i.IdInstituicao).ValueGeneratedOnAdd();

                entity.Property(i => i.NomeInstituicao).HasMaxLength(100);
                entity.Property(i => i.Morada).HasMaxLength(100);
                entity.Property(i => i.Setor).HasMaxLength(100);
            });

            // Configuração da entidade Medico
            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(m => m.IdMedico);
                entity.Property(m => m.IdMedico).ValueGeneratedOnAdd();

                entity.Property(m => m.Nome).HasMaxLength(100);
                entity.Property(m => m.NIdentidade);
                entity.Property(m => m.Especialidade).HasMaxLength(100);
                entity.Property(m => m.Instituicoes).HasMaxLength(100);

                entity.HasOne(m => m.Instituicao)
                      .WithMany(i => i.Medicos)
                      .HasForeignKey(m => m.IdInstituicao)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade Paciente
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(p => p.IdPaciente);
                entity.Property(p => p.IdPaciente).ValueGeneratedOnAdd();

                entity.Property(p => p.NSaude);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.Morada).HasMaxLength(100);
                entity.Property(p => p.NIdentidade);
            });

            // Configuração da entidade Utilizador
            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(u => u.IdUtilizador);
                entity.Property(u => u.IdUtilizador).ValueGeneratedOnAdd();

                entity.Property(u => u.NSaude);
                entity.Property(u => u.Passe).HasMaxLength(100);
                entity.Property(u => u.Tipo).HasMaxLength(100);
                entity.Property(u => u.Contacto);
                entity.Property(u => u.DataNasc);

                entity.HasOne(u => u.Paciente)
                      .WithMany(p => p.Utilizadores)
                      .HasForeignKey(u => u.IdPaciente)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Medico)
                      .WithMany(m => m.Utilizadores)
                      .HasForeignKey(u => u.IdMedico)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
