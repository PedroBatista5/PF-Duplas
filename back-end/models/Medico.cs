using System;
using System.Collections.Generic;

namespace Backend.Models
public class Medico
{
    public int IdMedico { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [Column("n_identidade")]
    public int NIdentidade { get; set; }

    [Required]
    [Column("especialidade")]
    [StringLength(100)]
    public string Especialidade { get; set; }

    [Required]
    [Column("instituicoes")]
    [StringLength(100)]
    public string Instituicoes { get; set; }

    [Required]
    public int IdInstituicao { get; set; }
    public Instituicao Instituicao { get; set; } // Propriedade de navegação
}
