using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    [MetadataType(typeof(UserMetada))]
    public partial class User
    {
        public string ConfirmMDP { get; set; }
    }
    public class UserMetada
    {
        [Display(Name = "Prenom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Prénom requis")]
        public string Prenom { get; set; }

        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nom requis")]
        public string Nom { get; set; }

        [Display(Name = "EmailID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email requis")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "DateDeNaissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateDeNaissance { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le mdp est requis")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 caractères requis")]
        public string MotDePasse { get; set; }

        [Display(Name = "Confirmé le mdp")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse", ErrorMessage = "L'adresse et le mdp ne sont pas correct")]
        public string ConfirmMDP { get; set; }

    }
}