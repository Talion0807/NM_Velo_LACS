using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NM_Velo_LACS.Models
{
    public class BddContext : DbContext
    {
        public BddContext() : base()
        {
            
        }
        
        public DbSet<Achat> Achat { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<Location> Location { get; set; }

        public DbSet<Velo> Velo { get; set; }
        public DbSet<Vente> Vente { get; set; }
    }
}