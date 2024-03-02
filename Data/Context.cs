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
           
        }

        public virtual DbSet<Movie>? Movies { get; set; }
        public virtual DbSet<Character>? Characters { get; set; }
        public virtual DbSet<Genre>? Genres { get; set; }

       

            
    }
}
