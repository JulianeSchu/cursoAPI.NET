using System.ComponentModel.DataAnnotations;

namespace JornadaAPI.Data.DTOs;

public class ReadDestinoDto
{
    public string Foto { get; set; }
    public string Nome { get; set; }
    public string Depoimento { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
