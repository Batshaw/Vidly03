namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypesId");
            AddForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypesId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypesId" });
            DropColumn("dbo.Customers", "MembershipTypesId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
