using challange_disney.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace challange_disney.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context>options ) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Peli 1", Image = "asda", Rating = 2, GenreId = 1, CreationDate = new DateTime(2014, 12, 20)}
                );
            builder.Entity<Character>().HasData(

                new Character { Id = 1, Age = 25,Bio="asd", Image="asdads", Name="Robert",Weight=75 });
            builder.Entity<Genre>().HasData(
                new Genre { Id=1, Image="asdasd", Name="Drama"}
                );
        }

        public virtual DbSet<Movie>? Movies { get; set; }
        public virtual DbSet<Character>? Characters { get; set; }
        public virtual DbSet<Genre>? Genres { get; set; }

       

            
    }
}
