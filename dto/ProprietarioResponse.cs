using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dto
{
    public record ProprietarioResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public List<PetResponse> Pets { get; set; } = new List<PetResponse>();
    }
}
