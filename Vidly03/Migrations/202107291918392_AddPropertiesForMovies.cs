namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesForMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "ReleasedDate");
        }
    }
}
