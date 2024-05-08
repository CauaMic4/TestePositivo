using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestePositivo.Models
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Rua { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000")]
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }


        [ForeignKey("Aluno")]
        [Required(ErrorMessage = "A seleção de um aluno é obrigatória.")]
        public int AlunoModelId { get; set; }
        public AlunoModel Aluno { get; set; }
    }
}
