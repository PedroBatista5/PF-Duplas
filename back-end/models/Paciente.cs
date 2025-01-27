using System;
using System.Collections.Generic;

namespace Backend.Models
public class Paciente
{
    public int IdPaciente { get; set; }

    [Required]
    [Column("n_saude")]
    public int NSaude { get; set; }

    [Required]
    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [Column("morada")]
    [StringLength(100)]
    public string Morada { get; set; }

    [Required]
    [Column("n_identidade")]
    public int NIdentidade { get; set; }

    public ICollection<Baixas> Baixas { get; set; } // Coleção para Baixas
    public ICollection<Utilizador> Utilizadores { get; set; } // Coleção para Utilizadores
}
