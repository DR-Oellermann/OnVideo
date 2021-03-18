namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "phonNeumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "phonNeumber");
        }
    }
}
