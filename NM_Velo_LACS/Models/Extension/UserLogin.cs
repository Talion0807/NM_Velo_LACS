using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NM_Velo_LACS.Models
{
    public class UserLogin
    {
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Email requise")]
        public string EmailID { get; set; }

        [Display(Name = "Mot De Passe")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mdp requise")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Display(Name ="Remember Me")]
        public bool RemeberMe { get; set; }
    }
}