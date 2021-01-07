using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM_Velo_LACS.Models
{
    public class Dal :IDal
    {
        private BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();
        }
        public List<Velo> ObtientTousLesVelos()
        {
            return bdd.Velo.ToList();
        }
        public void Dispose()
        {
            bdd.Dispose();
        }
       
    }
}