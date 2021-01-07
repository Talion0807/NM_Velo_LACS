using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    public class Velo
    {
        [Key]
        public int IDVelo { get; set; }

        public string Marque { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Pouces { get; set; }
        public DateTime Annee_achat { get; set; }
        public string Couleur { get; set; }
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Prix_location { get; set; }
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Prix_vente { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Inserer seulement des chiffres")]
        public int Caution { get; set; }

        public string NomImage { get; set; }


        public ICollection<Vente> Ventes { get; set; }
        public ICollection<Achat> Achats { get; set; }
        public ICollection<Location> Locations { get; set; }

    }
}