namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenreAndColumnsToMovieGenreTableAndMoviesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Available", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Available");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "ReleasedDate");
            DropColumn("dbo.Movies", "MovieGenreId");
            DropTable("dbo.MovieGenres");
        }
    }
}
