using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JornadaAPI.Models;

public class Destinos
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Foto { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int Preco { get; set; }
}
