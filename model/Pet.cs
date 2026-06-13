using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace model
{
    [Table("pets")]
    public class Pet
    {
        [Column("pet_id")]
        public int Id { get; set; }

        [Column("pet_nome")]
        public string Nome { get; set; }

        [Column("pet_eta")]
        public int Eta { get; set; }

        [Column("pet_data_nascita")]
        public DateTime DataNascita { get; set; }

        [Column("pet_pro_id")]
        public int ProprietarioId { get; set; }

    }
}
