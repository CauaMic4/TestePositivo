using System.ComponentModel.DataAnnotations.Schema;

namespace TestePositivo.Models
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        public int Id { get; set; }
        public int AlunoModelId { get; set; }
        public virtual AlunoModel Aluno { get; set; }
        public string Tipo { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
    }
}
