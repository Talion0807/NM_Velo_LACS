using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    public class Achat
    {
        [Key]
        public int IDAchat { get; set; }

        public DateTime Date_Achat { get; set; }
        public int Prix { get; set; }

        [ForeignKey("Velo")]

        public int? IDVelo { get; set; }
        public virtual Velo Velo { get; set; }

        [ForeignKey("Fournisseur")]

        public int? IDFournisseur { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
    }
}