namespace projetCRMStagiaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInscriptionModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Inscriptions", name: "Stagiaire_Id", newName: "StagiaireId");
            RenameIndex(table: "dbo.Inscriptions", name: "IX_Stagiaire_Id", newName: "IX_StagiaireId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Inscriptions", name: "IX_StagiaireId", newName: "IX_Stagiaire_Id");
            RenameColumn(table: "dbo.Inscriptions", name: "StagiaireId", newName: "Stagiaire_Id");
        }
    }
}
