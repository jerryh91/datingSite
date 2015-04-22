namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConversationMeta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InitiatorID = c.Int(nullable: false),
                        ResponderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MessageDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                        MessageContent = c.String(),
                        ConversationMeta_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ConversationMeta", t => t.ConversationMeta_ID)
                .Index(t => t.ConversationMeta_ID);
            
            CreateTable(
                "dbo.ProfileMeta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProfileDetail",
                c => new
                    {
                        ProfileMetaID = c.Int(nullable: false),
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Age = c.String(),
                        Location = c.String(),
                        Gender = c.String(),
                        HighSchool = c.String(),
                        UndergraduateSchool = c.String(),
                        GraduateSchool = c.String(),
                    })
                .PrimaryKey(t => t.ProfileMetaID)
                .ForeignKey("dbo.ProfileMeta", t => t.ProfileMetaID)
                .Index(t => t.ProfileMetaID);
            
            CreateTable(
                "dbo.ProfileMetaConversationMeta",
                c => new
                    {
                        ProfileMeta_ID = c.Int(nullable: false),
                        ConversationMeta_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfileMeta_ID, t.ConversationMeta_ID })
                .ForeignKey("dbo.ProfileMeta", t => t.ProfileMeta_ID, cascadeDelete: true)
                .ForeignKey("dbo.ConversationMeta", t => t.ConversationMeta_ID, cascadeDelete: true)
                .Index(t => t.ProfileMeta_ID)
                .Index(t => t.ConversationMeta_ID);
            
            CreateTable(
                "dbo.ProfileMetaMessageDetail",
                c => new
                    {
                        ProfileMeta_ID = c.Int(nullable: false),
                        MessageDetail_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfileMeta_ID, t.MessageDetail_ID })
                .ForeignKey("dbo.ProfileMeta", t => t.ProfileMeta_ID, cascadeDelete: true)
                .ForeignKey("dbo.MessageDetail", t => t.MessageDetail_ID, cascadeDelete: true)
                .Index(t => t.ProfileMeta_ID)
                .Index(t => t.MessageDetail_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileDetail", "ProfileMetaID", "dbo.ProfileMeta");
            DropForeignKey("dbo.ProfileMetaMessageDetail", "MessageDetail_ID", "dbo.MessageDetail");
            DropForeignKey("dbo.ProfileMetaMessageDetail", "ProfileMeta_ID", "dbo.ProfileMeta");
            DropForeignKey("dbo.ProfileMetaConversationMeta", "ConversationMeta_ID", "dbo.ConversationMeta");
            DropForeignKey("dbo.ProfileMetaConversationMeta", "ProfileMeta_ID", "dbo.ProfileMeta");
            DropForeignKey("dbo.MessageDetail", "ConversationMeta_ID", "dbo.ConversationMeta");
            DropIndex("dbo.ProfileMetaMessageDetail", new[] { "MessageDetail_ID" });
            DropIndex("dbo.ProfileMetaMessageDetail", new[] { "ProfileMeta_ID" });
            DropIndex("dbo.ProfileMetaConversationMeta", new[] { "ConversationMeta_ID" });
            DropIndex("dbo.ProfileMetaConversationMeta", new[] { "ProfileMeta_ID" });
            DropIndex("dbo.ProfileDetail", new[] { "ProfileMetaID" });
            DropIndex("dbo.MessageDetail", new[] { "ConversationMeta_ID" });
            DropTable("dbo.ProfileMetaMessageDetail");
            DropTable("dbo.ProfileMetaConversationMeta");
            DropTable("dbo.ProfileDetail");
            DropTable("dbo.ProfileMeta");
            DropTable("dbo.MessageDetail");
            DropTable("dbo.ConversationMeta");
        }
    }
}
