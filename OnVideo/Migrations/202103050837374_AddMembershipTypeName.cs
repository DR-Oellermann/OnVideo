namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set MembershipName = 'Pay as you go' WHERE DiscountRate = 0");
            Sql("Update MembershipTypes Set MembershipName = 'Monthly' WHERE DiscountRate = 10");
            Sql("Update MembershipTypes Set MembershipName = 'Quarterly' WHERE DiscountRate = 15");
            Sql("Update MembershipTypes Set MembershipName = 'Annual' WHERE DiscountRate = 20");
        }
        
        public override void Down()
        {
        }
    }
}
