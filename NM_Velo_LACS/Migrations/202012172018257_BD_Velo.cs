namespace NM_Velo_LACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BD_Velo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        IDAchat = c.Int(nullable: false, identity: true),
                        Date_Achat = c.DateTime(nullable: false),
                        Prix = c.Int(nullable: false),
                        IDVelo = c.Int(),
                        IDFournisseur = c.Int(),
                    })
                .PrimaryKey(t => t.IDAchat)
                .ForeignKey("dbo.Fournisseurs", t => t.IDFournisseur)
                .ForeignKey("dbo.Veloes", t => t.IDVelo)
                .Index(t => t.IDVelo)
                .Index(t => t.IDFournisseur);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        IDFournisseur = c.Int(nullable: false, identity: true),
                        Nom_Fournisseur = c.String(),
                        GSM = c.String(),
                        Adresse_Email = c.String(),
                        Adresse = c.String(),
                        Code_Postal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDFournisseur);
            
            CreateTable(
                "dbo.Veloes",
                c => new
                    {
                        IDVelo = c.Int(nullable: false, identity: true),
                        Marque = c.String(),
                        Pouces = c.Int(nullable: false),
                        Annee_achat = c.DateTime(nullable: false),
                        Couleur = c.String(),
                        Prix_location = c.Int(nullable: false),
                        Prix_vente = c.Int(nullable: false),
                        Caution = c.Int(nullable: false),
                        IDFournisseur = c.Int(),
                    })
                .PrimaryKey(t => t.IDVelo)
                .ForeignKey("dbo.Fournisseurs", t => t.IDFournisseur)
                .Index(t => t.IDFournisseur);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        IDLocation = c.Int(nullable: false, identity: true),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                        Prix_location = c.Int(nullable: false),
                        Caution = c.Int(nullable: false),
                        IDClient = c.Int(),
                        IDVelo = c.Int(),
                    })
                .PrimaryKey(t => t.IDLocation)
                .ForeignKey("dbo.Clients", t => t.IDClient)
                .ForeignKey("dbo.Veloes", t => t.IDVelo)
                .Index(t => t.IDClient)
                .Index(t => t.IDVelo);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        GSM = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        IDVente = c.Int(nullable: false, identity: true),
                        Date_vente = c.DateTime(nullable: false),
                        Prix_vente = c.Int(nullable: false),
                        IDClient = c.Int(),
                        IDVelo = c.Int(),
                    })
                .PrimaryKey(t => t.IDVente)
                .ForeignKey("dbo.Clients", t => t.IDClient)
                .ForeignKey("dbo.Veloes", t => t.IDVelo)
                .Index(t => t.IDClient)
                .Index(t => t.IDVelo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achats", "IDVelo", "dbo.Veloes");
            DropForeignKey("dbo.Achats", "IDFournisseur", "dbo.Fournisseurs");
            DropForeignKey("dbo.Locations", "IDVelo", "dbo.Veloes");
            DropForeignKey("dbo.Locations", "IDClient", "dbo.Clients");
            DropForeignKey("dbo.Ventes", "IDVelo", "dbo.Veloes");
            DropForeignKey("dbo.Ventes", "IDClient", "dbo.Clients");
            DropForeignKey("dbo.Veloes", "IDFournisseur", "dbo.Fournisseurs");
            DropIndex("dbo.Ventes", new[] { "IDVelo" });
            DropIndex("dbo.Ventes", new[] { "IDClient" });
            DropIndex("dbo.Locations", new[] { "IDVelo" });
            DropIndex("dbo.Locations", new[] { "IDClient" });
            DropIndex("dbo.Veloes", new[] { "IDFournisseur" });
            DropIndex("dbo.Achats", new[] { "IDFournisseur" });
            DropIndex("dbo.Achats", new[] { "IDVelo" });
            DropTable("dbo.Ventes");
            DropTable("dbo.Clients");
            DropTable("dbo.Locations");
            DropTable("dbo.Veloes");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Achats");
        }
    }
}
