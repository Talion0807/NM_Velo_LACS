using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NM_Velo_LACS.Models
{
    public class Fournisseur
    {
        [Key]
        public int IDFournisseur { get; set; }

        public string Nom_Fournisseur { get; set; }
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public string GSM { get; set; }
        public string Adresse_Email { get; set; }
        public string Adresse { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Code_Postal { get; set; }

        public ICollection<Achat> Achats { get; set; }
    }
}