namespace projetCRMStagiaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiviteSportives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdActiviteSportive = c.Int(nullable: false),
                        DateInscription = c.DateTime(nullable: false),
                        Stagiaire_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Stagiaire_Id)
                .Index(t => t.Stagiaire_Id);
            
            AddColumn("dbo.AspNetUsers", "Section", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "Stagiaire_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Inscriptions", new[] { "Stagiaire_Id" });
            DropColumn("dbo.AspNetUsers", "Section");
            DropTable("dbo.Inscriptions");
            DropTable("dbo.ActiviteSportives");
        }
    }
}
