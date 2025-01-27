using System;
using System.Collections.Generic;

namespace Backend.Models
public class Instituicao
{
    public int IdInstituicao { get; set; }

    [Required]
    [Column("nome_instituicao")]
    [StringLength(100)]
    public string NomeInstituicao { get; set; }

    [Required]
    [Column("morada")]
    [StringLength(100)]
    public string Morada { get; set; }

    [Required]
    [Column("setor")]
    [StringLength(100)]
    public string Setor { get; set; }

    public ICollection<Baixas> Baixas { get; set; } // Coleção para Baixas
    public ICollection<Medico> Medicos { get; set; } // Coleção para Medicos
}
