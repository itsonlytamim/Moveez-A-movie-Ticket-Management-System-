namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
