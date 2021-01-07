using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    public class Location
    {
        [Key]
        public int IDLocation { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Prix_location { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Caution { get; set; }

        [ForeignKey("Client")]
        public int? IDClient { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Velo")]
        public int? IDVelo { get; set; }
        public virtual Velo Velo { get; set; }
    }
}