namespace DirecTvGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfirtsname : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 128),
                        Extention = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumber);
            
            AddColumn("dbo.AspNetUsers", "FirtsNameLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirtsNameLastName");
            DropTable("dbo.Phones");
        }
    }
}
