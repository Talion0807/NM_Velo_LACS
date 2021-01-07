using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NM_Velo_LACS.Models
{

    public class Client
    {
        
        [Key]
        public int IDClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage ="Inserer seulement des chiffres")]
        public string GSM { get; set; }
        public string Email { get; set; }

        public ICollection<Vente>Ventes { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}