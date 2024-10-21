using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Gerente Gerente { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
