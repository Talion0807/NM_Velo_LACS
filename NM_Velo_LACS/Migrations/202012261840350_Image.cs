namespace NM_Velo_LACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Veloes", "NomImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veloes", "NomImage");
        }
    }
}
