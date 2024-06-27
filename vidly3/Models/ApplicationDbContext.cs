using System.Collections.Generic;
using System.Data.Entity;

namespace vidly3.Models
{
    //Install-Package EntityFramework -IncludePrerelease
    public class ApplicationDbContext : DbContext
    {   
         public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

   
}