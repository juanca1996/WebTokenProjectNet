namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_idPhone : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Phones");
            AddColumn("dbo.Phones", "id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String());
            AddPrimaryKey("dbo.Phones", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Phones");
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Phones", "id");
            AddPrimaryKey("dbo.Phones", "PhoneNumber");
        }
    }
}
