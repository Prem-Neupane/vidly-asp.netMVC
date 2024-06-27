namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MovieGenres (Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO dbo.MovieGenres (Id,Name) VALUES (2,'Action')");
            Sql("INSERT INTO dbo.MovieGenres (Id,Name) VALUES (3,'Family')");
            Sql("INSERT INTO dbo.MovieGenres (Id,Name) VALUES (4,'Romance')");
        }
        public override void Down()
        {
            Sql("DELETE dbo.MovieGenres WHERE Id in (1, 2, 3, 4) ");
        }
    }
}
