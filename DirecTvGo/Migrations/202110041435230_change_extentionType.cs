namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_extentionType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Extention", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "Extention", c => c.Int(nullable: false));
        }
    }
}
