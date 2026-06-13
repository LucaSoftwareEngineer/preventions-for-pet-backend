using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dto
{
    public record PetResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Eta { get; set; }

        public DateTime DataNascita { get; set; }

        public ProprietarioNoPetsResponse Proprietario { get; set; }
    }
}
