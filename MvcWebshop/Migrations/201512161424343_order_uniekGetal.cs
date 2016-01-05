namespace MvcWebshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_uniekGetal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "uniekGetal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "uniekGetal");
        }
    }
}
