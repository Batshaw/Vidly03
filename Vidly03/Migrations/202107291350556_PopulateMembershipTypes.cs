namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, DiscountRate, DurationInMonths, SignUpFee) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, DiscountRate, DurationInMonths, SignUpFee) VALUES (2, 10, 1, 30)");
            Sql("INSERT INTO MembershipTypes (Id, DiscountRate, DurationInMonths, SignUpFee) VALUES (3, 15, 3, 90)");
            Sql("INSERT INTO MembershipTypes (Id, DiscountRate, DurationInMonths, SignUpFee) VALUES (4, 20, 12, 300)");
        }
        
        public override void Down()
        {
        }
    }
}
