using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM_Velo_LACS.Models
{
    public class VeloVenduAnnee
    {
        public Velo veloDetails { get; set; }

        public Vente venteDetails { get; set; }
    }
}