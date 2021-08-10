namespace Vidly03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Mission Impossible I', 2, CAST('1996-05-22' AS DATETIME), GETDATE(), 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Mission Impossible II', 2, CAST('2000-05-24' AS DATETIME), GETDATE(), 6)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Mission Impossible III', 2, CAST('2006-05-05' AS DATETIME), GETDATE(), 2)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Friends', 1, CAST('1994-09-22' AS DATETIME), GETDATE(), 7)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('LUCA', 3, CAST('2021-06-16' AS DATETIME), GETDATE(), 1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleasedDate, AddedDate, NumberInStock) VALUES ('Before Sunrise', 4, CAST('1995-01-27' AS DATETIME), GETDATE(), 1)");
        }
        
        public override void Down()
        {
        }
    }
}
