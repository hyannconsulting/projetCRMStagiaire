namespace projetCRMStagiaire.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateActiviteSportive : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ActiviteSportives (Nom) VALUES ('BASKET BALL')");
            Sql("INSERT INTO ActiviteSportives (Nom) VALUES ('JUDO')");
            Sql("INSERT INTO ActiviteSportives (Nom) VALUES ('NATATION')");
        }

        public override void Down()
        {
            Sql("DELETE FROM ActiviteSportives ");
        }
    }
}
