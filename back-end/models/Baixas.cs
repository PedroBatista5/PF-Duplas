public class Baixas
{
    public int IdBaixas { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    [Required]
    [Column("data_inic")]

    public DateTime DataInic { get; set; }

    [Required]
    [Column("data_fim")]

    public DateTime DataFim { get; set; }

    [Required]
    [Column("movivo")]
    [StringLength(300)]
    public string Motivo { get; set; }

    [Required]
    [Column("status")]
    [StringLength(100)]
    public string Status { get; set; }

    [Required]
    public int IdInstituicao { get; set; }
    public Instituicao Instituicao { get; set; } // Propriedade de navegação

    [Required]
    [Column("recomendacoes")]
    [StringLength(500)]
    public string Recomendacoes { get; set; }
}
