namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_session_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoginSessions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LoginSessions", new[] { "User_Id" });
            AddColumn("dbo.LoginSessions", "userId", c => c.String());
            DropColumn("dbo.LoginSessions", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoginSessions", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.LoginSessions", "userId");
            CreateIndex("dbo.LoginSessions", "User_Id");
            AddForeignKey("dbo.LoginSessions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
