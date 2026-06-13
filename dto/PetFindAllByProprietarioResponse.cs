using System;
using System.Collections.Generic;
using System.Text;

namespace dto
{
    public record PetFindAllByProprietarioResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Eta { get; set; }

        public DateTime DataNascita { get; set; }
    }
}
