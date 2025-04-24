using System.ComponentModel.DataAnnotations;

namespace JornadaAPI.Data.DTOs;

public class CreateDepoimentoDto
{
    [Required(ErrorMessage = "É obrigatório adicionar uma foto.")]
    public string Foto { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    [Required]
    [StringLength(500, ErrorMessage = "O depoiemento não poderá exceder 500 caractéres.")]
    public string Depoimento { get; set; }
}
