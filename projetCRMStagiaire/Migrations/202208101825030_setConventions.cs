namespace projetCRMStagiaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inscriptions", "Stagiaire_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Inscriptions", new[] { "Stagiaire_Id" });
            AlterColumn("dbo.ActiviteSportives", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.ActiviteSportives", "Description", c => c.String(maxLength: 225));
            AlterColumn("dbo.Inscriptions", "Stagiaire_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Inscriptions", "Stagiaire_Id");
            AddForeignKey("dbo.Inscriptions", "Stagiaire_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "Stagiaire_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Inscriptions", new[] { "Stagiaire_Id" });
            AlterColumn("dbo.Inscriptions", "Stagiaire_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ActiviteSportives", "Description", c => c.String());
            AlterColumn("dbo.ActiviteSportives", "Nom", c => c.String());
            CreateIndex("dbo.Inscriptions", "Stagiaire_Id");
            AddForeignKey("dbo.Inscriptions", "Stagiaire_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
