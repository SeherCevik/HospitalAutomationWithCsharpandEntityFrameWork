using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkHastaneOto
{
    class HastaDetay
    {
        public int id { get; set; }
        public int? Yas { get; set; }
        public int? Kilo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        [ForeignKey("HastaId")]
        [Required]
        public Hasta hasta { get; set; }

    }
}
