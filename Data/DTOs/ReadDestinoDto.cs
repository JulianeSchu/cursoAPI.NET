using System.ComponentModel.DataAnnotations;



public class ReadDestinoDto
{
    public int Id { get; set; }
    public string Foto { get; set; }
    public string Nome { get; set; }
    public int Preco { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
