namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubcribedToNewsletter, MembershipTypesId) VALUES ('Quang Dang', 1, 2)");
            Sql("INSERT INTO Customers (Name, IsSubcribedToNewsletter, MembershipTypesId) VALUES ('Anh Nguyen', 1, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
