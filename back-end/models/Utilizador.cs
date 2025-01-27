using System;
using System.Collections.Generic;

namespace Backend.Models
public class Utilizador
{
    public int IdUtilizador { get; set; }

    [Required]
    [Column("n_saude")]
    public int NSaude { get; set; }

    [Required]
    [Column("passe")]
    [StringLength(100)]
    public string Passe { get; set; }

    [Required]
    [Column("tipo")]
    [StringLength(100)]
    public string Tipo { get; set; }

    [Required]
    [Column("contacto")]
    public int Contacto { get; set; }
    [Required]

    public int IdPaciente { get; set; }
    public Paciente Paciente { get; set; } // Propriedade de navegação

    [Required]
    public int IdMedico { get; set; }
    public Medico Medico { get; set; } // Propriedade de navegação

    [Required]
    [Column("data_nasc")]
    public DateTime DataNasc { get; set; }
}
