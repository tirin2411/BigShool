namespace BigShool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledColumnToFollow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Followings", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Followings", "IsCanceled");
        }
    }
}
