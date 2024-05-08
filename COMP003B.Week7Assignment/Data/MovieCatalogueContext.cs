using COMP003B.Week7Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Week7Assignment.Data
{
    public class MovieCatalogueContext :DbContext
    {
        public MovieCatalogueContext(DbContextOptions<MovieCatalogueContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<IMDB> IMDBs { get; set; }


    }
}
