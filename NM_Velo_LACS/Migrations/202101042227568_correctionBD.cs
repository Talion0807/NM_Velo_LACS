namespace NM_Velo_LACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionBD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veloes", "IDFournisseur", "dbo.Fournisseurs");
            DropIndex("dbo.Veloes", new[] { "IDFournisseur" });
            DropColumn("dbo.Veloes", "IDFournisseur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veloes", "IDFournisseur", c => c.Int());
            CreateIndex("dbo.Veloes", "IDFournisseur");
            AddForeignKey("dbo.Veloes", "IDFournisseur", "dbo.Fournisseurs", "IDFournisseur");
        }
    }
}
