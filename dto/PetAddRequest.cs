using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dto
{
    public record PetAddRequest
    {

        [Required(ErrorMessage = "Il nome del pet è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "L'età del pet è obbligatoria")]
        public int Eta { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        public DateTime DataNascita { get; set; }

        [Required(ErrorMessage = "L'id del proprietario è obbligatorio")]
        public int IdProprietario { get; set; }

    }
}
