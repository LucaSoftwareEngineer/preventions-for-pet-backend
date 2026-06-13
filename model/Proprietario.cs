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
        public int Id { get; set; }

        [Column("pro_nome")]
        public string Nome { get; set; }

        [Column("pro_cognome")]
        public string Cognome { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
