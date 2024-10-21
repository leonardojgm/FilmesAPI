using FilmesAPI.Models;
using System;

namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme { get; set; }

        public DateTime HorarioDeInicio { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
