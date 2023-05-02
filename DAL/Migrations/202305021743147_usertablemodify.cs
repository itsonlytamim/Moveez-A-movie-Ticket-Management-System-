namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertablemodify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Photo", c => c.Binary());
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
