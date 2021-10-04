namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login_session_change_tokenmax : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LoginSessions");
            AddColumn("dbo.LoginSessions", "login_id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LoginSessions", "token", c => c.String());
            AddPrimaryKey("dbo.LoginSessions", "login_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LoginSessions");
            AlterColumn("dbo.LoginSessions", "token", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.LoginSessions", "login_id");
            AddPrimaryKey("dbo.LoginSessions", "token");
        }
    }
}
