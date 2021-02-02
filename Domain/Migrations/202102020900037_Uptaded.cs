namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uptaded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commodities", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Commodities", "Description");
        }
    }
}
