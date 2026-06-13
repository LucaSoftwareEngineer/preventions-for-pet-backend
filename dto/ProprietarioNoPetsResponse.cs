using System;
using System.Collections.Generic;
using System.Text;

namespace dto
{
    public record ProprietarioNoPetsResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }
    }
}
