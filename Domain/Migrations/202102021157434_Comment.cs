namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommodityId", c => c.Guid());
            AddColumn("dbo.Comments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Name");
            DropColumn("dbo.Comments", "CommodityId");
        }
    }
}
