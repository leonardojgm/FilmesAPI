using System;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public object Cinemas { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
