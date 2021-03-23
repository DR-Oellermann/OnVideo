namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setdefaultvalue : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
