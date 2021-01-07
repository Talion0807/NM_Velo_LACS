using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM_Velo_LACS.Models
{
    public interface IDal : IDisposable
    {
        List<Velo> ObtientTousLesVelos();
       
        
    }
}