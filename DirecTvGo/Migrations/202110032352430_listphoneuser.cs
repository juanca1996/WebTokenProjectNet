namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listphoneuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Phones", "ApplicationUser_Id");
            AddForeignKey("dbo.Phones", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Phones", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Phones", "ApplicationUser_Id");
        }
    }
}
