using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    public class Vente
    {
        [Key]
        public int IDVente { get; set; }
        
        public DateTime Date_vente { get; set; }
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Prix_vente { get; set; }
        [ForeignKey("Client")]
        public int? IDClient { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Velo")]
        public int? IDVelo { get; set; }
        public virtual Velo Velo { get; set; }

    }
}