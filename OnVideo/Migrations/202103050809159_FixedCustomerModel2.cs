namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCustomerModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id");
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
