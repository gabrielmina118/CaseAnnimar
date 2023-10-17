using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CaseAnnimar.Application.Models;

[Table("Pessoas")]
public class Pessoa
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataInsercao { get; set; }
    public string Profissao { get; set; }
}