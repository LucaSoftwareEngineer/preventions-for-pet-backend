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
        private int id { get; set; }

        [Column("pet_nome")]
        private string nome { get; set; }

        [Column("pet_eta")]
        private int eta { get; set; }

        [Column("pet_data_nascita")]
        private DateTime dataNascita { get; set; }

        [Column("pet_pro_id")]
        private int proprietarioId { get; set; }

    }
}
