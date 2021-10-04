namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_session : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginSessions",
                c => new
                    {
                        token = c.String(nullable: false, maxLength: 128),
                        Creation_date = c.DateTime(nullable: false),
                        Update_date = c.DateTime(nullable: false),
                        Last_login = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.token)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginSessions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LoginSessions", new[] { "User_Id" });
            DropTable("dbo.LoginSessions");
        }
    }
}
