using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace model
{
    [Table("proprietari")]
    public class Proprietario
    {
        [Column("pro_id")]
        private int id { get; set; }

        [Column("pro_nome")]
        private string nome { get; set; }

        [Column("pro_cognome")]
        private string cognome { get; set; }

        private List<Pet> pets { get; set; } = new List<Pet>();
    }
}
