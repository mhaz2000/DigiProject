namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commodities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                        Price = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Remaining = c.String(),
                        SalesNumber = c.Int(nullable: false),
                        Brand = c.String(),
                        AttachmentImageId = c.Guid(),
                        ImmediateSending = c.Boolean(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        PromotionId = c.Guid(),
                        Model = c.String(),
                        LaptopRam = c.Int(),
                        IsTouchable = c.Boolean(),
                        ScreenSize = c.Int(),
                        MatteImage = c.Boolean(),
                        RAM_Type = c.String(),
                        RAM_Size = c.Int(),
                        ScreenResolution = c.Int(),
                        GPU_Company = c.String(),
                        GPU_Size = c.Int(),
                        CPU = c.String(),
                        OS = c.String(),
                        InternalStorage = c.Int(),
                        MobileRam = c.Int(),
                        InternalStorage1 = c.Int(),
                        CameraResolution = c.Int(),
                        OS1 = c.String(),
                        Network = c.String(),
                        Model1 = c.String(),
                        CPU_Company = c.String(),
                        IntrnalStorageType = c.String(),
                        RAM = c.Int(),
                        Storage = c.Int(),
                        ConnectionType = c.String(),
                        StirageType = c.String(),
                        WaterResistance = c.Boolean(),
                        ImpactResistance = c.Boolean(),
                        MicrophoneInput = c.Boolean(),
                        USB_Input = c.Boolean(),
                        ConnectionType1 = c.String(),
                        ConnectorType = c.String(),
                        Backlight = c.Boolean(),
                        CarvedPersian = c.Boolean(),
                        LiquidResistance = c.Boolean(),
                        HaveMouse = c.Boolean(),
                        Backlight1 = c.Boolean(),
                        HDMI_Port = c.Boolean(),
                        USB_Port = c.Boolean(),
                        DVI_Port = c.Boolean(),
                        Resolution = c.Int(),
                        ResponseTime = c.Double(),
                        PanelType = c.String(),
                        Speaker = c.String(),
                        Size = c.Double(),
                        Material = c.String(),
                        SpecialFeature = c.String(),
                        ForMobile = c.Boolean(),
                        Rotate360 = c.Boolean(),
                        WirelessCharging = c.Boolean(),
                        Rechargeable = c.Boolean(),
                        Flow = c.Double(),
                        Capacity = c.Int(),
                        WeightClass = c.String(),
                        SpecialFeatures = c.String(),
                        OutputNumbers = c.Int(),
                        BodyMaterial = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AttachmentFiles", t => t.AttachmentImageId)
                .Index(t => t.AttachmentImageId);
            
            CreateTable(
                "dbo.AttachmentFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Name = c.String(),
                        Extension = c.String(),
                        Size = c.Int(nullable: false),
                        MimeType = c.String(),
                        IsPhysicalStorage = c.Boolean(nullable: false),
                        IsBinaryStorage = c.Boolean(nullable: false),
                        Binary = c.Binary(),
                        PhysicalPath = c.String(),
                        ImageWidth = c.Int(),
                        ImageHeight = c.Int(),
                        Description = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        PosterImageGuid = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Advantages = c.String(),
                        DisAdvantages = c.String(),
                        HasContent = c.Boolean(nullable: false),
                        Content = c.String(),
                        SuggestToFriends = c.Boolean(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostedComments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PersonID = c.Guid(nullable: false),
                        CommentID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        IsLogin = c.Boolean(nullable: false),
                        IsRegister = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Percent = c.Int(nullable: false),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        CommodityId = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Commodities", t => t.CommodityId)
                .Index(t => t.CommodityId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotions", "CommodityId", "dbo.Commodities");
            DropForeignKey("dbo.PostedComments", "PersonID", "dbo.People");
            DropForeignKey("dbo.PostedComments", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Commodities", "AttachmentImageId", "dbo.AttachmentFiles");
            DropIndex("dbo.Promotions", new[] { "CommodityId" });
            DropIndex("dbo.PostedComments", new[] { "CommentID" });
            DropIndex("dbo.PostedComments", new[] { "PersonID" });
            DropIndex("dbo.Commodities", new[] { "AttachmentImageId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Promotions");
            DropTable("dbo.People");
            DropTable("dbo.PostedComments");
            DropTable("dbo.Comments");
            DropTable("dbo.AttachmentFiles");
            DropTable("dbo.Commodities");
        }
    }
}
