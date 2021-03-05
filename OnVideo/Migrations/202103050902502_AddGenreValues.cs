namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreValues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres Values ('Comedy')");
            Sql("Insert Into Genres Values ('Action')");
            Sql("Insert Into Genres Values ('Family')");
            Sql("Insert Into Genres Values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
