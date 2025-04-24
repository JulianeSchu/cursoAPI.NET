using System.ComponentModel.DataAnnotations;

namespace JornadaAPI.Models;

public class Depoimentos
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Foto { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Depoimento { get; set; }
}
