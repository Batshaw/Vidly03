namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE DurationInMonths = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE DurationInMonths = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annually' WHERE DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
