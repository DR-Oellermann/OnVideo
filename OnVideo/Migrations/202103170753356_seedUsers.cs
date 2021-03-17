namespace OnVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0bac6b4d-acf9-4653-bf01-27d347cbf47f', N'guest@onvideo.com', 0, N'AENvQhGfNXUYQQC74SzBQGVV/5GAiuH0eA2E+6vEp7vmdoC533FqmcsiMav251oHQQ==', N'94505857-cd9d-4cbb-90f9-90071fce86f8', NULL, 0, 0, NULL, 1, 0, N'guest@onvideo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'41fc3919-bbc5-4230-9deb-d3dcab20855f', N'admin2@onvideo.com', 0, N'AOdxbKD4go0hF/ITl2KDMmpQv/G+hFgb0WjiUOibPhkypLhDhRW1Z1ESv3AK9sgZlA==', N'f2b8569f-1ab9-4013-a2bd-35132e80ceea', NULL, 0, 0, NULL, 1, 0, N'admin2@onvideo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'53a17614-b459-4176-b166-b18b01dd4030', N'admin@onvideo.com', 0, N'AHdAFNaSgIWLIzO7+Myd33oQPu6ttp/bq7C8j7bWIHJ+2iZA+U7xSv0QKwNiXd0oBQ==', N'44757b5a-85ab-4315-995c-034e8009632c', NULL, 0, 0, NULL, 1, 0, N'admin@onvideo.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'46c63aa6-69c1-45f9-8eab-e5bf85c226a6', N'CanManageMovie')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'41fc3919-bbc5-4230-9deb-d3dcab20855f', N'46c63aa6-69c1-45f9-8eab-e5bf85c226a6')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
