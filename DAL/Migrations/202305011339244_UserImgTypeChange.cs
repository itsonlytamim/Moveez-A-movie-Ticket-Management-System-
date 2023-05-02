namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImgTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Photo", c => c.Binary());
        }
    }
}
