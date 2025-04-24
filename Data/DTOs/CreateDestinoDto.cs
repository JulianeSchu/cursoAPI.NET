using System.ComponentModel.DataAnnotations;

namespace JornadaAPI.Data.DTOs;

public class CreateDestinoDto
{
    [Required(ErrorMessage = "É obrigatório incluir uma imagem.")]
    public string Foto { get; set; }
    [Required(ErrorMessage = "Informe o nome do destino.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Informe o preço.")]
    public int Preco { get; set; }
}
