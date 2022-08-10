namespace projetCRMStagiaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpropertytoUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nom", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prenom", c => c.String());
            AlterColumn("dbo.ActiviteSportives", "Nom", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActiviteSportives", "Nom", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Prenom");
            DropColumn("dbo.AspNetUsers", "Nom");
        }
    }
}
