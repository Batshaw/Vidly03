namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDateOfBirth : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = CAST('1992-02-25' AS DATETIME) WHERE Name = 'Quang Dang'");
            Sql("UPDATE Customers SET DateOfBirth = CAST('1991-11-23' AS DATETIME) WHERE Name = 'Anh Nguyen'");
        }
        
        public override void Down()
        {
        }
    }
}
