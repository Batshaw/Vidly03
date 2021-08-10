namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b1032fdb-51c3-46ff-8f94-3a9f5106829c', N'admin@vidly.com', 0, N'AN9FIY0O6LEmc1+LWAK/BEPOu8sWk9v6iT+B2JBl4yEaW2MwKORH4OOa+Xv4anlKbQ==', N'2d730fa6-3bb2-408d-abe9-02d90715d6cf', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e172c4b1-015e-4101-8b26-9840b952a915', N'guest@vidly.com', 0, N'AHrayN/K2u/ilmry34ErHg3NpTOYI0Y/x+unY8/xVnqCT1HAUfLJ3X/4nkIhuaE6FQ==', N'f87a3d21-f496-4579-8a3f-9fd1c325f080', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8f485fc2-7ba3-4e8f-ab0d-4994c06b711e', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b1032fdb-51c3-46ff-8f94-3a9f5106829c', N'8f485fc2-7ba3-4e8f-ab0d-4994c06b711e')

");
        }
        
        public override void Down()
        {
        }
    }
}
