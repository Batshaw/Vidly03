namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableToMoive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Available", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));

            Sql("UPDATE Movies SET Available = NumberInStock");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Available");
        }
    }
}
