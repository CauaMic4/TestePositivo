﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestePositivo.Models
{
    [Table("Aluno")]
    public class AlunoModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Serie { get; set; }
        public string Segmento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }

        public List<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();
    }
}