using challange_disney.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace challange_disney.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context>options ) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Acción"},
                new Genre { Id = 2, Name = "Aventura" },
                new Genre { Id = 3, Name = "Comedia" }
           
            );
            builder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Pedro", Age = 30, Weight = 70, Bio = "Bio de Pedro", Image="image_Pedro.png" },
                new Character { Id = 2, Name = "Angel", Age = 25, Weight = 65, Bio = "Bio de Angel", Image="image_Angel.png" } 
            );
            builder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "El arte", Rating = 3, CreationDate = DateTime.Now, Image = "image.png", GenreId=1 },
                new Movie { Id = 2, Title = "La luz", Rating = 4, CreationDate = DateTime.Now, Image = "image2.png", GenreId=3 }
                );

        
        }

        public virtual DbSet<Movie>? Movies { get; set; }
        public virtual DbSet<Character>? Characters { get; set; }
        public virtual DbSet<Genre>? Genres { get; set; }
       
       

            
    }
}
